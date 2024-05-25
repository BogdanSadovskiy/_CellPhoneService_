using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _CellPhoneService_.view.Menu
{
    public enum BackStatus
    {
        _FirstPage, 
        _SignInPage, 
        _SignUpPage
    }
    public class BackButton
    {
        public Button Back {  get; set; }
        public BackStatus status {  get; set; }
        private FirstPage page;

        public BackButton(Button back, BackStatus status, FirstPage page)
        {
            Back = back;
            Back.Text = "Back";
            Back.TextAlign = ContentAlignment.MiddleCenter;
            Back.Size = new Size(20, 20);
            Back.Click += Back_Click;
            this.status = status;
            this.page = page;
        }

        private void Back_Click(object? sender, EventArgs e)
        {
            if(status == BackStatus._SignInPage)
            {
                page.startFirstPage();
            }
        }
    }
}
