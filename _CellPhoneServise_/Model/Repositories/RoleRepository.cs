using _CellPhoneService_.Entity;
using System.Data;
using System.Data.SqlClient;

namespace _CellPhoneService_.Model.Repositories
{
    public class RoleRepository
    {
        public List<Roles> getRoles(SqlConnection connection)
        {
            string query = "SELECT * from roles;";
            List < Roles > roles = null;
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        string roleName = Convert.ToString(reader["role"]); 

                        Roles role = new Roles(id, roleName);
                        roles.Add(role);
                    }
                }
                return roles;
            }
        }

        public string getRole(SqlConnection connection, int id)
        {
            string query = "SELECT role FROM roles WHERE id = " + id.ToString();
            string role = "";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        role = Convert.ToString(reader["role"]);
                    }
                }
            }
            return role;
        }
    }
}
