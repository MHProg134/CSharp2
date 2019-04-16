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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSubmit();
        }

        private void UxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSubmit();
        }

        private void EnableSubmit()
        {
            if ((uxName.Text != "") & (uxPassword.Text != ""))
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }
    }
}
