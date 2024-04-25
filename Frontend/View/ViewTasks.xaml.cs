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
using IntroSE.Kanban.Backend.BusinessLayer;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace Frontend.View
{
    /// <summary>
    /// Interaction logic for ViewTasks.xaml
    /// </summary>
    public partial class ViewTasks : Window
    {
        private ViewTasksViewModel viewTasksViewModel;
        private UserModel userModel;

        public ViewTasks(UserModel userModel, BoardModel boardModel)
        {
            InitializeComponent();
            this.viewTasksViewModel = new ViewTasksViewModel(userModel, boardModel);
            this.DataContext = viewTasksViewModel;
            this.userModel = userModel;
        }


        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            Boards boards = new Boards(userModel);
            boards.Show();
            this.Close();
        }

        private void AddNewTask_Click(object sender, RoutedEventArgs e)
        {
            var AddNewTaskWindow = new AddNewTaskWindow();
            if (AddNewTaskWindow.ShowDialog() == true)
            {
                Response<string> response = viewTasksViewModel.AddTask(AddNewTaskWindow.TaskTitle,
                    AddNewTaskWindow.TaskDescription,
                    AddNewTaskWindow.TaskDueDate);
                string returnValue = (string)response.ReturnValue;

                if (response.ErrorMessage == null)
                {
                    MessageBox.Show("Added a new task successfully", "Success", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    viewTasksViewModel.RefreshTasks();
                }
                else
                {
                    MessageBox.Show(response.ErrorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}