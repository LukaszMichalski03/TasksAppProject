using System;
using System.Threading.Tasks;
using TasksProject.DTOs;
using TasksProject.EF;
using TasksProject.Stores;
using TasksProject.ViewModels;

namespace TasksProject.Commands
{
    public class CreateTaskCommand : AsyncCommandBase
    {
        private readonly FormAddTaskViewModel _formAddTaskViewModel;
        private readonly SelectedUserStore _selectedUserStore;
        private readonly DbContextFactory _dbContextFactory;

        public CreateTaskCommand(FormAddTaskViewModel formAddTaskViewModel, SelectedUserStore selectedUserStore)
        {
            _formAddTaskViewModel = formAddTaskViewModel;
            _selectedUserStore = selectedUserStore;
            _dbContextFactory = new();

        }

        public override async Task ExecuteAsync(object parameter)
        {
            using(DataContext context = _dbContextFactory.Create())
            {
                TaskDTO taskDTO = new TaskDTO()
                {
                    Id = new Guid(),
                    Title = _formAddTaskViewModel.Title,

                    UserId = _selectedUserStore.SelectedUser.Id,
                    Description = _formAddTaskViewModel.Description,
                    Priority = _formAddTaskViewModel.PriorityEnum,
                    IsDone = false,


                };
                context.Tasks.Add(taskDTO);
                await context.SaveChangesAsync();
            }
            
            _formAddTaskViewModel.Title = string.Empty;
            _formAddTaskViewModel.Description = string.Empty;
        }
    }
}
