
using _CellPhoneService_.view.Menu;
using _CellPhoneService_.view.Navigation;
namespace _CellPhoneServise_
{
    public partial class RepairDeviceApp : Form
    {

        public RepairDeviceApp()
        {
            InitializeComponent();
            Page start = new FirstPage(this);
            NavigationManager navigation = new NavigationManager(start);
            navigation.InitializeBackButton(this);
        }
    }
}
