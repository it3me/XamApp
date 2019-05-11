using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MelkradarView : ContentPage
    {
        public Entry previousEntry;
        public MelkradarView()
        {            
            InitializeComponent();            
            FirstDigit.Unfocused += (object sender, FocusEventArgs e) => {
                previousEntry = (Entry)sender;
            };

            SecondDigit.Unfocused += (object sender, FocusEventArgs e) => {
                previousEntry = (Entry)sender;
            };

            ThirdDigit.Unfocused += (object sender, FocusEventArgs e) => {
                previousEntry = (Entry)sender;
            };
            FourthDigit.Unfocused += (object sender, FocusEventArgs e) => {
                previousEntry = (Entry)sender;
            }; 
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
            if (previousEntry != null )
            {
                previousEntry.Text = pressed;
            }            

        }
        void FirstDigit_TextChanged(object sender, EventArgs args)
        {
            if (FirstDigit.Text.Length > 0)
            {
                SecondDigit.Focus();
            }

        }
        void SecondDigit_TextChanged(object sender, EventArgs args)
        {
            if (SecondDigit.Text.Length > 0)
            {
                ThirdDigit.Focus();
            }

        }
        void ThirdDigit_TextChanged(object sender, EventArgs args)
        {
            if (ThirdDigit.Text.Length > 0)
            {
                FourthDigit.Focus();
            }
        }
        private void FourthDigit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FourthDigit.Text.Length > 0)
            {
                previousEntry = null;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FirstDigit.Focus();

            FirstDigit.Text = "";
            SecondDigit.Text = "";
            ThirdDigit.Text = "";
            FourthDigit.Text = "";
            

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}