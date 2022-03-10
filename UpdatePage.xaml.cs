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
    public partial class UpdatePage : ContentPage
    {
        MyCompTabel myComp; string size;
        public UpdatePage()
        {
            InitializeComponent();
            Update.IsEnabled = false;
            Delete.IsEnabled = false;

            Back.Clicked += (s, e) => Navigation.PushAsync(new MainPage());
        }
        private async void Get_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Name.Text)){

                myComp = await App.MyCompSQLite.GetCompAsync(Name.Text);

                MyCountry.ItemsSource = await App.MyCompSQLite.GetAllCountryAsync(); ;

                if (myComp != null)
                {
                    //Id.Text = Int32.Parse(myComp.Id) + "";
                    Name.Text = myComp.Name;
                    SComp1.IsChecked = myComp.CompSize == "Small"?true:false;
                    MComp1.IsChecked = myComp.CompSize == "Medium" ? true : false;
                    LComp1.IsChecked = myComp.CompSize == "Large" ? true : false;
                    Online1.IsToggled = myComp.Online;
                    Update.IsEnabled = true;
                    Delete.IsEnabled = true;
                }
                else
                    await DisplayAlert("Null", "Table is Null", "Ok");
            }
            else
                await DisplayAlert("Error", "Name is empty", "Ok");
        }

        private async void Update_Clicked(object sender, EventArgs e)
        {

            if (this.myComp != null)
            {
                myComp.CompSize = this.size;
                myComp.Online = Online1.IsToggled ? true : false;
                myComp.Country = ((Countries)MyCountry.SelectedItem).CountryName;

                await App.MyCompSQLite.SaveCompAsync(myComp);
                await DisplayAlert("Update", "Name is updated", "Ok");
            }
            else
                await DisplayAlert("Delete", "Table is null", "Ok");

        }


        private async void Delete_Clicked(object sender, EventArgs e)
        {
            if (this.myComp != null)
            {
                await App.MyCompSQLite.DeleteAddressAsync(this.myComp);
                await DisplayAlert("Delete", "Table is deleted", "Ok");
                Name.Text = "";
                SComp1.IsChecked = false;
                MComp1.IsChecked = false;
                LComp1.IsChecked = false;
                Online1.IsToggled = false;

                Update.IsEnabled = false;
                Delete.IsEnabled = false;
            }
            else
                await DisplayAlert("Delete", "Table is null", "Ok");

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
    }
}