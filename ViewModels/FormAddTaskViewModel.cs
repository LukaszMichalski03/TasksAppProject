using System;
using TasksProject.Commands;
using TasksProject.DTOs;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class FormAddTaskViewModel : ViewModelBase
    {
        private readonly SelectedUserStore _selectedUserStore;

        public UserDTO SelectedUser => _selectedUserStore.SelectedUser;

        public FormAddTaskViewModel(SelectedUserStore selectedUserStore)
        {
            _selectedUserStore = selectedUserStore;
            CreateTaskCommand = new CreateTaskCommand(this, _selectedUserStore);
            _selectedUserStore.SelectedUserChanged += _selectedUserStore_SelectedUserChanged;
        }        

        private string _title { get; set; }
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private string _description { get; set; }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string _priority { get; set; }
        
        public string Priority
        {
            get { return _priority; }
            set
            {
                _priority = value;
                OnPropertyChanged(nameof(Priority));            
            }
        }
        public Models.PriorityEnum PriorityEnum => (Models.PriorityEnum) Enum.Parse(typeof(Models.PriorityEnum), Priority);
        public CreateTaskCommand CreateTaskCommand { get; }

        protected override void Dispose()
        {
            _selectedUserStore.SelectedUserChanged -= _selectedUserStore_SelectedUserChanged;
            base.Dispose();
        }
        private void _selectedUserStore_SelectedUserChanged()
        {
            OnPropertyChanged(nameof(CreateTaskCommand));
        }

    }
}
