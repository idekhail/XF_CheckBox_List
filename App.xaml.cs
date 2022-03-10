using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestCheckBox
{
    public partial class App : Application
    {
        static MyCompOperation db;

        // Create the database connection as a singleton.
        public static MyCompOperation MyCompSQLite
        {
            get
            {
                if (db == null)
                {
                    db = new MyCompOperation(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyCompDB.db3"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
