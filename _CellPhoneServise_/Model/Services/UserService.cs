using _CellPhoneService_.Entity;
using _CellPhoneService_.Model.Repository;
using System.Configuration;
using System.Data.SqlClient;

namespace _CellPhoneService_.Model.Services
{
    public class UserService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["db_connectionString"].ConnectionString;
        UserRepository repository = new UserRepository();

        public List<User_> getAllUsers()
        {
            List<User_>? users = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    users = repository.getAllUsers(connection);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return users;
        }

        public User_ signInUser(string email, string password)
        {
            User_ user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    user = repository.getUserByEmail(email,connection);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            if(user != null)
            {
                if (user.Password == password) return user; 
            }
            return  null;

        }
        //public int createNewAccount(string name, string  email, string password)
        //{
        //    int id = 0;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            repository.createNewAccount(connection, name, email, password);
        //        }

        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //    return id;
        //}
        //public User getAccountById(int id)
        //{
        //    User account = null;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            account = repository.getAccountById(connection, id);
        //        }

        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //        return account;
        //    }
        //}

        //public void updateAccountName(int id, string newName)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            repository.updateAccountName(connection,id, newName);
        //        }
        //        catch(Exception ex)
        //        {
        //            Console.WriteLine("\n" + ex.Message + "\n");
        //        }
        //    }



        //}

        //public void deleteAccount(int id)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //            repository.deleteAccount(connection,id);
        //        }
        //        catch(Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }
        //}
        //public User SighIn(string login, string password)
        //{
        //    User account = null;
        //    using(SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //           account = repository.SighIn(connection, login, password);
        //        }
        //        catch(Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }

        //    }
        //    return account;
        //}
    }
}
