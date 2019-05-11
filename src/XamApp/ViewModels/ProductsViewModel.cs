using Acr.UserDialogs;
using Bit.ViewModel;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamApp.Models;
using Syncfusion.ListView.XForms;
using Syncfusion.SfDataGrid.XForms.DataPager;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using Xamarin.Forms;
using XamApp.Views;

namespace XamApp.ViewModels
{
    public class ProductsViewModel : BitViewModelBase
    {
        private ProductRepository pagingProductRepository;
        public ObservableCollection<Product> pagingProducts { get; set; }

        public ProductsViewModel()
        {
           // ShowProductDetailsCommand = new BitDelegateCommand<Product>(ShowProductDetails);
            pagingProductRepository = new ProductRepository();
            pagingProducts = new ObservableCollection<Product>();
            GenerateSource();
        }
        /*SfDataPager sfPager = new SfDataPager();
        SfListView listView = new SfListView();*/

       // public BitDelegateCommand<Product> ShowProductDetailsCommand { get; set; }

        public List<Product> Products { get; set; }
       // public Product SelectedProduct { get; set; }

       /* public async override Task OnNavigatedToAsync(INavigationParameters parameters)
        {
            /*products = new list<product> // getting products from server or sqlite database
            {
                new product { id = 1, isactive = true, name = "product1" , price = 12.2m , note = "sample note for product1" },
                new product { id = 2, isactive = false, name = "product2" , price = 14 , note = "sample note for product2"},
                new product { id = 3, isactive = true, name = "product3" , price = 11 , note = "sample note for product3"},
            };*/
            

        /*    await base.OnNavigatedToAsync(parameters);
        }*/

      /*  async Task ShowProductDetails(Product product)
        {
            await NavigationService.NavigateAsync("ProductDetail", new NavigationParameters
            {
                { "product", product }
            });
        }*/

        private void GenerateSource()
        {
            var index = 0;
            Assembly assembly = typeof(ProductsView).GetTypeInfo().Assembly;
            for (int i = 0; i < pagingProductRepository.Names.Count(); i++)
            {
                if (index == 21)
                    index = 0;

                var name = pagingProductRepository.Names[index];
                var p = new Product()
                {
                    Name = pagingProductRepository.Names[i],                    
                    Image = ImageSource.FromResource("XamApp.Images." + name.Replace(" ", string.Empty) + ".jpg", assembly)
                };

                index++;
                pagingProducts.Add(p);
            }
        }

        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
