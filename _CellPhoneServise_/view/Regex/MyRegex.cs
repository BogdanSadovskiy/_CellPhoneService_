using System.Text.RegularExpressions;

namespace _CellPhoneService_.view.Regex
{
    public class MyRegex
    {
        private static string emailPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

        public static bool checkEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.Match(email, emailPattern).Success;


        }
    }
}
