using Acr.UserDialogs;
using Bit.ViewModel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamApp.ViewModels
{
    public class MelkradarViewMode : BitViewModelBase
    {
        public string Digit { get; set; }
        public string FirstDigit { get; set; }
        public string SecondDigit { get; set; }
        public string ThirdDigit { get; set; }
        public string FourthDigit { get; set; }

        public BitDelegateCommand ConfirmCommand { get; set; }
        //public BitDelegateCommand EditEntryCommand { get; set; }


        public IUserDialogs UserDialogs { get; set; }
        public MelkradarViewMode()
        {
            ConfirmCommand = new BitDelegateCommand(Confirmation);
            //EditEntryCommand = new BitDelegateCommand(EditEntryText);
        }
        public async Task Confirmation()
        {           
            await NavigationService.NavigateAsync("ServiceItems");
        }
        
        

        

    }
}

