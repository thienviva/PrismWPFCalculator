using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismCalculator.ViewModels
{
    public class CalculatorViewModel : BindableBase
    {
        public CalculatorViewModel()
        {

        }
        string _result;

        public string Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }
    }
}
