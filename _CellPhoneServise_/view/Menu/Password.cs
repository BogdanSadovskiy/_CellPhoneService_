using _CellPhoneService_.view.Service;

namespace _CellPhoneService_.view.Menu
{
    public class Password
    {
        TextBox? password;
        Form? myForm;
        Button? visability;
        bool visabilityCheck;
        private string passwordInitialText;

        TextBox? repeatedPassword;
        Label? passwordStrength;
 
   
        public void initializeForSignIn(Form myForm, TextBox password)
        {
            passwordInitialText = "Input Password";
            this.myForm = myForm;
            visabilityCheck = false;
            visability = new Button();
            visability.Location = new Point(password.Location.X + password.Width + 20,
                password.Location.Y);
            visability.Click += Visability_Click;
            visability.Size = new Size(password.Size.Height, password.Size.Height);
            visability.Visible = true;
            this.myForm.Controls.Add(visability);

            password.Text = passwordInitialText;
            password.Click += Password_Click;
            password.Leave += Password_Leave;
            password.TextChanged += Password_TextChanged;
        }

        public void initializeForSignUp(Form myForm, TextBox password, TextBox repeatedPassword)
        {
            initializeForSignIn(myForm, password);
            this.repeatedPassword = repeatedPassword;
            passwordStrength = new Label();
            passwordStrength.Location = new Point(repeatedPassword.Location.X + repeatedPassword.)
        }

        private void Password_TextChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Password_Leave(object? sender, EventArgs e)
        {
            password.TextChanged -= Password_TextChanged;
            if (password.Text == "")
                password.Text = passwordInitialText;
            password.TextChanged += Password_TextChanged;
        }


        private void Password_Click(object? sender, EventArgs e)
        {
            password.TextChanged -= Password_TextChanged;
            if (password.Text == passwordInitialText)
                password.Text = "";
            password.TextChanged += Password_TextChanged;
        }



        public void deinitializeSignin()
        {
            myForm.Controls.Remove(visability);
        }
        private void Visability_Click(object? sender, EventArgs e)
        {
            password.UseSystemPasswordChar = !visabilityCheck;
            visabilityCheck = !visabilityCheck;
        }




    }
}
