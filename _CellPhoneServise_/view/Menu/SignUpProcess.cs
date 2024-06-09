using _CellPhoneService_.Controller;
using _CellPhoneService_.view.Navigation;
using System.Runtime.CompilerServices;

namespace _CellPhoneService_.view.Menu
{
    public class SignUpProcess : Page
    {
        private Button SignUp;
        private Size buttonSize;
        private Size textboxSize;
        private Point SignUpLocation;
        private TextBox login;
        private TextBox password;
        private TextBox repitePassword;
        private Form myForm;
        Password passwordInstance;
        Login loginInstance;
        UserController controller;
        string initialLoginText;
        string initialPasswordText;
        string initialRepitePasswordText;
        NavigationManager navigationManager;
        public SignUpProcess(Form form, NavigationManager navigation)
        {
            this.myForm = form;
            this.navigationManager = navigation;
        }
        private void Initialize()
        {
            initialLoginText = "Input Email";
            initialPasswordText = "Create Password";
            initialRepitePasswordText = "Repite your Password";
            buttonSize = new Size(70, 20);
            textboxSize = new Size(200, 30);

            login = new TextBox();
            login.Location = new Point(myForm.Width / 2 - textboxSize.Width / 2, myForm.Height / 2 - 60);
            login.Size = textboxSize;
            login.Visible = true;


            password = new TextBox();
            password.Location = new Point(login.Location.X, login.Location.Y + 50);
            password.Size = textboxSize;
            password.Visible = true;

            repitePassword= new TextBox();
            repitePassword.Location = new Point(password.Location.X, password.Location.Y + 50);
            repitePassword.Size = textboxSize;
            repitePassword.Visible = true;

            loginInstance = new Login();
            loginInstance.InitializeSignUpLogin(myForm, login, initialLoginText);

            passwordInstance = new Password();
            passwordInstance.initializeForSignUp(myForm, password,repitePassword, initialPasswordText);

            SignUpLocation = new Point(myForm.Width / 2 - buttonSize.Width / 2, repitePassword.Location.Y + 2 * repitePassword.Height + 40);

            SignUp = new Button();
            SignUp.Text = "Sign Up";
            SignUp.TextAlign = ContentAlignment.MiddleCenter;
            SignUp.Location = SignUpLocation;
            SignUp.Size = buttonSize;
            SignUp.Click += SignUp_Click;

            myForm.Controls.Add(login);
            myForm.Controls.Add(password);
            myForm.Controls.Add(repitePassword);
            myForm.Controls.Add(SignUp);
        }

        private void SignUp_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void DeinitializePage()
        {
            throw new NotImplementedException();
        }

        public override void InitializePage()
        {
            Initialize();
        }
        private bool isLoginOk(string login)
        {
            return true;   
        }
        private bool isPasswordOk(string password)
        { 
            return true; 
        }
        private bool isRepitedPasswordOk(string repitedPassword)
        {
            return true;
        }


    }
}
