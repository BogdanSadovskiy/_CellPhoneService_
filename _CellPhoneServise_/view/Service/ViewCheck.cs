using _CellPhoneService_.view.Regex;

namespace _CellPhoneService_.view.Service
{
    public class ViewCheck
    {
       
        public bool isLoginOk(string login)
        {
            return MyRegex.checkEmail(login);
        }

        
    }
}
