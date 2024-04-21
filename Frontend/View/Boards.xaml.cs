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
using Frontend.Model;
using Frontend.View;
using Frontend.ViewModel;
using IntroSE.Kanban.Backend.BusinessLayer;
using IntroSE.Kanban.Backend.ServiceLayer;


namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for Boards.xaml
    /// </summary>
    public partial class Boards : Window
    {
        private BoardsViewModel boardsViewModel;

        public Boards(UserModel userModel)
        {
            InitializeComponent();
            this.boardsViewModel = new BoardsViewModel(userModel);
            this.DataContext = boardsViewModel;
        }



        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            boardsViewModel.Logout();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void addBoard_Click(object sender, RoutedEventArgs e)
        {
            var addBoardWindow = new AddBoardWindow();
            if (addBoardWindow.ShowDialog() == true)
            {
                Response<string> response = boardsViewModel.AddBoard(addBoardWindow.BoardName);
                string returnValue = (string)response.ReturnValue;

                if (response.ErrorMessage == null)
                {
                    MessageBox.Show("Added a new board successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(response.ErrorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ViewTasks viewTasks = new ViewTasks(boardsViewModel.UserModel, boardsViewModel.SelectedBoard);
            viewTasks.Show();
            this.Close();
        }


        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
    }
}