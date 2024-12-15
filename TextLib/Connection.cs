using MySql.Data.MySqlClient;

namespace TextLib; 
public class Connection {
    public static string conn_string = $"server={server}database={database}" +
            $"Uid={Uid}password={password}";
    public static MySqlConnection conn = new MySqlConnection(conn_string);

    static string server = "127.0.0.1;";
    static string database = "db_textwave;";
    static string Uid = "root;";
    static string password = ";";

    public void CreateUser(string user, string email, string password) {
        using (conn) {
            try {
                conn.Open();
                string query = $"INSERT INTO usuarios VALUES ('{user}' , '{email}', '{password}');";
                var command = new MySqlCommand(query, conn);

                int cmd = command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Console.WriteLine("Error al crear usuario: " + ex);
            }
        }
    }
}
