using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CellPhoneService_.view.Menu
{
    public  class SignInProcess
    {
        private  TextBox login;
        private  TextBox password;
        private  Form myForm;
        private Size textboxSize;
        private BackButton backButton;
        private void InitializeElements()
        {
            textboxSize = new Size(200, 30);

            login = new TextBox();
            login.Location = new Point(myForm.Width / 2 - textboxSize.Width/2, myForm.Height / 2 - 60);
            login.Size = textboxSize;
            login.Visible = true;

            password = new TextBox();
            password.Location = new Point(login.Location.X, login.Location.Y+50 );
            password.Size = textboxSize;
            password.Visible = true;

            myForm.Controls.Add(login);
            myForm.Controls.Add(password);
        }

        public SignInProcess(Form myForm, BackButton backButton)
        {
            this.myForm = myForm;
            InitializeElements();
            this.backButton = backButton;
            backButton.status = BackStatus._SignInPage;
            backButton.Back.Visible = true;
        }
    }
}
