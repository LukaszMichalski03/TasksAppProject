using TasksProject.Stores;
using TasksProject.ViewModels;

namespace TasksProject.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly CurrentUserStore _currentUserStore;

        public LogoutCommand(NavigationStore navigationStore, CurrentUserStore currentUserStore) 
        {
            _navigationStore = navigationStore;
            _currentUserStore = currentUserStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore, _currentUserStore);
            _currentUserStore.CurrentUser = null;
        }
    }
}
