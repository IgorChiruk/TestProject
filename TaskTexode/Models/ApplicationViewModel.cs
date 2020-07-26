using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Media;


namespace TaskTexode.Models
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private UserView selectedUser;
        public ObservableCollection<UserView> Users { get; set; }       
        public ApplicationViewModel()
        {
            FillCollection();
        }

        private void FillCollection()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Users = new ObservableCollection<UserView>();
                var allUsers = context.GetAllUsers();           

                foreach (ApplicationUser user in allUsers)
                {                   
                    CreateAndAddUserView(user);
                }
            }
        }

        private void CreateAndAddUserView(ApplicationUser user)
        {
            int best = 0, worst = Int32.MaxValue, average = 0;
            foreach (UserRecord record in user.UserRecords)
            {
                average += Convert.ToInt32(record.Steps);
                if (best < Convert.ToInt32(record.Steps)) { best = Convert.ToInt32(record.Steps); }
                if (worst > Convert.ToInt32(record.Steps)) { worst = Convert.ToInt32(record.Steps); }
            }
            average = average / user.UserRecords.Count;
            UserView newUserView = new UserView(user.Name, average.ToString(), best.ToString(), worst.ToString());
            Users.Add(newUserView);
        }
       
        public UserView SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void SetUserViewColor(int averageSteps)
        {
            foreach (UserView user in Users)
            {
                if (Convert.ToInt32(user.AverageNumberOfSteps) >= averageSteps * 1.2)
                {
                    user.BackgroundColor = Colors.Green;
                }
                else if (Convert.ToInt32(user.AverageNumberOfSteps) <= averageSteps * 0.8)
                {
                    user.BackgroundColor = Colors.Red;
                }
                else
                {
                    user.BackgroundColor = Colors.White;
                }
            }
        }
    }
}
