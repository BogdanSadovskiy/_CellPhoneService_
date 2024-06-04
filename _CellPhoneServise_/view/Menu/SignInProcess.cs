using _CellPhoneService_.view.Service;

namespace _CellPhoneService_.view.Menu
{
    public class SignInProcess
    {
        private Button SignIn;
        private Size buttonSize;
        private Point SignInLocation;
        private TextBox login;
        private TextBox password;
        private Form myForm;
        private Size textboxSize;
        private MenuExplorer backButton;

        private string loginInitialText;
        Password passwordInstance;
        public void InitializeElements(Form myForm, MenuExplorer backButton)
        {
 
            loginInitialText = "Input Login";

            this.myForm = myForm;
            this.backButton = backButton;
            backButton.status = BackStatus._SignInPage;
            backButton.BackButton.Visible = true;

            buttonSize = new Size(70, 20);
            textboxSize = new Size(200, 30);

            SignInLocation = new Point(myForm.Width / 2 - buttonSize.Width / 2 + myForm.Height / 2 + myForm.Height / 4 + 20);

            login = new TextBox();
            login.Location = new Point(myForm.Width / 2 - textboxSize.Width / 2, myForm.Height / 2 - 60);
            login.Size = textboxSize;
            login.Visible = true;
            login.Text = loginInitialText;

            password = new TextBox();
            password.Location = new Point(login.Location.X, login.Location.Y + 50);
            password.Size = textboxSize;
            password.Visible = true;
           

            passwordInstance = new Password();
            passwordInstance.initializeForSignIn(myForm, password);

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

        public void deinitialize()
        {
            passwordInstance.deinitializeSignin();
            myForm.Controls.Remove(login);
            myForm.Controls.Remove(password);
            myForm.Controls.Remove(SignIn);
        }

        private bool isLoginOk(string login)
        {
            return ViewCheck.isLoginOk( login);
        }

        private void SignIn_Click(object? sender, EventArgs e)
        {

        }


    }
}
