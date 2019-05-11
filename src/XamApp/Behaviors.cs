using Syncfusion.SfDataGrid.XForms.DataPager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamApp.ViewModels;
using Xamarin.Forms;

namespace XamApp
{
    public class SfListViewPagingBehavior : Behavior<ContentPage>
    {
        #region Fields

        private Syncfusion.ListView.XForms.SfListView listView;
        private ProductsViewModel ProductViewModel;
        private SfDataPager dataPager;

        #endregion

        #region Methods
        protected override void OnAttachedTo(ContentPage bindable)
        {
            listView = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            dataPager = bindable.FindByName<SfDataPager>("dataPager");
            ProductViewModel = new ProductsViewModel();
            //listView.BindingContext = ProductViewModel;
            dataPager.Source = ProductViewModel.pagingProducts;
            dataPager.OnDemandLoading += OnDemandPageLoading;
            base.OnAttachedTo(bindable);
        }

        private void DataPager_OnDemandLoading(object sender, OnDemandLoadingEventArgs e)
        {
            var source = ProductViewModel.pagingProducts.Skip(e.StartIndex).Take(e.PageSize);
            listView.ItemsSource = source.AsEnumerable();
        }
        private void OnDemandPageLoading(object sender, OnDemandLoadingEventArgs args)
        {
            dataPager.LoadDynamicItems(args.StartIndex, ProductViewModel.pagingProducts.Skip(args.StartIndex).Take(args.PageSize));
            //(dataPager.PagedSource as PagedCollectionView).ResetCache();
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            listView = null;
            ProductViewModel = null;
            dataPager = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion
    }
}
