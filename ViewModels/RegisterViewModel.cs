using System.Windows.Input;
using TasksProject.Commands;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class RegisterViewModel : ViewModelBase
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
        private bool _isAdmin { get; set; }
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }


        public ICommand NavigateLoginCommand { get; }
        public ICommand CreateAccountCommand { get; }
        public RegisterViewModel(NavigationStore navigationStore, CurrentUserStore currentUserStore)
        {
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore, currentUserStore));
            CreateAccountCommand = new CreateAccountCommand(this,navigationStore, currentUserStore);
        }
    }
}
