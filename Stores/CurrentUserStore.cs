using System;
using TasksProject.DTOs;

namespace TasksProject.Stores
{
    public class CurrentUserStore
    {
        public event Action CurrentUserChanged;

        private UserDTO _currentUser;
        public UserDTO CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnCurrentUserlChanged();
            }
        }

        private void OnCurrentUserlChanged()
        {
            CurrentUserChanged?.Invoke();
        }
    }
}
