using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TasksProject.DTOs;
using TasksProject.Queries;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class TasksListingViewModel : ViewModelBase
    {
        private ObservableCollection<TasksListingItemViewModel> _tasksListingItemViewModels;
        private readonly CurrentUserStore _currentUserStore;
        private readonly SelectedTaskStore _selectedTaskStore;
        private readonly NavigationStore _navigationStore;

        public UserDTO CurrentUser => _currentUserStore.CurrentUser;
        
        private List<TaskDTO> _userTasks;

        public ObservableCollection<TasksListingItemViewModel> TasksListingItemViewModels
        {
            get { return _tasksListingItemViewModels; }
            set
            {
                if (_tasksListingItemViewModels != value)
                {
                    _tasksListingItemViewModels = value;

                }
            }
        }
        public TasksListingItemViewModel? SelectedTaskListingItemViewModel
        {
            get
            {
                return _tasksListingItemViewModels
                    .FirstOrDefault(u => u.TaskModel?.Id == _selectedTaskStore.SelectedTask?.Id);
            }
            set
            {
                if (value?.TaskModel != _selectedTaskStore.SelectedTask)
                {
                    _selectedTaskStore.SelectedTask = value?.TaskModel;
                }

            }
        }
        public TasksListingViewModel(CurrentUserStore currentUserStore, SelectedTaskStore selectedTaskStore, NavigationStore navigationStore)
        {
            _tasksListingItemViewModels = new ObservableCollection<TasksListingItemViewModel>();
            _currentUserStore = currentUserStore;
            _selectedTaskStore = selectedTaskStore;
            this._navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;
            _currentUserStore.CurrentUserChanged += OnCurrentUserChanged;
            _selectedTaskStore.SelectedTaskChanged += OnSelectedTaskChanged;
            
        }

        protected override void Dispose()
        {
            _navigationStore.CurrentViewModelChanged -= _navigationStore_CurrentViewModelChanged;
            _currentUserStore.CurrentUserChanged -= OnCurrentUserChanged;
            _selectedTaskStore.SelectedTaskChanged -= OnSelectedTaskChanged;
            base.Dispose();
        }
        private void _navigationStore_CurrentViewModelChanged()
        {
            if (_navigationStore.CurrentViewModel is HomeViewModel)
            {
                Initialize();
            }
        }

        private void OnSelectedTaskChanged()
        {
            if (_selectedTaskStore.SelectedTask == null)
            {
                Initialize();
            }
        }

        private void OnCurrentUserChanged()
        {
            OnPropertyChanged(nameof(CurrentUser));
            if (CurrentUser != null)
            {
                Initialize();
            }

        }
        public async Task Initialize()
        {
            _tasksListingItemViewModels.Clear();
            if(CurrentUser is not null)
            {
                _userTasks = await new GetUserTasksById(CurrentUser.Id).Execute();
                foreach (var Task in _userTasks)
                {
                    _tasksListingItemViewModels.Add(new TasksListingItemViewModel(Task));
                }
            }         
        }
    }
}
