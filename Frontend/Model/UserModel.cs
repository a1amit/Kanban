using Frontend.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Model
{
    public class UserModel : NotifiableModelObject
    {
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                this.email = value;
                RaisePropertyChanged("Username");
            }
        }


        public ObservableCollection<IntModel> BoardsIds { get; set; }
        public ObservableCollection<BoardModel> BoardsNames { get; set; }

        public UserModel(BackendController controller, string email) : base(controller)
        {
            this.Email = email;
            List<string> list = (List<string>)(controller.getBoardsNames(email).ReturnValue);
            BoardsNames = new ObservableCollection<BoardModel>(list.
                Select((c, i) => new BoardModel(controller, this ,list[i])));
        }

    }
}