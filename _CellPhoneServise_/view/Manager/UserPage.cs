using _CellPhoneService_.Entity;
using _CellPhoneService_.view.Navigation;
using System.Reflection.Metadata.Ecma335;
using Timer = System.Windows.Forms.Timer;


namespace _CellPhoneService_.view.Manager
{
    public class UserPage : Page
    {
        Anketa anketa;
        bool startAnketa;
        User_ user;
        Form form;
        Timer isAnketaDoneTimer;
        public UserPage(Form form, User_ user)
        {
            this.user = user;
            this.form = form;

        }
        public override void InitializePage()
        {
            startAnketa = false;

            isAnketaDoneTimer = new Timer();
            isAnketaDoneTimer.Interval = 150;
            isAnketaDoneTimer.Tick += IsAnketaDoneTimer_Tick;
            isAnketaDoneTimer.Start();
        }
        private void IsAnketaDoneTimer_Tick(object? sender, EventArgs e)
        {
            if (!isAnketaDone(user))
            {
                if (!startAnketa)
                {
                    anketa = new Anketa(form, user);
                    anketa.InitializePage();
                }
            }
            isAnketaDoneTimer.Stop();
            
        }

        private bool isAnketaDone(User_ user)
        {
            return Anketa.isAnketaDone(user.FirstName, user.LastName, user.Phone_number);
        }
        public override void DeinitializePage()
        {
            throw new NotImplementedException();
        }

      


    }
}
