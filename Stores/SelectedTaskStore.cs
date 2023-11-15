using System;
using TasksProject.DTOs;

namespace TasksProject.Stores
{
    public class SelectedTaskStore
    {
        private TaskDTO? _selectedTask;
        public TaskDTO? SelectedTask
        {
            get
            {
                return _selectedTask;
            }
            set
            {
                _selectedTask = value;
                OnSelectedTaskChanged();
            }
        }

        public event Action SelectedTaskChanged;
        private void OnSelectedTaskChanged()
        {
            SelectedTaskChanged?.Invoke();
        }
    }
}

