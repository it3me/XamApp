using Bit.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XamApp.ViewModels
{
    public class GridLayoutViewModel : BitViewModelBase
    {
        public BitDelegateCommand OpenFlexLayoutPageCommand { get; set; }
        public BitDelegateCommand OpenStackLayoutPageCommand { get; set; }

        public GridLayoutViewModel()
        {
            OpenFlexLayoutPageCommand = new BitDelegateCommand(FlexLayoutPage);
            OpenStackLayoutPageCommand = new BitDelegateCommand(StackLayoutPage);
        }

        public async Task FlexLayoutPage()
        {
            await NavigationService.NavigateAsync("FlexLayout");
        }

        public async Task StackLayoutPage()
        {
            await NavigationService.NavigateAsync("StackLayout");
        }
    }
}
