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
using System.Windows.Shapes;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for AddBoardWindow.xaml
    /// </summary>
    public partial class AddBoardWindow : Window
    {
        public string BoardName { get; private set; }

        public AddBoardWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            BoardName = txtBoardName.Text;
            DialogResult = true; // Indicate that the dialog was closed with a positive result
        }
        private void txtBoardName_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void txtBoardName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoardName.Text))
            {
                txtPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                txtPlaceholder.Visibility = Visibility.Collapsed;
            }
        }
    }
}
