using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TasksProject.DTOs;
using TasksProject.Queries;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class UsersListingViewModel : ViewModelBase
    {
        private ObservableCollection<UsersListingItemViewModel> _usersListingItemViewModels;
        private readonly CurrentUserStore _currentUserStore;
        private readonly SelectedUserStore _selectedUserStore;
        private readonly NavigationStore _navigationStore;

        public UserDTO? SelectedUser => _selectedUserStore.SelectedUser;
        public UserDTO CurrentUser => _currentUserStore.CurrentUser;

        private List<UserDTO> _users;

        
        public ObservableCollection<UsersListingItemViewModel> UsersListingItemViewModels
        {
            get { return _usersListingItemViewModels; }
            set
            {
                if (_usersListingItemViewModels != value)
                {
                    _usersListingItemViewModels = value;
                   
                }
            }
        }

        public UsersListingItemViewModel? SelectedUserListingItemViewModel
        {
            get
            {
                return _usersListingItemViewModels
                    .FirstOrDefault(u => u.User?.Id == _selectedUserStore.SelectedUser?.Id);
            }
            set
            {
                if(value?.User != _selectedUserStore.SelectedUser)
                {
                    _selectedUserStore.SelectedUser = value?.User;
                }
                
            }
        }

        public UsersListingViewModel(CurrentUserStore currentUserStore, SelectedUserStore selectedUserStore, NavigationStore navigationStore)
        {
            _usersListingItemViewModels = new ObservableCollection<UsersListingItemViewModel>();            
            _currentUserStore = currentUserStore;
            _selectedUserStore = selectedUserStore;
            _navigationStore = navigationStore;
            _users = new();
            _currentUserStore.CurrentUserChanged += OnCurrentUserChanged;
            _selectedUserStore.SelectedUserChanged += OnSelectedUserChanged;
            _navigationStore.CurrentViewModelChanged += _navigationStore_CurrentViewModelChanged;
            
        }
        protected override void Dispose()
        {
            _currentUserStore.CurrentUserChanged -= OnCurrentUserChanged;
            _selectedUserStore.SelectedUserChanged -= OnSelectedUserChanged;
            _navigationStore.CurrentViewModelChanged -= _navigationStore_CurrentViewModelChanged;
            base.Dispose();
        }
        private void _navigationStore_CurrentViewModelChanged()
        {
            if (_navigationStore.CurrentViewModel is AdminHomeViewModel)
            {
                Initialize();
            }
        }
        private void OnSelectedUserChanged()
        {
            OnPropertyChanged(nameof(SelectedUser));
            if (SelectedUser is null && CurrentUser is not null)
            {
                Initialize();
            }
        }

        private void OnCurrentUserChanged()
        {
            OnPropertyChanged(nameof(CurrentUser));
            Initialize();


        }
        public async Task Initialize()
        {
            _usersListingItemViewModels.Clear();
            
            _users.Clear();
            _users = await new GetUsers().Execute();
            

            foreach(var user in _users)
            {
                _usersListingItemViewModels.Add(new UsersListingItemViewModel(user));
            }            
        }
    }
}
