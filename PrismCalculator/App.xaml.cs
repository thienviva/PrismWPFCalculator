using PrismCalculator.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using PrismCalculator.Modules.Calculator;
using PrismCalculator.Modules.Login.Views;

namespace PrismCalculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<MainModule>();
            moduleCatalog.AddModule<CalculatorModule>();
        }

        //protected override void OnInitialized()
        //{
        //    var login = Container.Resolve<PrismLoginWindow>();
        //    var result = login.ShowDialog();
        //    if (result.Value)
        //        base.OnInitialized();
        //    else
        //        Application.Current.Shutdown();
        //    base.OnInitialized();
        //}
    }
}
