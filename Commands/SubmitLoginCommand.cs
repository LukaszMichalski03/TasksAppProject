using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Windows;
using TasksProject.DTOs;
using TasksProject.EF;
using TasksProject.Stores;
using TasksProject.ViewModels;

namespace TasksProject.Commands
{
    public class SubmitLoginCommand : AsyncCommandBase
    {
        private readonly LoginViewModel _registerViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly CurrentUserStore _currentUserStore;

        private DbContextFactory _contextFactory => new();

        public override async Task ExecuteAsync(object parameter)
        {
            string username = _registerViewModel.Username;
            string password = _registerViewModel.Password;
            using(DataContext context = _contextFactory.Create())
            {
                UserDTO userDto = await context.Users
                    .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
                if (userDto != null)
                {
                    
                    if(userDto.IsAdmin == true)  _navigationStore.CurrentViewModel = new AdminHomeViewModel(_navigationStore, _currentUserStore, new SelectedUserStore()); 
                    else _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore, _currentUserStore, new());

                    _currentUserStore.CurrentUser = userDto;

                }
                else MessageBox.Show("Account does not exist");
            }
        }
        public SubmitLoginCommand(LoginViewModel registerViewModel, NavigationStore navigationStore, CurrentUserStore currentUserStore)
        {
            _registerViewModel = registerViewModel;
            _navigationStore = navigationStore;
            _currentUserStore = currentUserStore;
        }
    }
}
