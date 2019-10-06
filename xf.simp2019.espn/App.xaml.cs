using Xamarin.Forms;
using xf.simp2019.espn.Views;

namespace xf.simp2019.espn
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ListArticlesPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}