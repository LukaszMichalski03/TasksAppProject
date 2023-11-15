using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TasksProject.DTOs;
using TasksProject.EF;
using TasksProject.ViewModels;

namespace TasksProject.Commands
{
    public class FastDeleteTaskCommand : AsyncCommandBase
    {
        private readonly DbContextFactory _contextFactory;
        private readonly Guid _id;
        private readonly ObservableCollection<TasksListingItemViewModel> userTasksListingItemViewModels;

        public override async Task ExecuteAsync(object parameter)
        {
            using (DataContext context = _contextFactory.Create())
            {
                TaskDTO taskDTO = context.Tasks.FirstOrDefault(t => t.Id == _id);
                
                context.Tasks.Remove(taskDTO);
                context.SaveChanges();
            }
            foreach (var element in userTasksListingItemViewModels)
            {
                if (element.Id == _id) userTasksListingItemViewModels.Remove(element);
            }
        }
        public FastDeleteTaskCommand(Guid id, ObservableCollection<ViewModels.TasksListingItemViewModel> userTasksListingItemViewModels)
        {            
            _contextFactory = new();
            this._id = id;
            this.userTasksListingItemViewModels = userTasksListingItemViewModels;
        }


    }
}
