using _CellPhoneService_.Controller;
using _CellPhoneService_.Entity;
using _CellPhoneService_.Model.Repositories;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace _CellPhoneService_.Model.Services
{
    public class RoleService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["db_connectionString"].ConnectionString;
        string internalErrorMessage = "Internal database ERROR";
        RoleRepository repository = new RoleRepository();

        public Instance<List<Roles>> getRoles()
        {
            Instance<List<Roles>>? roles = new Instance<List<Roles>>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    roles.obj = repository.getRoles(connection);
                }

                catch (Exception ex)
                {
                    roles.setMessageStr(internalErrorMessage);
                    roles.setMessageError(Errors.SystemError);
                }
            }
            return roles;
        }
        public Instance<RoleStatus> getRole(int id)
        {
            Instance<RoleStatus> role = new Instance<RoleStatus>();
            string role_ = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    role_ = repository.getRole(connection, id);
                }

                catch (Exception ex)
                {
                    role.setMessageStr(internalErrorMessage);
                    role.setMessageError(Errors.SystemError);
                }
            }
            role.obj = RoleHelper.GetRole(role_);
            return role;
        }
    }
}
