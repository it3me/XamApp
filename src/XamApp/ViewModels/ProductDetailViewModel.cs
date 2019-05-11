using Bit.ViewModel;
using Prism.Navigation;
using System.Threading.Tasks;
using XamApp.Models;

namespace XamApp.ViewModels
{

    public class ProductDetailViewModel : BitViewModelBase
    {
        public BitDelegateCommand ChangeProductIsActiveCommand { get; set; }

        public Product Product { get; set; }

        public ProductDetailViewModel()
        {
            ChangeProductIsActiveCommand = new BitDelegateCommand(ChangeProductIsActive);
        }

        async Task ChangeProductIsActive()
        {
           // Product.IsActive = !Product.IsActive;
        }

        public async override Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            await base.OnNavigatedToAsync(parameters);

            Product = parameters.GetValue<Product>("product");
        }
    }
}
