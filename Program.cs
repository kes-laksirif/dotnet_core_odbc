using System;
using System.Data.Odbc;

namespace MyOdbcTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string str = "DRIVER={Progress OpenEdge 10.2B Driver};DSN=alpha102b;HOST=user-PC;DB=alpha102;UID=laksiri;PWD=laksiri;PORT=16400; ";
            str = "DSN=alpha102b;HOST=user-PC;DB=alpha102;UID=laksiri;PWD=laksiri;PORT=16400; ";
            InsertRow(str);
            Console.WriteLine("Done!");
        }

        static private void InsertRow(string connectionString)
        {
            string queryString = "SELECT \"Emp-Code\", PW FROM pub.SelfUser";
            OdbcCommand command = new OdbcCommand(queryString);

            using (OdbcConnection connection = new OdbcConnection(connectionString))
            {
                command.Connection = connection;
                connection.Open();
                //command.ExecuteNonQuery();
                var dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    string sUser = dataReader.GetString(0);
                    string sPwd = dataReader.GetString(0);
                    Console.WriteLine("User: " + sUser + ", Password: " + sPwd);
                }

                // The connection is automatically closed at 
                // the end of the Using block.
            }
        }
    }
}

//dotnet new console -o MyOdbcTest
//cd MyOdbcTest
//dotnet add package System.Data.Odbc
//code .
//dotnet build
//dotnet run
