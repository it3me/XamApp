using Bit.Model;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XamApp.Models
{
    public class Product : Bindable ,  INotifyPropertyChanged
    {
       // public int Id { get; set; }
       // public bool IsActive { get; set; }

        public string Name { get; set; }
       
        public ImageSource Image { get; set; }        

        public string Price { get; set; }       
                
        private void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
