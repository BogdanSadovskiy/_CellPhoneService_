using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CellPhoneService_.view.Menu
{
    public class Login
    {
        Form myForm;
        TextBox login;

        public void InitializeSignInLogin(Form form, TextBox login)
        {
            myForm = form;
            this.login = login;
        }

    }
}
