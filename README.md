"# dotnet_core_odbc" 

dotnet new console -o MyOdbcTest
cd MyOdbcTest
dotnet add package System.Data.Odbc
code .
dotnet build
dotnet run