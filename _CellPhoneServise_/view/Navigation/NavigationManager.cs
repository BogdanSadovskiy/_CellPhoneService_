namespace _CellPhoneService_.view.Navigation
{
    public class NavigationManager
    {
        public Page firstPage { get; set; }
        public Page currentPage { get; set; }
        Form form { get; set; }
        Button back { get; set; }
        public void InitalizePriviesPage()
        {
            if (currentPage.priviesPage != null)
            {
                currentPage.DeinitializePage();
               currentPage.priviesPage.InitializePage();
               this.currentPage = currentPage.priviesPage;
            }
        }
        public void InitializeNextPage(Page page)
        {
            page.InitializePage();
            page.priviesPage = currentPage;
            currentPage = page;
            back.Visible = true;
        }
        public void InitializeBackButton(Form form)
        {
            this.form = form;
            back = new Button();
            back.Location = new Point(50, 50);
            back.Text = "Back";
            back.TextAlign = ContentAlignment.MiddleCenter;
            back.Size = new Size(20, 20);
            back.Visible = false;
            back.Click += Back_Click;
            this.form.Controls.Add(back);
        }

        private void Back_Click(object? sender, EventArgs e)
        {
            InitalizePriviesPage();
            if (currentPage.priviesPage == null)
                back.Visible = false;   
        }

        public NavigationManager(Page firstPage)
        {
            this.firstPage = firstPage;
            currentPage = firstPage;
            firstPage.priviesPage = null;
            currentPage.navigationManager = this;
            currentPage.InitializePage();
        }
    }
}
