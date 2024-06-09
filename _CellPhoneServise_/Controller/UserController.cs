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

        public Messages createNewAccount(string email, string password, int roleId)
        {
            return userService.createNewAccount( email, password, roleId);
        }

        public Messages updateUserFirstName(int id, string newName)
        {
            return userService.updateUserFirstName(id, newName);
        }

        public Messages updateUserLastName(int id, string newName)
        {
            return userService.updateUserLastName(id, newName);
        }

        public Messages updateUserPhone(int id, string newPhone)
        {
            return userService.updateUserPhone(id, newPhone);
        }

        public User_ getUserById(int id)
        {
            return userService.getUserById(id);
        }


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
