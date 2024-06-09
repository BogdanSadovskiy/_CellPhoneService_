

namespace _CellPhoneService_.view.Regex
{
    public class MyRegex
    {
        private static string emailPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

        public static bool checkEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.Match(email, emailPattern).Success;


        }

        public static bool isPasswordStrong(string password)
        {
            string pattern = @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*\W).{8,}$";
            return System.Text.RegularExpressions.Regex.Match(password, pattern).Success; 
        }

        public static bool isPasswordMiddleStrength(string password)
        {
            string pattern = @"^(?=.*[a-zA-Z])(?=.*\\d).{6,}$";
            return System.Text.RegularExpressions.Regex.Match(password, pattern).Success;
        }

        public static bool isPasswordWeak(string password)
        {
            string pattern = @"^(?=.*[a-zA-Z]).{4,}$";
            return System.Text.RegularExpressions.Regex.Match(password, pattern).Success;
        }
    }
}
