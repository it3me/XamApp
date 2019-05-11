using Acr.UserDialogs;
using Autofac;
using Bit;
using Bit.ViewModel.Contracts;
using Bit.ViewModel.Implementations;
using Prism;
using Prism.Autofac;
using Prism.Ioc;
using System.Globalization;
using System.Threading.Tasks;
using XamApp.Resources;
using XamApp.ViewModels;
using XamApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace XamApp
{
    public partial class App : BitApplication
    {
        public new static App Current
        {
            get { return (App)Application.Current; }
        }

        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer platformInitializer)
            : base(platformInitializer)
        {
#if DEBUG
            LiveReload.Init();
#endif


        }

        protected async override Task OnInitializedAsync()
        {
           
            InitializeComponent();

            Strings.Culture = CultureInfo.CurrentUICulture = new CultureInfo("en");

            await NavigationService.NavigateAsync("/Nav/ActivationPage");
            //await NavigationService.NavigateAsync("/Nav/GridLayout");


            //await NavigationService.NavigateAsync("/Nav/Products");
            //await NavigationService.NavigateAsync("/DataPager");

            await base.OnInitializedAsync();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ContainerBuilder containerBuilder = containerRegistry.GetBuilder();

            containerRegistry.RegisterForNav<NavigationPage>("Nav");
            containerRegistry.RegisterForNav<XamAppMasterDetailView, XamAppMasterDetailViewModel>("MasterDetail");
            containerRegistry.RegisterForNav<HelloWorldView, HelloWorldViewModel>("HelloWorld");
            containerRegistry.RegisterForNav<HelloWorldMultiLanguageView, HelloWorldViewModel>("HelloWorldMultiLanguage");
            containerRegistry.RegisterForNav<LoginView, LoginViewModel>("Login");
            containerRegistry.RegisterForNav<IntroView, IntroViewModel>("Intro");
            containerRegistry.RegisterForNav<ProductsView, ProductsViewModel>("Products");
            containerRegistry.RegisterForNav<ProductDetailView, ProductDetailViewModel>("ProductDetail");
            
            containerRegistry.RegisterForNav<MelkradarView, MelkradarViewMode>("ActivationPage");
            containerRegistry.RegisterForNav<ServiceItemsView, ServiceItemsViewModel>("ServiceItems");

            containerRegistry.RegisterForNav<DataPagerView, DataPagerViewModel>("DataPager");

            containerRegistry.RegisterForNav<GridLayoutView, GridLayoutViewModel>("GridLayout");
            containerRegistry.RegisterForNav<FlexLayoutView, FlexLayoutViewModel>("FlexLayout");
            containerRegistry.RegisterForNav<StackLayoutView, StackLayoutViewModel>("StackLayout");




            containerBuilder.Register<IClientAppProfile>(c => new DefaultClientAppProfile
            {
                AppName = "XamApp",
            }).SingleInstance();

            containerBuilder.RegisterRequiredServices();

            containerBuilder.RegisterInstance(UserDialogs.Instance);

            base.RegisterTypes(containerRegistry);
        }
    }
}
