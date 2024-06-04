using _CellPhoneService_.view.Regex;

namespace _CellPhoneService_.view.Service
{
    public class ViewCheck
    {
       
        public static bool isLoginOk(string login)
        {
            return MyRegex.checkEmail(login);
        }

        public static bool isPasswordOk(string password) 
        {
            return true;
        }
        

        public static bool checkIsInputtedEmpty(string inputted)
        {
            return inputted == "";
        }
    }
}
