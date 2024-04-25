using System;
using System.Windows;

namespace Frontend.View
{
    public partial class AddNewTaskWindow : Window
    {
        // Properties to access the values
        public string TaskTitle { get; private set; }
        public string TaskDescription { get; private set; }
        public DateTime TaskDueDate { get; private set; }

        public AddNewTaskWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window when the Cancel button is clicked
            this.Close();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Save the values from the TextBoxes and DatePicker as properties
            TaskTitle = TitleTextBox.Text;
            TaskDescription = DescriptionTextBox.Text;
            TaskDueDate = DueDatePicker.SelectedDate ?? DateTime.MinValue; // Default to minimum date if no date is selected
            DialogResult = true;
        }
    }
}