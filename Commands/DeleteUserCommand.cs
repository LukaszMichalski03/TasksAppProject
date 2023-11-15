using System.Threading.Tasks;
using TasksProject.DTOs;
using TasksProject.EF;
using TasksProject.Stores;

namespace TasksProject.Commands
{
    public class DeleteUserCommand : AsyncCommandBase
    {
        private readonly SelectedUserStore _selectedUserStore;
        private readonly DbContextFactory _contextFactory;

        public DeleteUserCommand(SelectedUserStore selectedUserStore) 
        {
            _contextFactory = new();
            _selectedUserStore = selectedUserStore;
            
        }
        public override async Task ExecuteAsync(object parameter)
        {
            if (_selectedUserStore.SelectedUser is not null)
            {

                using (DataContext context = _contextFactory.Create())
                {
                    UserDTO user = new UserDTO { Id = _selectedUserStore.SelectedUser.Id };
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();

                }
            }
            _selectedUserStore.SelectedUser = null;
            
        }
    }
}
