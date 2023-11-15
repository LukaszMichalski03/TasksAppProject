using System.Linq;
using System.Threading.Tasks;
using TasksProject.DTOs;
using TasksProject.EF;
using TasksProject.Stores;

namespace TasksProject.Commands
{
    public class DeleteTaskCommand : AsyncCommandBase
    {
        private readonly DbContextFactory _contextFactory;
        private readonly SelectedTaskStore _selectedTaskStore;
        private TaskDTO? _selectedTask => _selectedTaskStore.SelectedTask;

        public override async Task ExecuteAsync(object parameter)
        {
            using (DataContext context = _contextFactory.Create())
            {
                TaskDTO taskDTO = context.Tasks.FirstOrDefault(t => t.Id == _selectedTask.Id);

                context.Tasks.Remove(taskDTO);
                context.SaveChanges();
            }
            _selectedTaskStore.SelectedTask = null;
        }
        public DeleteTaskCommand(SelectedTaskStore selectedTaskStore) 
        {
            _selectedTaskStore = selectedTaskStore;
            _contextFactory = new();
        }
    }
}
