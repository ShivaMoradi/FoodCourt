using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

MySqlConnection? db = null;
string connectionString = "server=localhost;uid=root;pwd=mypassword;database=Food_Court;port=3306";

try
{

    db = new(connectionString);
    db.Open();

    string query = "SELECT name, role FROM users";
    MySqlCommand command = new(query, db);

    using var reader = command.ExecuteReader();

    while (reader.Read())
    {
        string role = reader.GetString("role");
        string name = reader.GetString("name");
        Console.WriteLine($"{name} has role: {role}");
    }


}
catch (MySqlException e)
{
    Console.WriteLine(e);

}
finally
{
    db.Close();
}
app.MapGet("/", () => "Hello World!");

app.Run();
