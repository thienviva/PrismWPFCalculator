using PrismCalculator.Modules.Calculator.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace PrismCalculator.Modules.Calculator
{
    public class CalculatorModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var region = containerProvider.Resolve<IRegionManager>();
            region.RegisterViewWithRegion("ContentRegion", typeof(PrismCalculatorControl));

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}