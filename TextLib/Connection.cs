using MySql.Data.MySqlClient;

namespace TextLib; 
public class Connection {
    public static string conn_string = $"server={server}database={database}" +
            $"Uid={Uid}password={password}";
    public static MySqlConnection conn = new MySqlConnection(conn_string);
    static string? insertedID;

    static string server = "127.0.0.1;";
    static string database = "db_textwave;";
    static string Uid = "root;";
    static string password = ";";

    public bool CreateUser(string user, string email, string password) {
        using (conn) {
            try {
                conn.Open();
                string query = $"INSERT INTO usuarios VALUES ('{user}' , '{email}', '{password}');";
                var command = new MySqlCommand(query, conn);

                int cmd = command.ExecuteNonQuery();

                query = $"SELECT LAST_INSERT_ID();";
                using (command = new MySqlCommand(query, conn)) {
                    insertedID = command.ExecuteScalar().ToString();
                }
                
                return true;
            }
            catch (Exception) { }
            return false;
        }
    }

    public string? GetUserID() {
        string? userID = "";
        
        using (conn) {
            try {  
                conn.Open();

                string query = $"SELECT LAST_INSERT_ID();";
                using (var command = new MySqlCommand(query, conn)) {
                    userID = command.ExecuteScalar().ToString();
                    return userID;
                }
                
            }
            
            catch {
                return null;
            }
        }

    }


    public bool LogIn(string id, string pass) {
        string?[] result = [];
        string? queryPass;

        try { 
            using (conn) {
           
                conn.Open();
                string query = $"SELECT password FROM usuarios WHERE id = {id};";
                var command = new MySqlCommand(query, conn);

                queryPass = command.ExecuteScalar().ToString();

                if (queryPass == pass) {
                    return true;
                }
            }
        }
        catch (Exception) { }

        return false;
    }
}
