using _CellPhoneService_.Entity;
using System.Data.SqlClient;

namespace _CellPhoneService_.Model.Repository
{
    public class UserRepository
    {

        public List<User_> getAllUsers(SqlConnection connection)
        {

            List<User_> users = new List<User_>();
            string query = "SELECT * from users;";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string firstName = Convert.ToString(reader["fname"]);
                        string lastName = Convert.ToString(reader["sname"]);
                        string phoneNumber = Convert.ToString(reader["number_of_telephone"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);
                        int roleId = Convert.ToInt32(reader["role_id"]);
                        User_ user = new User_(id, firstName, lastName, phoneNumber, email, password, roleId);
                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public User_ getUserByEmail(string email, SqlConnection connection)
        {
            User_ user = null;
            string query = $"SELECT * FROM users WHERE email = '{email}';";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string firstName = Convert.ToString(reader["fname"]);
                        string lastName = Convert.ToString(reader["sname"]);
                        string phoneNumber = Convert.ToString(reader["number_of_telephone"]);
                        string email_ = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);
                        int roleId = Convert.ToInt32(reader["role_id"]);
                        user = new User_(id, firstName, lastName, phoneNumber, email_, password, roleId);
                    }
                }
            }
            return user;
        }
        public int createNewAccount(SqlConnection connection, string email, string password, int roleId)
        {
            string query = "INSERT INTO accounts (email, password, role_id) OUTPUT INSERTED.id VALUES (@Email, @Password, @RoleId);";
            int id = 0;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = email;
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.NVarChar).Value = password;
                cmd.Parameters.Add("@RoleId", System.Data.SqlDbType.Int).Value = roleId;

                id = (int)cmd.ExecuteScalar();
            }
            return id;
        }


        public User_ getUserById(SqlConnection connection, int id)
        {
            User_ account = null;
            string query = "SELECT * FROM accounts WHERE id = " + id.ToString() + ";";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id_ = Convert.ToInt32(reader["id"]);
                        string firstName = Convert.ToString(reader["fname"]);
                        string lastName = Convert.ToString(reader["sname"]);
                        string phoneNumber = Convert.ToString(reader["number_of_telephone"]);
                        string email = Convert.ToString(reader["email"]);
                        string password = Convert.ToString(reader["password"]);
                        int roleId = Convert.ToInt32(reader["role_id"]);
                        account = new User_(id_, firstName, lastName, phoneNumber, email, password, roleId);
                    }
                }
            }
            return account;
        }

        public void updateUserFirstName(SqlConnection connection, int id, string newName)
        {
            string query = "UPDATE users SET fname = @fname WHERE id = @id";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@fname", System.Data.SqlDbType.NVarChar).Value = newName;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                cmd.ExecuteNonQuery();
            }
        }

        public void updateUserLastName(SqlConnection connection, int id, string newName)
        {
            string query = "UPDATE users SET sname = @sname WHERE id = @id;";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@sname", System.Data.SqlDbType.NVarChar).Value = newName;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                cmd.ExecuteNonQuery();
            }
        }

        public void updateUserPhone(SqlConnection connection, int id, string newPhone)
        {
            string query = "UPDATE  users SET number_of_telephone  = @newPhone  WHERE id = @id;";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@newPhone", System.Data.SqlDbType.NVarChar).Value = newPhone;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            }
        }

        public void updateUserPassword(SqlConnection connection, int id, string newPassword)
        {
            string query = "UPDATE  users SET password  = @newPassword  WHERE id = @id";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.Add("@newPassword", System.Data.SqlDbType.NVarChar).Value = newPassword;
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            }
        }
        //public void deleteAccount(SqlConnection connection,int id)
        //{
        //    string query = "DELETE FROM accounts WHERE ID = @id";
        //    using(SqlCommand cmd = new SqlCommand(query,connection))
        //    {
        //        cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        //public User SighIn(SqlConnection connection, string login, string password)
        //{

        //}
    }
}
