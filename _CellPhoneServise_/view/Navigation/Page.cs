namespace _CellPhoneService_.view.Navigation
{
    public abstract class Page
    {

        public  Page priviesPage { get; set; }

        public abstract void InitializePage();

        public NavigationManager navigationManager { get; set; }
        public abstract void DeinitializePage();
    }
}
