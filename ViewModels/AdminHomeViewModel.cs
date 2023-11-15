using System.Windows.Input;
using TasksProject.Commands;
using TasksProject.DTOs;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class AdminHomeViewModel : ViewModelBase
    {
        private readonly CurrentUserStore _currentUserStore;
        private readonly SelectedUserStore _selectedUserStore;

        public UserDTO CurrentUser => _currentUserStore.CurrentUser;

        public UsersListingViewModel UsersListingViewModel { get; set; }
        public FormDetailsMainViewModel MainDetailsFormViewModel { get; }

        public string Username => CurrentUser.Username;

        public LogoutCommand LogoutCommand { get; }
        public ICommand GoToProfileCommand { get; }

        public AdminHomeViewModel(NavigationStore navigationStore, CurrentUserStore currentUserStore, SelectedUserStore selectedUserStore)
        {
            _currentUserStore = currentUserStore;
            _selectedUserStore = selectedUserStore;
            LogoutCommand = new LogoutCommand(navigationStore, _currentUserStore);
            GoToProfileCommand = new NavigateCommand<ProfileViewModel>(navigationStore, () => new ProfileViewModel(currentUserStore, navigationStore));
            UsersListingViewModel = new UsersListingViewModel(_currentUserStore, _selectedUserStore, navigationStore);
            MainDetailsFormViewModel = new FormDetailsMainViewModel(new DetailsFormNavigationStore(), _selectedUserStore);

            _currentUserStore.CurrentUserChanged += OnCurrentUserChanged; 
            _selectedUserStore.SelectedUserChanged += _selectedUserStore_SelectedUserChanged;

        }
        protected override void Dispose()
        {
            _currentUserStore.CurrentUserChanged -= OnCurrentUserChanged;
            _selectedUserStore.SelectedUserChanged -= _selectedUserStore_SelectedUserChanged;
            base.Dispose();
        }
        private void _selectedUserStore_SelectedUserChanged()
        {
            if (_selectedUserStore.SelectedUser == null)
            {
                OnPropertyChanged(nameof(UsersListingViewModel));
            }
        }

        private void OnCurrentUserChanged()
        {
            OnPropertyChanged(nameof(CurrentUser));
        }
    }
}
