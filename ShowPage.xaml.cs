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
    public partial class ShowPage : ContentPage
    {
        public ShowPage()
        {
            InitializeComponent();
                       
            Home.Clicked += (s, e) => Navigation.PushAsync(new MainPage());
            Close.Clicked += (s, e) => Environment.Exit(0);
        }
        private async void Show_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Name.Text))
            {

                var myComp = await App.MyCompSQLite.GetCompAsync(Name.Text);
                if (myComp != null)
                {
                    //Id.Text = Int32.Parse(myComp.Id) + "";
                    Name.Text = myComp.Name ;
                    CompSize1.Text = myComp.CompSize;
                    //MComp1.Text = myComp.MComp ? "MComp" : "";
                    //LComp1.Text = myComp.LComp ? "LComp" : "";
                    Online1.Text = myComp.Online + "";
                    Country1.Text = myComp.Country;
                    City1.Text = myComp.City;

                }
                else
                    await DisplayAlert("Null", "Table is Null", "Ok");
            }
            else
                await DisplayAlert("Error", "Name is empty", "Ok");
        }      
    }
}