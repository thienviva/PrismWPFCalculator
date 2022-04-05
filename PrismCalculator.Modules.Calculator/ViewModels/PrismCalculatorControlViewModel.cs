using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace PrismCalculator.Modules.Calculator.ViewModels
{
    public class PrismCalculatorControlViewModel : BindableBase
    {
        public PrismCalculatorControlViewModel()
        {

        }

        private string _result;

        public string Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        private string _expression;
        public string Expression
        {
            get { return _expression; }
            set
            {
                SetProperty(ref _expression, value);
                CalculateCommand.RaiseCanExecuteChanged();
            }
        }
        private DelegateCommand<string> _clickCommand;

        public DelegateCommand<string> ClickCommand =>
            _clickCommand ?? (_clickCommand = new DelegateCommand<string>(ExecuteClickCommand));

        private DelegateCommand _calculateCommand;

        public DelegateCommand CalculateCommand =>
            _calculateCommand ?? (_calculateCommand = new DelegateCommand(Calculate, CanCalculate));
        
        private DelegateCommand<string> _trigoCommand;

        public DelegateCommand<string> TrigoCommand =>
            _trigoCommand ?? (_trigoCommand = new DelegateCommand<string>(CalculateTrigo));

        void CalculateTrigo(string param)
        {
            object trigoResult = null;
            if (param.StartsWith("A"))
            {
                var trigoInverseResult = typeof(Math).GetMethod(param).Invoke(null, new object[] { Convert.ToDouble(Expression) });
                trigoResult = Math.Round(Convert.ToDouble(trigoInverseResult) * (180 / Math.PI));
                param = param.Replace("A", "") + "\x207B\x00B9";
            }
            else
            {
                trigoResult = typeof(Math).GetMethod(param).Invoke(null, new object[] { Convert.ToDouble(Expression) * (Math.PI / 180) });
            }
            Result = $"{param}({Expression}) = {trigoResult}";
            Expression = string.Empty;

        }

        private bool CanCalculate()
        {
            //if expression is valid then only "=" button will enable
            var isvalidExpression = Expression != null ? Regex.IsMatch(Expression, @"^\d*\.?\-?\d+(\s*[+*/-]\-?\s*\d*\.?\d+)+$") : false;
            return isvalidExpression;
        }

        private void Calculate()
        {

            Result = Expression + "=" + new DataTable().Compute(Expression, "").ToString();
            Expression = string.Empty;
        }

        private void ExecuteClickCommand(string param)
        {
            Expression += param;
        }
    }
}
