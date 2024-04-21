using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Frontend.Model;
using Frontend.View;
using IntroSE.Kanban.Backend.ServiceLayer;

namespace Frontend.ViewModel
{
    internal class BoardsViewModel : NotifiableObject
    {
        public UserModel UserModel;

        public BackendController controller;

        public UserModel User { get; private set; }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Title { get; private set; }

        private BoardModel selectedBoard;

        public BoardModel SelectedBoard
        {
            get { return selectedBoard; }
            set
            {
                selectedBoard = value;
            }
        }

        public BoardsViewModel(UserModel user)
        {
            this.controller = user.Controller;
            this.UserModel = user;
            Title = "Boards of " + user.Email;
            Email = user.Email;
            User = user;
        }

        public Response<string> Logout()
        {
            try
            {
                return UserModel.Controller.logOut(UserModel.Email);
            }
            catch (Exception e)
            {
                // Message = e.Message;
                return new Response<string>(e.Message, null);
            }
        }
        public Response<string> AddBoard(string boardName)
        {
            try
            {
                return controller.AddBoard(UserModel.Email, boardName);
            }
            catch (Exception e)
            {
                return new Response<string>(e.Message, null);
            }
        }
    }
}