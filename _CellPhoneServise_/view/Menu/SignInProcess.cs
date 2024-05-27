using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CellPhoneService_.view.Menu
{
    public  class SignInProcess
    {
        private Button SignIn;
        private Size buttonSize;
        private Point SignInLocation;
        private  TextBox login;
        private  TextBox password;
        private  Form myForm;
        private Size textboxSize;
        private BackButton backButton;
        private void InitializeElements()
        {
            buttonSize = new Size(70, 20);
            textboxSize = new Size(200, 30);

            SignInLocation = new Point(myForm.Width / 2 - buttonSize.Width / 2 + myForm.Height / 2  + myForm.Height / 4 + 20);

            login = new TextBox();
            login.Location = new Point(myForm.Width / 2 - textboxSize.Width/2, myForm.Height / 2 - 60);
            login.Size = textboxSize;
            login.Visible = true;

            password = new TextBox();
            password.Location = new Point(login.Location.X, login.Location.Y+50 );
            password.Size = textboxSize;
            password.Visible = true;

            SignIn = new Button();
            SignIn.Text = "Sign In";
            SignIn.TextAlign = ContentAlignment.MiddleCenter;
            SignIn.Location = SignInLocation;
            SignIn.Size = buttonSize;
            SignIn.Click += SignIn_Click;

            myForm.Controls.Add(login);
            myForm.Controls.Add(password);
            myForm.Controls.Add(SignIn);
        }

        private void isLoginOk(string login)
        {

        }

        private void SignIn_Click(object? sender, EventArgs e)
        {
            
        }

        public SignInProcess(Form myForm, BackButton backButton)
        {
            this.myForm = myForm;
            this.backButton = backButton;
            backButton.status = BackStatus._SignInPage;
            backButton.Back.Visible = true;
 
        }
        public void startSignIn()
        {
            InitializeElements();
        }
    }
}
