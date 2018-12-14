This project is consisted of front-end Blazor, Back-end ASP.NET Web API, MySQL database and several third Web APIs.

To run this project, you need to install Blazor package together with ASP.NET runtime environment. Also, you need to install MySQL database (https://dev.mysql.com/downloads/mysql/).

After these installation, you need to configure MySQL and open its interface in a command line. 

1. open a terminal, input 
    "mysql -uroot -pYOUR_PASSWORD". 
(For the convenience, we use root account to create database)
2. Create a database (You can name it whatever you like)
    "create database DATABASE_NAME;"
3. Change to the database you created
    "use DATABASE_NAME"
4. Execute the freshtomatoes.sql file to create and insert tables.
    "source ../../freshtomatoes.sql"
5. Once it shows Query OK, you need to open the file "FinalProject\Backend\Backend\Models\service\SqlConnector.cs", and change the constructor with your own configurations.
6. Next open another terminal and input 
    "cd ..\..\FinalProject\Backend\Backend"
    "dotnet run"
7. Open the third terminal and input 
    "cd ..\..\FinalProject\Frontend"
    "dotnet run"
8. Open your browser and input url "http://localhost:8000"

Now, your are all set.