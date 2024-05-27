using _CellPhoneService_.Entity;
using _CellPhoneService_.Model.Services;

namespace _CellPhoneService_.Controller
{
    public class UserController
    {
        private UserService userService = new UserService();
        public List<User_> getAllUsers()
        {

            return userService.getAllUsers();
        }

        public Instance<User_> loginUser(string email, string password) 
        {
            return userService.signInUser(email, password); 
        }

        public string createNewAccount(string email, string password)
        {
            return serviceAccount.createNewAccount( email, password);
        }
        //    public User getAccountById(int id)
        //    {
        //        return serviceAccount.getAccountById(id);
        //    }
        //    public void updateAccountName(int id, string newName)
        //    {
        //        serviceAccount.updateAccountName(id, newName);
        //    }

        //    public void deleteAccount(int id)
        //    {
        //        serviceAccount.deleteAccount(id);
        //    }

        //    public User SighIn(string login, string password)
        //    {
        //        return serviceAccount.SighIn(login, password);
        //    }
    }
}
