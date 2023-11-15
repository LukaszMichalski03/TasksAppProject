using TasksProject.Commands;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class TaskDetailsViewModel : ViewModelBase
    {
        private readonly SelectedTaskStore _selectedTaskStore;

        public TaskDetailsViewModel(SelectedTaskStore selectedTaskStore)
        {
            _selectedTaskStore = selectedTaskStore;
            _selectedTaskStore.SelectedTaskChanged += _onSelectedTaskChanged;
            MarkAsDoneCommand = new(_selectedTaskStore);
            DeleteTaskCommand = new(_selectedTaskStore);
        }


        public MarkAsDoneCommand MarkAsDoneCommand { get;}
        public DeleteTaskCommand DeleteTaskCommand { get;}
        public string? Title => _selectedTaskStore.SelectedTask?.Title?? "";
        public string? Description => _selectedTaskStore.SelectedTask?.Description?? "";
        public bool? IsDone
        {
            get
            {
                if (_selectedTaskStore.SelectedTask != null) { return _selectedTaskStore.SelectedTask.IsDone; }
                else return null;
            }
            set
            {
                IsDone = _selectedTaskStore.SelectedTask.IsDone;
            }
        }
        protected override void Dispose()
        {
            _selectedTaskStore.SelectedTaskChanged -= _onSelectedTaskChanged;
            base.Dispose();
        }
        private void _onSelectedTaskChanged()
        {
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(IsDone));

        }
    }
}
