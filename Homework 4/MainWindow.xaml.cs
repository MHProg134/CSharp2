using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Homework_4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool IsValidUSZip()
        {
            if (Regex.IsMatch(uxPostalCode.Text , "^[0-9]{5}(?:-[0-9]{4})?$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsValidCanadianPC()
        {
            if (Regex.IsMatch(uxPostalCode.Text, "^([ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ])[ ]{0,1}([0-9][ABCEGHJKLMNPRSTVWXYZ][0-9])$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitted.");
        }

        private void UxPostalCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsValidUSZip() || IsValidCanadianPC())
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
