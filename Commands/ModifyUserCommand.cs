using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TasksProject.DTOs;
using TasksProject.EF;
using TasksProject.EFCRUD;
using TasksProject.Stores;
using TasksProject.ViewModels;

namespace TasksProject.Commands
{
    public class ModifyUserCommand : AsyncCommandBase
    {
        private readonly ProfileViewModel _profileViewModel;
        private readonly CurrentUserStore _currentUserStore;
        private readonly CreateUser _createUser;
        private readonly DbContextFactory _contextFactory;
        public override async Task ExecuteAsync(object parameter)
        {
            string username = _profileViewModel.CurrentName;
            string usernameModified = _profileViewModel.Username;
            string passwordModified = _profileViewModel.Password;
            using (DataContext context = _contextFactory.Create())
            {
                bool isUsernameTaken =await _createUser.IsTakenAsync(usernameModified);

                if (!isUsernameTaken)
                {
                    UserDTO userDto = context.Users.FirstOrDefault(u => u.Username == username);

                    if (userDto != null)
                    {
                        userDto.Username = usernameModified;
                        userDto.Password = passwordModified;

                        context.SaveChanges();
                        _currentUserStore.CurrentUser = userDto;
                        MessageBox.Show("Username, Password changed successfully");
                    }
                }
                else MessageBox.Show("This username is already taken!");
            }
        }

        public ModifyUserCommand(ProfileViewModel profileViewModel, CurrentUserStore currentUserStore) 
        {
            _contextFactory = new();
            _profileViewModel = profileViewModel;
            _currentUserStore = currentUserStore;
            _createUser = new(_contextFactory);
        }
    }
}
