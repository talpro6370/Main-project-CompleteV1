using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace part2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel vm;
        public progressBarStatus pgbs = new progressBarStatus();
        public WorkWithDB wwdb;
        public MainWindow()
        {
            
            vm = new MainWindowViewModel();
            InitializeComponent();
            this.DataContext = vm;
            //pgBar.DataContext = pgbs;
        }

        private void FlightsPerCmpnyTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void AirlineCmpTxtBox_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void AirlineCmpTxtBox_Error(object sender, ValidationErrorEventArgs e)
        {

        }
    }
}
