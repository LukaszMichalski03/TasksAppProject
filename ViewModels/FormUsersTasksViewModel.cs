using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TasksProject.DTOs;
using TasksProject.Queries;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class FormUsersTasksViewModel : ViewModelBase
    {
        private  ObservableCollection<TasksListingItemViewModel> _tasksListingItemViewModels;
        private readonly SelectedUserStore _selectedUserStore;
        private readonly DetailsFormNavigationStore _formNavigationStore;

        public UserDTO? SelectedUser => _selectedUserStore.SelectedUser;

        private List<TaskDTO> _userTasks;

        public ObservableCollection<TasksListingItemViewModel> UserTasksListingItemViewModels
        {
            get
            {
                return _tasksListingItemViewModels;
            }
            set
            {
                _tasksListingItemViewModels = value;
                OnPropertyChanged(nameof(UserTasksListingItemViewModels));
                if(value != null && value != new ObservableCollection<TasksListingItemViewModel> { } )
                {
                    Initialize();
                }
            }
        }

        public FormUsersTasksViewModel(SelectedUserStore selectedUserStore, DetailsFormNavigationStore formNavigationStore)
        {
           
            _tasksListingItemViewModels = new ObservableCollection<TasksListingItemViewModel>();
            _selectedUserStore = selectedUserStore;
            _formNavigationStore = formNavigationStore;
            _selectedUserStore.SelectedUserChanged += OnSelectedUserChanged;
            _formNavigationStore.CurrentDetailsFormChanged += OnFormViewModelChanged;           
        }

        protected override void Dispose()
        {
            _selectedUserStore.SelectedUserChanged -= OnSelectedUserChanged;
            _formNavigationStore.CurrentDetailsFormChanged -= OnFormViewModelChanged;
            base.Dispose();
        }

        private void OnFormViewModelChanged()
        {
            OnPropertyChanged(nameof(_formNavigationStore));
            if(_formNavigationStore.DetailsFormViewModel is FormUsersTasksViewModel)
            {
                Initialize();
            }
        }

        private void OnSelectedUserChanged()
        {
            OnPropertyChanged(nameof(SelectedUser));            
            Initialize();


        }
        private async Task Initialize()
        {
            _tasksListingItemViewModels.Clear();
            if (_selectedUserStore.SelectedUser != null)
            {
                _userTasks = await new GetUserTasksById(SelectedUser.Id).Execute();

                foreach (var Task in _userTasks)
                {
                    _tasksListingItemViewModels.Add(new TasksListingItemViewModel(Task, UserTasksListingItemViewModels));
                }
            }

        }
    }
}
