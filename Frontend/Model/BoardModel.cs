using IntroSE.Kanban.Backend.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = IntroSE.Kanban.Backend.BusinessLayer.Task;


namespace Frontend.Model
{
    public class BoardModel : NotifiableModelObject
    {
        private UserModel userModel;

        private ObservableCollection<TaskModel> backlog;

        public ObservableCollection<TaskModel> Backlog
        {
            get { return backlog; }
            set { backlog = value; }
        }

        private ObservableCollection<TaskModel> inProgress;

        public ObservableCollection<TaskModel> InProgress
        {
            get { return inProgress; }
            set { inProgress = value; }
        }

        private ObservableCollection<TaskModel> done { get; set; }

        public ObservableCollection<TaskModel> Done
        {
            get { return done; }
            set { done = value; }
        }

        private string name { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public BoardModel(BackendController bc, UserModel userModelModel, string boardName) : base(bc)
        {
            this.userModel = userModelModel;
            this.name = boardName;

            List<Task> backlogList = (List<Task>)(bc.getColumn(userModel.Email, this.name, 0).ReturnValue);

            backlog = new ObservableCollection<TaskModel>(backlogList.Select((c, i) =>
                new TaskModel(bc, backlogList[i].title, backlogList[i].Description, backlogList[i].DueDate,
                    backlogList[i].Assignie)));

            List<Task> inProgressList = (List<Task>)(bc.getColumn(userModel.Email, this.name, 1).ReturnValue);

            inProgress = new ObservableCollection<TaskModel>(inProgressList.Select((c, i) =>
                new TaskModel(bc, inProgressList[i].title, inProgressList[i].Description, inProgressList[i].DueDate,
                    inProgressList[i].Assignie)));

            List<Task> doneList = (List<Task>)(bc.getColumn(userModel.Email, this.name, 2).ReturnValue);

            done = new ObservableCollection<TaskModel>(doneList.Select((c, i) =>
                new TaskModel(bc, doneList[i].title, doneList[i].Description, doneList[i].DueDate,
                    doneList[i].Assignie)));
        }

        public void RefreshTasks(BackendController backendController)
        {
            // Retrieve updated task lists from the backend for each column
            List<Task> updatedBacklog =
                (List<Task>)(backendController.getColumn(userModel.Email, this.name, 0).ReturnValue);
            List<Task> updatedInProgress =
                (List<Task>)(backendController.getColumn(userModel.Email, this.name, 1).ReturnValue);
            List<Task> updatedDone =
                (List<Task>)(backendController.getColumn(userModel.Email, this.name, 2).ReturnValue);

            // Update backlog
            backlog.Clear();
            foreach (Task task in updatedBacklog)
            {
                backlog.Add(new TaskModel(backendController, task.title, task.Description, task.DueDate,
                    task.Assignie));
            }

            // Update inProgress
            inProgress.Clear();
            foreach (Task task in updatedInProgress)
            {
                inProgress.Add(new TaskModel(backendController, task.title, task.Description, task.DueDate,
                    task.Assignie));
            }

            // Update done
            done.Clear();
            foreach (Task task in updatedDone)
            {
                done.Add(new TaskModel(backendController, task.title, task.Description, task.DueDate, task.Assignie));
            }
        }
    }
}