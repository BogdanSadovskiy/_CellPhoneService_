namespace _CellPhoneService_.view.Menu
{
    public class FirstPage
    {
        public FirstPage(Form myForm)
        {
            this.myForm = myForm;
            InitializeElements();
            startFirstPage();
        }
        public SignInProcess? signInProcess {  get; set; }
        
        private BackButton? backButton;
        private Button? SignIn;
        private Button? SignUp;
        private Form myForm;
        private Size buttonSize;
        private Point SignInStartLocation;
        private Point SignInEndLocation;
        private Point SignUpStartLocation;
        private Point SignUpEndLocation;


        private void InitializeElements()
        {
            buttonSize = new Size(70, 20);

            SignInStartLocation = new Point(myForm.Width / 2 - buttonSize.Width / 2, myForm.Height / 2 - 40);
            SignInEndLocation = new Point(SignInStartLocation.X, SignInStartLocation.Y + myForm.Height / 4 + 20);

            SignUpStartLocation = new Point(SignInStartLocation.X, SignInStartLocation.Y + 70);
            SignUpEndLocation = SignInEndLocation;

            Button back = new Button();
            back.Location = new Point(myForm.Size.Width - 50, 50);

            backButton = new BackButton(back, BackStatus._FirstPage, this);

            SignIn = new Button();
            SignIn.Text = "Sign In";
            SignIn.TextAlign = ContentAlignment.MiddleCenter;
            SignIn.Location = SignInStartLocation;
            SignIn.Size = buttonSize;
            SignIn.Click += SignIn_Click;

            SignUp = new Button();
            SignUp.Text = "Sign Up";
            SignUp.TextAlign = ContentAlignment.MiddleCenter;
            SignUp.Location = SignUpStartLocation;
            SignUp.Size = buttonSize;
            SignUp.Click += SignUp_Click;


            myForm.Controls.Add(SignIn);
            myForm.Controls.Add(SignUp);
            myForm.Controls.Add(back);

        }

        private void SignUp_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        private void SignIn_Click(object? sender, EventArgs e)
        {
            SignUp.Visible = false;
            SignIn.Location = SignInEndLocation;
            signInProcess = new SignInProcess(myForm, backButton);
        }

        public void startFirstPage()
        {
            SignIn.Location = SignInStartLocation;
            SignUp.Location = SignUpStartLocation;
            SignIn.Visible = true;
            SignUp.Visible = true;
            backButton.Back.Visible = false;
        }
    }
}
