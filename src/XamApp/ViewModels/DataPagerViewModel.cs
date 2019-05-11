using Bit.ViewModel;
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
    public class DataPagerViewModel : BitViewModelBase
    {
        public ObservableCollection<Product> ProductCollection { get; set; }
        private ProductRepository productRepo;

        public DataPagerViewModel()
        {
            ProductCollection = new ObservableCollection<Product>();
            productRepo = new ProductRepository();
            GenerateResource();
        }
        private void GenerateResource()
        {
            var index = 0;
            var name = "flower";
            Assembly assembly = typeof(XamApp.Views.DataPagerView).GetTypeInfo().Assembly;
            for (int i = 0; i < productRepo.Names.Count(); i++)
            {
                var p = new Product()
                {
                    Name = productRepo.Names[i],
                    Price = productRepo.Price[i],
                    Image = ImageSource.FromResource("XamApp.Images." + name + "" + i + ".jpg", assembly)
                };
                ProductCollection.Add(p);
            }
        }
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

    }    
}

