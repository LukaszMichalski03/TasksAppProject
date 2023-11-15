using System;
using TasksProject.ViewModels;

namespace TasksProject.Stores
{
    public class DetailsFormNavigationStore
    {
        public event Action CurrentDetailsFormChanged;

        private ViewModelBase _detailsFormViewModel;
        public ViewModelBase DetailsFormViewModel
        {
            get => _detailsFormViewModel;
            set
            {
                _detailsFormViewModel = value;
                OnDetailsFormChanged();
            }
        }

        private void OnDetailsFormChanged()
        {
            CurrentDetailsFormChanged?.Invoke();
        }
    }
}
