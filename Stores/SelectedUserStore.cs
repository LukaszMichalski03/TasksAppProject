using System;
using TasksProject.DTOs;

namespace TasksProject.Stores
{
    public class SelectedUserStore
    {
        private UserDTO? _selectedUser;
        public UserDTO? SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                OnSelectedUserChanged();
            }
        }

        public event Action SelectedUserChanged;
        private void OnSelectedUserChanged()
        {
            SelectedUserChanged?.Invoke();
        }
    }
}
