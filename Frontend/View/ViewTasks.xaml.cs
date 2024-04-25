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
using Frontend.Model;
using Frontend.ViewModel;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for ViewTasks.xaml
    /// </summary>
    public partial class ViewTasks : Window
    {
        private ViewTasksViewModel viewModel;
        private UserModel userModel;

        public ViewTasks(UserModel userModel, BoardModel boardModel)
        {
            InitializeComponent();
            this.viewModel = new ViewTasksViewModel(userModel, boardModel);
            this.DataContext = viewModel;
            this.userModel = userModel;
        }


        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            Boards boards = new Boards(userModel);
            boards.Show();
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}