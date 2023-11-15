using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using TasksProject.DTOs;
using TasksProject.EFCRUD;
using TasksProject.Stores;
using TasksProject.ViewModels;

namespace TasksProject.Commands
{
    public class CreateAccountCommand : AsyncCommandBase
    {
        private readonly RegisterViewModel _registerViewModel;
        private readonly NavigationStore _navigationStore;
        private readonly CurrentUserStore _currentUserStore;

        private readonly CreateUser _createUser;
        
        public override async Task ExecuteAsync(object parameter)
        {
            bool isUsernameTaken = await _createUser.IsTakenAsync(_registerViewModel.Username);
            if (!isUsernameTaken)
            {
                UserDTO user = new UserDTO{ 
                    Id=new Guid(),
                    Username = _registerViewModel.Username,
                    Password=_registerViewModel.Password,
                    IsAdmin = _registerViewModel.IsAdmin,
                    Tasks = new List<TaskDTO>()
                };

                await _createUser.Execute(user);                    
                
                if(user.IsAdmin == true)
                {
                    _navigationStore.CurrentViewModel = new AdminHomeViewModel(_navigationStore, _currentUserStore, new());
                }
                else
                {
                    _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore, _currentUserStore, new());
                }
               
                _currentUserStore.CurrentUser = user;
                
            }
            else MessageBox.Show("Username is already taken");
                      
        }
        

        public CreateAccountCommand(RegisterViewModel registerViewModel, NavigationStore navigationStore, CurrentUserStore currentUserStore)
        {
            _registerViewModel = registerViewModel;
            _navigationStore = navigationStore;
            _currentUserStore = currentUserStore;
            
            _createUser = new(new ());
        }
    }
}
