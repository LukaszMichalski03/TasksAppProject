using System.Windows.Input;
using TasksProject.Commands;
using TasksProject.Stores;

namespace TasksProject.ViewModels
{
    public class FormDetailsMainViewModel : ViewModelBase
    {
        private readonly DetailsFormNavigationStore _detailsFormNavigationStore;
        private readonly SelectedUserStore _selectedUserStore;

        public ViewModelBase CurrentDetailsFormViewModel => _detailsFormNavigationStore.DetailsFormViewModel;

        

        public ICommand NavigateToDetailsCommand { get; }
        public ICommand NavigateToTasksCommand { get; }
        public ICommand NavigateToAddTaskCommand { get; }

        public FormDetailsMainViewModel(DetailsFormNavigationStore detailsFormNavigationStore, SelectedUserStore selectedUserStore) 
        {
            _detailsFormNavigationStore = detailsFormNavigationStore;
            _selectedUserStore = selectedUserStore;
            

            NavigateToDetailsCommand = new NavigateFormCommand<FormUserDetailsViewModel>(_detailsFormNavigationStore, () => new FormUserDetailsViewModel(_selectedUserStore));
            NavigateToTasksCommand = new NavigateFormCommand<FormUsersTasksViewModel>(_detailsFormNavigationStore, () => new FormUsersTasksViewModel(_selectedUserStore, _detailsFormNavigationStore));
            NavigateToAddTaskCommand = new NavigateFormCommand<FormAddTaskViewModel>(_detailsFormNavigationStore, () => new FormAddTaskViewModel(_selectedUserStore));
            _detailsFormNavigationStore.CurrentDetailsFormChanged += onDetailsFormViewModelChanged;
            
        }
        protected override void Dispose()
        {
            _detailsFormNavigationStore.CurrentDetailsFormChanged -= onDetailsFormViewModelChanged;
            base.Dispose();
        }
        private void onDetailsFormViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentDetailsFormViewModel));
        }
    }
}
