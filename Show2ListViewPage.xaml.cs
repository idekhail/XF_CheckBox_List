using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestCheckBox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Show2ListViewPage : ContentPage
    {
        public Show2ListViewPage()
        {
            InitializeComponent();
        }


        private async void AllComp_Clicked(object sender, EventArgs e)
        {
            var allComp = await App.MyCompSQLite.GetAllCompAsync();
            myList.ItemsSource = allComp;
        }
    }
}