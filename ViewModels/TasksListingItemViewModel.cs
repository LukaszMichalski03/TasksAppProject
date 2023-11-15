using System;
using System.Collections.ObjectModel;
using TasksProject.Commands;
using TasksProject.DTOs;

namespace TasksProject.ViewModels
{
    public class TasksListingItemViewModel : ViewModelBase
    {
        public TasksListingItemViewModel(TaskDTO taskModel, ObservableCollection<TasksListingItemViewModel> userTasksListingItemViewModels = null)
        {
            TaskModel = taskModel;
            FastDeleteTaskCommand = new FastDeleteTaskCommand(taskModel.Id, userTasksListingItemViewModels);
        }

        public TaskDTO TaskModel { get; set; }

        public string Title => TaskModel.Title;
        public Guid Id => TaskModel.Id;
        

        public string Description => TaskModel.Description;
        public bool IsDone => TaskModel.IsDone;

        public FastDeleteTaskCommand FastDeleteTaskCommand { get; }

        
    }
}
