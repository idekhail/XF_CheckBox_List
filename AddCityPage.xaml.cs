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
    public partial class AddCityPage : ContentPage
    {
        public AddCityPage()
        {
            InitializeComponent();
            Home.Clicked += (s, e) => Navigation.PushAsync(new MainPage());

        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Name.Text))
            {
                var city = await App.MyCompSQLite.GetCityAsync(Name.Text);
                Countries country = await App.MyCompSQLite.GetCountryCodeAsync(CountryCode.Text);

                if (city == null)
                {
                    city = new Cities()
                    {
                        CityName = Name.Text,
                        CountryName = country.CountryName,                     
                    };
                    await App.MyCompSQLite.SaveCityAsync(city);

                    await DisplayAlert("Add", "City is Added", "Ok");

                    Name.Text = "";
                    CountryCode.Text = "";                   
                }
                else
                    await DisplayAlert("Duplicate", "Name is Found", "Ok");
            }
            else
                await DisplayAlert("Error", "Name is empty", "Ok");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Name.Focus();
        }
    }    
}