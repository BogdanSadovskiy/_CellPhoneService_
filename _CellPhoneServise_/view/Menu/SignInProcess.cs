using _CellPhoneService_.Controller;
using _CellPhoneService_.Entity;
using _CellPhoneService_.view.Navigation;
using _CellPhoneService_.view.Service;

namespace _CellPhoneService_.view.Menu
{
    public class SignInProcess : Page
    {
        private Button SignIn;
        private Size buttonSize;
        private Point SignInLocation;
        private TextBox login;
        private TextBox password;
        private Form myForm;
        private Size textboxSize;
        Password passwordInstance;
        Login loginInstance;
        UserController controller;
        string initialLoginText;
        string initialPasswordText;

        Label label = new Label();
        public SignInProcess(Form myForm, Page priviesPage, NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
            this.priviesPage = priviesPage;
            this.myForm = myForm;
        }
        private void InitializeElements()
        {
            label.AutoSize = true;
            label.Location = new Point(300, 300);
            label.Visible = false;
            myForm.Controls.Add(label); 

            controller = new UserController();
            initialLoginText = "Input Email";
            initialPasswordText = "Input Password";

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
           
            loginInstance = new Login();
            loginInstance.InitializeSignInLogin(myForm, login, initialLoginText);

            passwordInstance = new Password();
            passwordInstance.initializeForSignIn(myForm, password, initialPasswordText);

            SignInLocation = new Point(myForm.Width / 2 - buttonSize.Width / 2, password.Location.Y + 2 * password.Height + 40);

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


        public override void DeinitializePage()
        {
            loginInstance.DeinitializeSignIn();
            passwordInstance.deinitializeSignin();
            myForm.Controls.Remove(login);
            myForm.Controls.Remove(password);
            myForm.Controls.Remove(SignIn);
        }

        private void SignIn_Click(object? sender, EventArgs e)
        {
            if (!isLoginOk(login.Text) || !isPasswordOk(password.Text)) { return; }
            Instance<User_> user = controller.loginUser(login.Text, password.Text);
            label.Visible = true;
            if (user.obj == null) 
            {
                label.Text = user.getMessageStr();
                return;
            }
            label.Text = user.obj.FirstName;
        }

        public override void InitializePage()
        {
            InitializeElements();
        }
        private bool isLoginOk(string login)
        {
            return login != "" && login != initialLoginText;
        }

        private bool isPasswordOk(string password)
        {
            return password != "" && password != initialPasswordText;
        }
    }
}
