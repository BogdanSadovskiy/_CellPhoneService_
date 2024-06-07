namespace _CellPhoneService_.view.Menu
{
    public class Password
    {
        TextBox? password;
        Form? myForm;
        Button? visability;
        private string passwordInitialText;

        TextBox? repeatedPassword;
        Label? passwordStrength;
        private bool isSignUp;
   
        public void initializeForSignIn(Form myForm, TextBox password_)
        {
            passwordInitialText = "Input Password";
            password = password_;
            password.Text = passwordInitialText;
            password.Click += Password_Click;
            password.Leave += Password_Leave;
            
            isSignUp = false;

            this.myForm = myForm;
            visability = new Button();
            visability.Location = new Point(password.Location.X + password.Width + 20,
                password.Location.Y);
            visability.MouseDown += Visability_MouseDown;
            visability.MouseUp += Visability_MouseUp;
            visability.Size = new Size(password.Size.Height, password.Size.Height);
            visability.Visible = true;

            this.myForm.Controls.Add(visability);
 
        }

       

        public void initializeForSignUp(Form myForm, TextBox password, TextBox repeatedPassword)
        {
            initializeForSignIn(myForm, password);
            isSignUp = true;
            this.repeatedPassword = repeatedPassword;
            passwordStrength = new Label();
            passwordStrength.Location = new Point(this.password.Location.X, password.Location.Y + password.Height + 10);
            password.TextChanged += Password_TextChanged;
        }

        private void closeTextChanged()
        {
            if (isSignUp) { password.TextChanged -= Password_TextChanged; }
        }

        private void openTextChanged()
        {
            if (isSignUp) { password.TextChanged += Password_TextChanged; }
        }

        private void Password_TextChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Password_Leave(object? sender, EventArgs e)
        {
            closeTextChanged();
            if (password.Text == "")
            {
                password.UseSystemPasswordChar = false;
                password.Text = passwordInitialText;
            }
            openTextChanged();
        }


        private void Password_Click(object? sender, EventArgs e)
        {
            closeTextChanged();
            if (password.Text == passwordInitialText)
                password.Text = "";
            password.UseSystemPasswordChar = true;
            openTextChanged();
        }



        public void deinitializeSignin()
        {
            myForm.Controls.Remove(visability);
        }
        private void Visability_MouseDown(object? sender, EventArgs e)
        {
            if(password.Text == passwordInitialText)
            {
                password.UseSystemPasswordChar=false;
                return;
            }
            password.UseSystemPasswordChar = false;

        }

        private void Visability_MouseUp(object? sender, MouseEventArgs e)
        {
            if (password.Text == passwordInitialText)
            {
                password.UseSystemPasswordChar = false;
                return;
            }
            password.UseSystemPasswordChar = true;

        }



    }
}
