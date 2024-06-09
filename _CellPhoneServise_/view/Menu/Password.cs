using _CellPhoneService_.view.Regex;
using _CellPhoneService_.view.Service;

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
        Label? repitedPasswordIndicator;
        private bool isSignUp;
        string initialRepitedPassText;
   
        public void initializeForSignIn(Form myForm, TextBox password_, string initialText)
        {
            passwordInitialText = initialText;
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

       

        public void initializeForSignUp(Form myForm, TextBox password, TextBox repeatedPassword, string initialText)
        {
            initializeForSignIn(myForm, password, initialText);
            //initialRepitedPassText = "Repeat password";
            isSignUp = true;
            this.repeatedPassword = repeatedPassword;
            repeatedPassword.UseSystemPasswordChar = true;  
            repeatedPassword.TextChanged += RepeatedPassword_TextChanged;

            passwordStrength = new Label();
            passwordStrength.Size = password.Size;
            passwordStrength.Location = new Point(this.password.Location.X, password.Location.Y + password.Height);
            passwordStrength.Visible = false;

            repitedPasswordIndicator = new Label();
            repitedPasswordIndicator.Size = repeatedPassword.Size;
            repitedPasswordIndicator.Location = new Point(this.repeatedPassword.Location.X, repeatedPassword.Height);
            repitedPasswordIndicator.Visible = false;
            

            password.TextChanged += Password_TextChanged;
            myForm.Controls.Add(passwordStrength);  
        }

        private void RepeatedPassword_TextChanged(object? sender, EventArgs e)
        {
            repitedPasswordIndicator.Visible = true;
            if (repeatedPassword.Text != password.Text) {
                repitedPasswordIndicator.ForeColor = Colors.ErrorColor();
                repitedPasswordIndicator.Text = "Not Correct";
                return;
            }
            repitedPasswordIndicator.ForeColor = Color.Green;
            repitedPasswordIndicator.Text = "Correct";
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
            passwordStrength.Visible = true;
            if (MyRegex.isPasswordStrong(password.Text))
            {
                passwordStrength.ForeColor = Color.Green;
                passwordStrength.Text = "Strong";
            }
            else if (MyRegex.isPasswordMiddleStrength(password.Text))
            {
                passwordStrength.ForeColor = Color.Orange;
                passwordStrength.Text = "Middle";
            }
            else if (MyRegex.isPasswordWeak(password.Text))
            {
                passwordStrength.ForeColor = Colors.ErrorColor();
                passwordStrength.Text = "Weak";
            }
            else if(password.Text.Length < 4)
            {
                passwordStrength.ForeColor = Colors.ErrorColor();
                passwordStrength.Text = "Not Less 4 symbols";
            }

        }

        private void Password_Leave(object? sender, EventArgs e)
        {
            closeTextChanged();
            if (password.Text == "")
            {
                password.UseSystemPasswordChar = false;
                password.Text = passwordInitialText;
                passwordStrength.Visible = false;
                repitedPasswordIndicator.Visible = false;
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
