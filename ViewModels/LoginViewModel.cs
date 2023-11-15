using System.Windows.Input;
using TasksProject.Commands;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username { get; set; }
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private string _password { get; set; } 
        public string Password 
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand NavigateRegisterCommand { get; set; }
        public ICommand SubmitLoginCommand { get; set; }

        public LoginViewModel(NavigationStore navigationStore, CurrentUserStore currentUserStore)
        {
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore, currentUserStore));
            SubmitLoginCommand = new SubmitLoginCommand(this, navigationStore, currentUserStore);
        }
    }
}
