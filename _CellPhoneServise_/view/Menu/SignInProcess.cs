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
        public SignInProcess(Form myForm, Page priviesPage, NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
            this.priviesPage = priviesPage;
            this.myForm = myForm;
        }
        private void InitializeElements()
        {
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
            loginInstance.InitializeSignInLogin(myForm, login);

            passwordInstance = new Password();
            passwordInstance.initializeForSignIn(myForm, password);

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

        }

        public override void InitializePage()
        {
            InitializeElements();
        }
    }
}
