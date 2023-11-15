using System.Windows;
using TasksProject.Stores;
using TasksProject.ViewModels;

namespace TasksProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            CurrentUserStore currentUserStore = new CurrentUserStore();
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new LoginViewModel(navigationStore, currentUserStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
