using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _CellPhoneService_.view.Menu
{
    public class Password
    {
        TextBox password;
        string tmpPass;
        Form myForm;
        Button visability;
        bool visabilityCheck;
        public void initialize(Form myForm,TextBox password)
        {
            this.myForm = myForm;
            tmpPass = "";
            visabilityCheck = false;
            visability = new Button();
            visability.Location = new Point(password.Location.X + password.Width +20, 
                password.Location.Y);
            visability.Click += Visability_Click;
            visability.Size = new Size(password.Size.Height, password.Size.Height);
            visability.Visible = true;
            this.myForm.Controls.Add(visability);

        }

        public void deinitialize()
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
