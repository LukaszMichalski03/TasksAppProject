using System.Windows.Input;
using TasksProject.Commands;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
        private readonly CurrentUserStore _currentUserStore;

        public string CurrentName => _currentUserStore.CurrentUser.Username;
        private string _usernameModified { get; set; }
        public string Username
        {
            get { return _usernameModified; }
            set
            {
                _usernameModified = value;
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

        public ICommand SaveChanges { get; }
        public ICommand ReturnToMenu { get; }
        public ProfileViewModel(CurrentUserStore currentUserStore, NavigationStore navigationStore) 
        {
            _currentUserStore = currentUserStore;
            SaveChanges = new ModifyUserCommand(this, _currentUserStore);
            if(_currentUserStore.CurrentUser.IsAdmin == true)
            {
                ReturnToMenu = new NavigateCommand<AdminHomeViewModel>(navigationStore, () => new AdminHomeViewModel(navigationStore, _currentUserStore, new SelectedUserStore()));
            }
            else if(_currentUserStore.CurrentUser.IsAdmin == false)
            {
                ReturnToMenu = new NavigateCommand<HomeViewModel>(navigationStore, () => new HomeViewModel(navigationStore, _currentUserStore, new SelectedTaskStore()));
            }
            _currentUserStore.CurrentUserChanged += OnCurrentUserChanged;
        }

        protected override void Dispose()
        {
            _currentUserStore.CurrentUserChanged -= OnCurrentUserChanged;
            base.Dispose();
        }

        private void OnCurrentUserChanged()
        {
            OnPropertyChanged(nameof(CurrentName));
        }
    }
}
