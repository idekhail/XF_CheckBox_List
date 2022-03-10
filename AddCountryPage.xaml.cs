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
    public partial class AddCountryPage : ContentPage
    {
        public AddCountryPage()
        {
            InitializeComponent();
            Home.Clicked += (s, e) => Navigation.PushAsync(new MainPage());

        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Name.Text))
            {
                var country = await App.MyCompSQLite.GetCountryAsync(Name.Text);

                if (country == null)
                {
                    country = new Countries()
                    {
                        CountryName = Name.Text,
                        CountryCode = Code.Text,
                    };
                    await App.MyCompSQLite.SaveCountryAsync(country);

                    await DisplayAlert("Add", "Country is Added", "Ok");

                    Name.Text = "";
                    Code.Text = "";
                }
                else
                    await DisplayAlert("Duplicate", "Country Name is Found", "Ok");
            }
            else
                await DisplayAlert("Error", "Country Name is empty", "Ok");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Name.Focus();
        }
    }
}