using _CellPhoneService_.Controller;
using _CellPhoneService_.Entity;
using _CellPhoneService_.view.Navigation;
using _CellPhoneService_.view.Service;
namespace _CellPhoneService_.view.Manager
{
    public class Anketa : Page
    {
        Label title;
        private Form form;
        private User_ user_;
        TextBox firstName;
        TextBox lastName;
        TextBox phone;
        Label error;
        Button submit;
        string initialFirstNameText;
        string initialLastNameText;
        string initialPhoneText;
        UserController userController;
        public override void DeinitializePage()
        {
            form.Controls.Remove(firstName);
            form.Controls.Add(lastName);
            form.Controls.Add(phone);
            form.Controls.Add(error);
            form.Controls.Add(submit);
        }

        public override void InitializePage()
        {
            title = new Label();
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Size = new Size(300, 60);
            title.Location = new Point(form.Width / 2 - title.Width / 2, 30);
            title.Text = "Input Your date";
            title.Font = new Font("Arial", 12);

            firstName = new TextBox();
            firstName.Size = Sizes.textBoxSize();
            firstName.Location = new Point(form.Width/2 - firstName.Width/2, form.Height/3);
            firstName.Text = initialFirstNameText;

            lastName = new TextBox();
            lastName.Size = Sizes.textBoxSize();
            lastName.Location = new Point(firstName.Location.X, firstName.Location.Y + 20);
            lastName.Text = initialLastNameText;

            phone = new TextBox();
            phone.Size = Sizes.textBoxSize();
            phone.Location = new Point(firstName.Location.X, lastName.Location.Y + 20);
            phone.Text = initialLastNameText;

            error = new Label();
            error.Size = phone.Size;
            error.AutoSize = false;
            error.Location = new Point(firstName.Location.Y, phone.Location.Y + 20);
            error.Visible = false;

            submit = new Button();
            submit.Size = Sizes.mainButtonSize();
            submit.Location = new Point(form.Width / 2 - submit.Width / 2, phone.Location.Y + 20);
            submit.Click += Submit_Click;

            form.Controls.Add(firstName);
            form.Controls.Add(lastName);
            form.Controls.Add(phone);
            form.Controls.Add(error);
            form.Controls.Add(submit);

            userController = new UserController();
        }

        private void Submit_Click(object? sender, EventArgs e)
        {
            if (!isAnketaDone(firstName.Text, lastName.Text, phone.Text))
            {
                error.Visible = true;
                error.ForeColor = Colors.ErrorColor();
                error.Text = "Fill all fields";
            }
            updateUser();
        }

        public Anketa(Form form, User_ user)
        {
            this.form = form;
            this.user_ = user;
        }
        public static bool isFirstNameDone(string firstName)
        {
            return !string.IsNullOrEmpty(firstName);
        }

        public static bool isLastNameDone(string lastName)
        {
            return !string.IsNullOrEmpty(lastName);
        }

        public static bool isPhoneDone(string phone)
        {
            return !string.IsNullOrEmpty(phone);
        }

        public static bool isAnketaDone(string firstName, string lastName, string phone)
        {
            return isFirstNameDone(firstName) && isLastNameDone(lastName) && isPhoneDone(phone);
        }

        private void updateUser()
        {
            userController.updateUserFirstName(user_.Id, firstName.Text);
            userController.updateUserLastName(user_.Id, lastName.Text);
            userController.updateUserPhone(user_.Id, phone.Text);
            user_ = userController.getUserById(user_.Id);
        }
    }
}
