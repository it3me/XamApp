using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using XamApp.Models;
using Xamarin.Forms;

namespace XamApp.ViewModels
{
    public class GridViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ProductRepository productRepository;
        public ObservableCollection<Product> pagingProducts { get; set; }

        public GridViewModel()
        {
            productRepository = new ProductRepository();
            pagingProducts = new ObservableCollection<Product>();
        }

        private void GenerateSource()
        {
            var index = 0;
            Assembly assembly = typeof(XamApp.Views.GridView).GetTypeInfo().Assembly;
            for (int i = 0; i < productRepository.Names.Count(); i++)
            {
                if (index == 21)
                    index = 0;

                var name = productRepository.Names[index];
                var p = new Product()
                {
                    Name = productRepository.Names[i],                   
                    Price = productRepository.Price[i], 
                    Image = ImageSource.FromResource("XamApp.Images." + name.Replace(" ", string.Empty) + ".jpg", assembly)
                };

                index++;
                pagingProducts.Add(p);
            }
        }

    }
}
