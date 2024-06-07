using _CellPhoneService_.view.Service;
namespace _CellPhoneService_.view.Menu
{
    public class Login
    {
        Form myForm;
        TextBox login;
        Label message;
        string initialText;
        bool isSingUp;
        public void InitializeSignInLogin(Form form, TextBox login)
        {
            initialText = "Input Email";
            myForm = form;
            this.login = login;
            message = new Label();
            message.AutoSize = false;
            message.Size = login.Size;
            message.Location = new Point(login.Location.X, login.Location.Y + login.Height + 10);
            login.Text = initialText;
            login.Click += Login_Click;
            login.Leave += Login_Leave;
            isSingUp = false;

        }

        public void InitializeSignUpLogin(Form form, TextBox login)
        {
            InitializeSignInLogin(form, login);
            login.TextChanged += Login_TextChanged;
            isSingUp = true;
        }
        private void closeTextChanged()
        {
            if (isSingUp) { login.TextChanged -= Login_TextChanged; }
        }

        private void openTextChanged()
        {
            if (isSingUp) { login.TextChanged += Login_TextChanged; }
        }

        private void Login_TextChanged(object? sender, EventArgs e)
        {
            if (isSingUp)
            {
                if (!ViewCheck.isLoginOk(login.Text))
                    login.ForeColor = Colors.ErrorColor();
                else login.ForeColor = Colors.initiateColor();
            }
        }

        private void Login_Leave(object? sender, EventArgs e)
        {
            closeTextChanged();
            if (login.Text == "")
                login.Text = initialText;
            openTextChanged();
        }

        private void Login_Click(object? sender, EventArgs e)
        {
            closeTextChanged();
            if (login.Text == initialText)
                login.Text = "";
            openTextChanged();
        }

        public void DeinitializeSignIn()
        {
            myForm.Controls.Remove(login);
        }
    }
}
