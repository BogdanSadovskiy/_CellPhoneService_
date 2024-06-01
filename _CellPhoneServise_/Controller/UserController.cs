using _CellPhoneService_.Entity;
using _CellPhoneService_.Model.Services;

namespace _CellPhoneService_.Controller
{
    public class UserController
    {
        private UserService userService = new UserService();
        public Instance< List<User_>> getAllUsers()
        {

            return userService.getAllUsers();
        }

        public Instance<User_> loginUser(string email, string password) 
        {
            return userService.signInUser(email, password); 
        }

        public Messages createNewAccount(string email, string password)
        {
            return userService.createNewAccount( email, password);
        }

        public Messages updateUserName(int id, string newName)
        {
            return userService.updateUserName(id, newName);
        }

        public Messages updateUserPhone(int id, string newPhone)
        {
            return userService.updateUserPhone(id, newPhone);
        }

        //    public User getAccountById(int id)
        //    {
        //        return serviceAccount.getAccountById(id);
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
