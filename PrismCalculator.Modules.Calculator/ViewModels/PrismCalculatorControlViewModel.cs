using Prism.Commands;
using Prism.Mvvm;
using PrismCalculator.Modules.Login.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

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
            if (Expression == "" || Expression == null )
            {
                Result = "Error! Let input value!";
            }
            else
            {
                object trigoResult = null;
                if (param.StartsWith("A"))
                {
                    var trigoInverseResult = typeof(Math).GetMethod(param).Invoke(null, new object[] { Convert.ToDouble(Expression) });
                    trigoResult = Math.Round(Convert.ToDouble(trigoInverseResult) * (180 / Math.PI));
                    param = param.Replace("A", "") + "\x207B\x00B9";
                }
                else if (param.EndsWith("h"))
                    trigoResult = typeof(Math).GetMethod(param).Invoke(null, new object[] { Convert.ToDouble(Expression) });
                else
                {
                    trigoResult = typeof(Math).GetMethod(param).Invoke(null, new object[] { Convert.ToDouble(Expression) * (Math.PI / 180) });
                }
                Result = $"{param}({Expression}) = {trigoResult}";
                Expression = string.Empty;
            }


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

        private DelegateCommand _sinhInverseCommand;

        public DelegateCommand SinhInverseCommand =>
            _sinhInverseCommand ?? (_sinhInverseCommand = new DelegateCommand(SinhInverse));

        void SinhInverse()
        {
            if (Expression == "" || Expression == null )
            {
                Result = "Error! Let input value!";
            }
            else
            {
                var input = Convert.ToDouble(Expression);
                var result = Math.Log(input + Math.Sqrt(Math.Pow(input, 2) + 1));
                Result = $"Sinh\x207B\x00B9({Expression}) = {result}";
                Expression = string.Empty;
            }

        }

        private DelegateCommand _coshInverseCommand;

        public DelegateCommand CoshInverseCommand =>
            _coshInverseCommand ?? (_coshInverseCommand = new DelegateCommand(CoshInverse));

        void CoshInverse()
        {
            if (Expression == "" || Expression == null )
            {
                Result = "Error! Let input value!";
            }
            else
            {
                var input = Convert.ToDouble(Expression);
                var result = Math.Log(input + Math.Sqrt(Math.Pow(input, 2) - 1));
                Result = $"Cosh\x207B\x00B9({Expression}) = {result}";
                Expression = string.Empty;
            }

        }

        private DelegateCommand _tanhInverseCommand;

        public DelegateCommand TanhInverseCommand =>
            _tanhInverseCommand ?? (_tanhInverseCommand = new DelegateCommand(TanhInverse));

        void TanhInverse()
        {
            if (Expression == "" || Expression == null )
            {
                Result = "Error! Let input value!";
            }
            else
            {
                var input = Convert.ToDouble(Expression);
                var result = 0.5 * Math.Log((1 + input) / (1 - input));
                Result = $"Tanh\x207B\x00B9({Expression}) = {result}";
                Expression = string.Empty;
            }
        }

        private DelegateCommand _sechInverseCommand;

        public DelegateCommand SechInverseCommand =>
            _sechInverseCommand ?? (_sechInverseCommand = new DelegateCommand(SechInverse));

        void SechInverse()
        {
            if (Expression == "" || Expression == null )
            {
                Result = "Error! Let input value!";
            }
            else
            {
                var input = Convert.ToDouble(Expression);
                var result = Math.Log((1 + Math.Sqrt(1 - Math.Pow(input, 2))) / input);
                Result = $"Sech\x207B\x00B9({Expression}) = {result}";
                Expression = string.Empty;
            }
        }


        private DelegateCommand _cosechInverseCommand;

        public DelegateCommand CosechInverseCommand =>
            _cosechInverseCommand ?? (_cosechInverseCommand = new DelegateCommand(CosechInverse));

        void CosechInverse()
        {
            if (Expression == "" || Expression == null )
            {
                Result = "Error! Let input value!";
            }
            else
            {
                var input = Convert.ToDouble(Expression);
                var result = Math.Log((1 + Math.Sqrt(1 + Math.Pow(input, 2))) / input);
                Result = $"Cosech\x207B\x00B9({Expression}) = {result}";
                Expression = string.Empty;
            }
        }

        private DelegateCommand _cothInverseCommand;

        public DelegateCommand CothInverseCommand =>
            _cothInverseCommand ?? (_cothInverseCommand = new DelegateCommand(CothInverse));

        void CothInverse()
        {
            if (Expression == "" || Expression == null )
            {
                Result = "Error! Let input value!";
            }
            else
            {
                var input = Convert.ToDouble(Expression);
                var result = 0.5 * Math.Log((input + 1) / (input - 1));
                Result = $"Coth\x207B\x00B9({Expression}) = {result}";
                Expression = string.Empty;
            }
        }

        private DelegateCommand _PICommand;

        public DelegateCommand PICommand =>
            _PICommand ?? (_PICommand = new DelegateCommand(PI));

        void PI()
        {
            Result = $"\x03a0 = { Math.PI}";
        }
        private DelegateCommand _inverseCommand;

        public DelegateCommand InverseCommand =>
            _inverseCommand ?? (_inverseCommand = new DelegateCommand(ExecuteInverse));
        void ExecuteInverse()
        {
            Result = $"1 / {Expression} = {1 / Convert.ToDouble(Expression)}";
            Expression = string.Empty;
        }

        private DelegateCommand _powerCommand;


        public DelegateCommand PowerCommand =>
            _powerCommand ?? (_powerCommand = new DelegateCommand(ExecutePower));

        void ExecutePower()
        {
            if (Expression == "" || Expression == null )
            {
                Result = "Error! Let input value!";
            }
            else
            {
                //Expression should be x,y
                var exp = Expression.Split(',');
                if (exp.Count() <= 1)
                {
                    Result = "Incorrect input!";
                }
                else
                {
                    var _base = Convert.ToDouble(exp[0]);
                    var pow = Convert.ToDouble(exp[1]);
                    var result = Math.Pow(_base, pow);
                    Result = $"{_base}^{pow} = {result}";
                    Expression = string.Empty;
                }
               
            }
        }

        private DelegateCommand _eCommand;

        public DelegateCommand ECommand =>
            _eCommand ?? (_eCommand = new DelegateCommand(E));

        void E()
        {
            Result = $"e = {Math.E}";
        }

        private DelegateCommand _ePowerCommand;

        public DelegateCommand EPowerCommand =>
            _ePowerCommand ?? (_ePowerCommand = new DelegateCommand(EPower));

        void EPower()
        {
            if (Expression == "" || Expression == null )
            {
                Result = "Error! Let input value!";
            }
            else
            {
                var pow = Convert.ToDouble(Expression);
                Result = $"e ^ {pow} = {Math.Pow(Math.E, pow)}";
                Expression = string.Empty;
            }
        }

        private DelegateCommand _cubeRootCommand;

        public DelegateCommand CubeRootCommand =>
            _cubeRootCommand ?? (_cubeRootCommand = new DelegateCommand(CubeRoot));

        void CubeRoot()
        {
            if (Expression == "" || Expression == null)
            {
                Result = "Error! Let input value!";
            }
            else
            {
                var result = Math.Round(Math.Pow(Convert.ToDouble(Expression), (double)1 / 3));
                Result = $"\u221B{Expression} = {result}";
                Expression = string.Empty;
            }
        }

        private DelegateCommand _squareRootCommand;

        public DelegateCommand SquareRootCommand =>
            _squareRootCommand ?? (_squareRootCommand = new DelegateCommand(SquareRoot));

        void SquareRoot()
        {
            if (Expression == "" || Expression == null)
            {
                Result = "Error! Let input value!";
            }
            else
            {
                Result = $"\u221A{Expression} = {Math.Sqrt(Convert.ToDouble(Expression))}";
                Expression = string.Empty;
            }
        }

        private DelegateCommand _factCommand;

        public DelegateCommand FactCommand =>
            _factCommand ?? (_factCommand = new DelegateCommand(Factorial));

        void Factorial()
        {
            if (Expression == "" || Expression == null)
            {
                Result = "Error! Let input value!";
            }
            else
            {
                var n = Convert.ToDouble(Expression);
                var fact = 1;
                for (var i = 1; i <= n; i++)
                {
                    fact = fact * i;
                }
                Result = $"{n}! = {fact}";
                Expression = string.Empty;
            }
        }

        private DelegateCommand _logBaseECommand;

        public DelegateCommand LogBaseECommand =>
            _logBaseECommand ?? (_logBaseECommand = new DelegateCommand(LogBaseE));

        void LogBaseE()
        {
            if (Expression == "" || Expression == null)
            {
                Result = "Error! Let input value!";
            }
            else
            {
                Result = $"Log\x2091{Expression} = {Math.Log(Convert.ToDouble(Expression))}";
                Expression = string.Empty;
            }
        }

        private DelegateCommand _logBase10Command;

        public DelegateCommand LogBase10Command =>
            _logBase10Command ?? (_logBase10Command = new DelegateCommand(LogBase10));

        void LogBase10()
        {
            if (Expression == "" || Expression == null)
            {
                Result = "Error! Let input value!";
            }
            else
            {
                Result = $"Log\x2081\x2080{Expression} = {Math.Log(Convert.ToDouble(Expression))}";
                Expression = string.Empty;
            }
        }

        private DelegateCommand _logBaseNCommand;

        public DelegateCommand LogBaseNCommand =>
            _logBaseNCommand ?? (_logBaseNCommand = new DelegateCommand(LogBaseN));

        void LogBaseN()
        {
            if (Expression == "" || Expression == null)
            {
                Result = "Error! Let input value!";
            }
            else
            {
                //Expression should be x,base
                var exp = Expression.Split(',');
                if (exp.Count() <= 1)
                {
                    Result = "Incorrect input!";
                }
                else
                {
                    var x = Convert.ToDouble(exp[0]);
                    var _base = Convert.ToDouble(exp[1]);
                    Result = $"Log\x2099{x} = {Math.Log(x, _base)} where n={_base}";
                    Expression = string.Empty;
                }
            }
        }

        private DelegateCommand _remainderCommand;

        public DelegateCommand RemainderCommand =>
            _remainderCommand ?? (_remainderCommand = new DelegateCommand(Remainder));

        void Remainder()
        {
            if (Expression == "" || Expression == null)
            {
                Result = "Error! Let input value!";
            }
            else
            {
                //Expression should be a,b
                var exp = Expression.Split(',');
                if (exp.Count() <= 1)
                {
                    Result = "Incorrect input!";
                }
                else
                {
                    var a = Convert.ToDouble(exp[0]);
                    var b = Convert.ToDouble(exp[1]);
                    Result = $"{a} % {b} = {a % b}";
                    Expression = string.Empty;
                }
            }
        }

        public DelegateCommand LoginCommand => new DelegateCommand(LoginExe);

        public void LoginExe()
        {
            var w = Application.Current.Windows[0];
            w.Hide();
            PrismLoginWindow login = new PrismLoginWindow();
            login.ShowDialog();

            w.Show();
        }
    }
}
