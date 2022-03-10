using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestCheckBox
{
    public partial class MainPage : ContentPage
    {
        string county, city, size;
        public MainPage()
        {
            InitializeComponent();

            Update.Clicked += (s, e) => Navigation.PushAsync(new UpdatePage());
            Show.Clicked += (s, e) => Navigation.PushAsync(new ShowPage());
            Show2.Clicked += (s, e) => Navigation.PushAsync(new Show2ListViewPage());
            AddCountry.Clicked += (s, e) => Navigation.PushAsync(new AddCountryPage());
            AddCity.Clicked += (s, e) => Navigation.PushAsync(new AddCityPage());
           
        }
        private async void Create_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Name.Text))
            {              
                var myComp = await App.MyCompSQLite.GetCompAsync(Name.Text);

                if (myComp == null)
                {
                    var comp = new MyCompTabel()
                    {
                        Name = Name.Text,
                        CompSize = this.size,
                        //MComp = MComp1.IsChecked,
                        //LComp = LComp1.IsChecked,
                        Online = Online1.IsToggled ? true : false,
                        Country = this.county,
                        City = this.city,
                    };
                    await App.MyCompSQLite.SaveCompAsync(comp);
                    await DisplayAlert("Added", "Name is Added", "Ok");

                    Name.Text = "";
                    SComp1.IsChecked = false;
                    MComp1.IsChecked = false;
                    LComp1.IsChecked = false;
                }
                else
                    await DisplayAlert("Duplicate", "Name is Found", "Ok");
            }
            else
                await DisplayAlert("Error", "Name is empty", "Ok");
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Name.Focus();
            MyCountry.ItemsSource = await App.MyCompSQLite.GetAllCountryAsync();
        }

        private async void MyCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.county = MyCountry.Items[MyCountry.SelectedIndex];
            MyCity.ItemsSource = await App.MyCompSQLite.GetAllCityAsync(this.county);
        }

        private void SComp1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            MComp1.IsChecked = false;
            LComp1.IsChecked = false;

            this.size = "Small";
        }

        private void LComp1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            SComp1.IsChecked = false;
            MComp1.IsChecked = false;
            this.size = "Medium";
        }

        private void MComp1_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            SComp1.IsChecked = false;
            LComp1.IsChecked = false;
            this.size = "Large";
        }

        private void MyCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.city = MyCity.Items[MyCity.SelectedIndex];
        }
    }
}
