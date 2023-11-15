using System;
using TasksProject.Stores;
using TasksProject.ViewModels;

namespace TasksProject.Commands
{
    public class NavigateFormCommand<TViewModel> : CommandBase
        where TViewModel : ViewModelBase
    {
        private readonly DetailsFormNavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        public NavigateFormCommand(DetailsFormNavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.DetailsFormViewModel = _createViewModel();
        }
    }
}
