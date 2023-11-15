using TasksProject.DTOs;

namespace TasksProject.ViewModels
{
    public class UsersListingItemViewModel : ViewModelBase
    {
        public UsersListingItemViewModel(UserDTO user)
        {
            User = user;
            
        }
        public UserDTO User { get; set; }
        public string Username => User.Username;
        
        
    }
}
