using System.Windows.Input;
using TasksProject.Commands;
using TasksProject.DTOs;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly CurrentUserStore _currentUserStore;

        public UserDTO CurrentUser => _currentUserStore.CurrentUser;

        public TasksListingViewModel TasksListingViewModel { get; }
        public TaskDetailsViewModel TaskDetailsViewModel { get; }

        public string Username => CurrentUser.Username;

        public LogoutCommand LogoutCommand { get; }
        public ICommand GoToProfileCommand { get; }

        public HomeViewModel(NavigationStore navigationStore ,CurrentUserStore currentUserStore, SelectedTaskStore selectedTaskStore)
        {
            _currentUserStore = currentUserStore;
            _currentUserStore.CurrentUserChanged += OnCurrentUserChanged;
            LogoutCommand = new LogoutCommand(navigationStore, _currentUserStore);
            GoToProfileCommand = new NavigateCommand<ProfileViewModel>(navigationStore, () => new ProfileViewModel(currentUserStore, navigationStore));
            TasksListingViewModel = new TasksListingViewModel(_currentUserStore, selectedTaskStore, navigationStore);
            TaskDetailsViewModel = new(selectedTaskStore);
        }

        protected override void Dispose()
        {
            _currentUserStore.CurrentUserChanged -= OnCurrentUserChanged;
            base.Dispose();
        }

        private void OnCurrentUserChanged()
        {
            OnPropertyChanged(nameof(CurrentUser));
        }
    }
}
