﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Frontend.Model;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace Frontend.ViewModel
{
    internal class ViewTasksViewModel : NotifiableObject
    {
        public BackendController controller;

        private UserModel userModel;
        public UserModel UserModel { get; set; }

        public BoardModel Board { get; private set; }

        private TaskModel selectedTask; // New property for selected task

        public TaskModel SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                RaisePropertyChanged(nameof(SelectedTask));
            }
        }


        public ViewTasksViewModel(UserModel userModel, BoardModel boardModel)
        {
            this.controller = userModel.Controller;
            this.UserModel = userModel;
            Board = boardModel;
        }

        public Response<string> AddTask(string taskTitle, string TaskDescription, DateTime taskDueDate)
        {
            try
            {
                return controller.addTask(taskTitle, TaskDescription, taskDueDate, UserModel.Email, Board.Name);
            }
            catch (Exception e)
            {
                return new Response<string>(e.Message, null);
            }
        }

        public Response<string> AdvanceTask()
        {
            try
            {
                string title = selectedTask.Title; // save title before removing from the collection
                Response<string> response = controller.AdvanceTask(UserModel.Email, Board.Name, title);

                return response;
            }
            catch (Exception e)
            {
                return new Response<string>(e.Message, null);
            }
        }

        public void RefreshTasks()
        {
            Board.RefreshTasks(controller);
        }
    }
}