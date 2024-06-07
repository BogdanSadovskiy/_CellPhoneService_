using _CellPhoneService_.view.Navigation;

namespace _CellPhoneService_.view.Menu
{
    public class FirstPage : Page
    {
        public FirstPage(Form myForm)
        {
            this.myForm = myForm;
        }

        public override void DeinitializePage()
        {
            myForm.Controls.Remove(SignUp);
            myForm.Controls.Remove(SignIn);
        }

        private Button? SignIn;
        private Button? SignUp;
        private Form myForm;
        private Size buttonSize;
        private Point SignInStartLocation;
        private Point SignInEndLocation;
        private Point SignUpStartLocation;
        private Point SignUpEndLocation;


        public void InitializeElements()
        {
            this.priviesPage = null;
            buttonSize = new Size(70, 20);

            SignInStartLocation = new Point(myForm.Width / 2 - buttonSize.Width / 2, myForm.Height / 2 - 40);
            SignInEndLocation = new Point(SignInStartLocation.X, SignInStartLocation.Y + myForm.Height / 4 + 20);

            SignUpStartLocation = new Point(SignInStartLocation.X, SignInStartLocation.Y + 70);
            SignUpEndLocation = SignInEndLocation;



            SignIn = new Button();
            SignIn.Text = "Sign In";
            SignIn.TextAlign = ContentAlignment.MiddleCenter;
            SignIn.Location = SignInStartLocation;
            SignIn.Size = buttonSize;
            SignIn.Click += SignIn_Click;
            SignIn.Visible = true;

            SignUp = new Button();
            SignUp.Text = "Sign Up";
            SignUp.TextAlign = ContentAlignment.MiddleCenter;
            SignUp.Location = SignUpStartLocation;
            SignUp.Size = buttonSize;
            SignUp.Click += SignUp_Click;
            SignUp.Visible = true;


            myForm.Controls.Add(SignIn);
            myForm.Controls.Add(SignUp);

        }

        private void SignUp_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        private void SignIn_Click(object? sender, EventArgs e)
        {
            DeinitializePage();
            this.navigationManager.InitializeNextPage(new SignInProcess(myForm, this, navigationManager));
        }

        public override void InitializePage()
        {
            InitializeElements();
        }
    }
}
