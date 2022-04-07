using System.Windows;

namespace PrismCalculator.Modules.Login.Views
{
    /// <summary>
    /// Interaction logic for PrismLoginWindow.xaml
    /// </summary>
    public partial class PrismLoginWindow : Window
    {
        public PrismLoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
            //DialogResult = true;
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            this.Hide();

            //DialogResult = false;
        }
    }
}
