using _CellPhoneService_.Controller;
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
        string success = "Success";
        string internalErrorMessage = "Internal database ERROR";

        public Instance< List<User_>> getAllUsers()
        {
            Instance<List<User_>>? users = new Instance<List<User_>>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    users.obj = repository.getAllUsers(connection);
                }

                catch (Exception ex)
                {
                    users.setMessageStr( internalErrorMessage);
                    users.setMessageError(Errors.SystemError);
                }
            }
            return users;
        }
        public Instance<User_> getUserByEmail(string email)
        {
            Instance<User_> userInstance = new Instance<User_>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    userInstance.obj = repository.getUserByEmail(email, connection);
                }
                catch (Exception ex)
                {
                    userInstance.setMessageStr (internalErrorMessage);
                    userInstance.setMessageError( Errors.SystemError);
                    return userInstance;
                }
                if (userInstance.obj == null)
                {
                    userInstance.setMessageStr ( "Can not find user");
                }
                return userInstance;
            }


        }
        public Instance<User_> signInUser(string email, string password)
        {
            Instance<User_> userInstance = getUserByEmail(email);

            if (userInstance.obj == null)
            {
                userInstance.setMessageError( Errors.ClientError);
                userInstance.setMessageStr( "Login or Password are uncorrect");
            }
            if (userInstance.obj.Password == password)
                userInstance.setMessageStr(success);

            return userInstance;
        }

        public Messages createNewAccount(string email, string password)
        {
            int id;
            if (getUserByEmail(email).obj != null) 
                return new Messages("Login already exists", Errors.ClientError);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    id = repository.createNewAccount(connection, email, password);
                }

                catch (Exception ex)
                {
                    return new Messages( ex.Message, Errors.SystemError);
                }
            }
            return new Messages( $"Successfuly created account {id}");
        }
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
        public Messages updateUserPassword (int id, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    repository.updateUserName(connection, id, newPassword);
                }
                catch (Exception ex)
                {
                    return new Messages(ex.Message, Errors.SystemError);
                }
            }
            return new Messages();
        }

        public Messages updateUserName(int id, string newName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    repository.updateUserName(connection, id, newName);
                }
                catch (Exception ex)
                {
                    return new Messages(ex.Message,Errors.SystemError);
                }
            }
            return new Messages();

        }
        public Messages updateUserPhone(int id, string newPhone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    repository.updateUserPhone(connection, id, newPhone);
                }
                catch (Exception ex)
                {
                    return new Messages(ex.Message, Errors.SystemError);
                }
            }
            return new Messages();
        }

        


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
