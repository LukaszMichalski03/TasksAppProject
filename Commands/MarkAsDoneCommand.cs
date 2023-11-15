using System.Linq;
using System.Threading.Tasks;
using TasksProject.DTOs;
using TasksProject.EF;
using TasksProject.Stores;

namespace TasksProject.Commands
{
    public class MarkAsDoneCommand : AsyncCommandBase
    {
        private readonly SelectedTaskStore _selectedTaskStore;
        
        private readonly DbContextFactory _dbContextFactory;

        public override async Task ExecuteAsync(object parameter)
        {
                using(DataContext context = _dbContextFactory.Create())
                {
                    TaskDTO taskDTO = context.Tasks.FirstOrDefault(t => t.Id == _selectedTaskStore.SelectedTask.Id);
                    if(taskDTO.IsDone == false) taskDTO.IsDone = true;
                    else taskDTO.IsDone = false;                    
                    context.SaveChanges();
                }
            
            _selectedTaskStore.SelectedTask = null;
            
        }
        public MarkAsDoneCommand(SelectedTaskStore selectedTaskStore) 
        {
            _selectedTaskStore = selectedTaskStore;
            
            _dbContextFactory = new();
        }

    }
}
