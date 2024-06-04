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
    public class MenuExplorer
    {
        public Button BackButton {  get; set; }
        public BackStatus status {  get; set; }
        private FirstPage page;

        public MenuExplorer(Button back, BackStatus status, FirstPage page)
        {
            BackButton = back;
            BackButton.Text = "Back";
            BackButton.TextAlign = ContentAlignment.MiddleCenter;
            BackButton.Size = new Size(20, 20);
            BackButton.Click += Back_Click;
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
