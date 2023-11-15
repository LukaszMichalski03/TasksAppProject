using TasksProject.Commands;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class FormUserDetailsViewModel : ViewModelBase
    {
        private readonly SelectedUserStore _selectedUserStore;

        public FormUserDetailsViewModel(SelectedUserStore selectedUserStore)
        {
            _selectedUserStore = selectedUserStore;
            _selectedUserStore.SelectedUserChanged += _onSelectedUserChanged;
            DeleteUserCommand = new(_selectedUserStore);
        }


        public DeleteUserCommand DeleteUserCommand { get; set; }
        public string? Username => _selectedUserStore.SelectedUser?.Username ?? "";
        protected override void Dispose()
        {
            _selectedUserStore.SelectedUserChanged -= _onSelectedUserChanged;
            base.Dispose();
        }
        private void _onSelectedUserChanged()
        {
            OnPropertyChanged(nameof(Username));
            
        }
    }
}
