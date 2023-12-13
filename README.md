# **Tasks App**
**A desktop application written in WPF based on the MVVM pattern, utilizing Entity Framework Core. The functionality of the application includes:**
* Creating and logging into accounts stored in a database.
* Administrators can check the tasks currently assigned to individual users. Using the database, they can create and assign tasks to users, delete tasks, and remove user accounts.
* Users have access only to tasks assigned to them and can mark them as completed.
* Each account has the ability to change its login and password.

### Project Setup
Application uses SQlServer database so you must have it installed.\
To run this project you need to set your own **connection string** for the database, which can be found in [DataContext.cs](EF/DataContext.cs) file.
### Project Structure
#### Views and ViewModels
Views bind with ViewModels with the same name, only with the "*ViewModel*" suffix instead of "*View*". 
In the "*MainWindow.xaml*", the corresponding view is displayed depending on the value of *CurrentViewModel* in the [MainViewModel.cs](ViewModels/MainViewModel.cs).
#### Stores
* [NavigationStore.cs](Stores/NavigationStore.cs) - stores the view that is currently being displayed
* [CurrentUserStore.cs](Stores/CurrentUserStore.cs) - stores the user who is currently logged in
* [SelectedUserStore.cs](Stores/SelectedUserStore.cs) - stores the user from the list who is currently selected
* [SelectedTaskStore.cs](Stores/SelectedTaskStore.cs) - stores the task from the list that is currently selected
* [DetailsFormNavigationStore.cs](Stores/DetailsFormNavigationStore.cs) - stores the form that is currently being displayed
#### Entity Framework Core
In the ***DTOs*** folder, there are classes **TaskDTO.cs** and **UserDTO.cs** that define database tables.\
In the ***EF*** folder, there is a **DataContext.cs** inheriting from **DbContext**, where the connection string is located, and the relationship between database tables is described. Additionally, there is a **DbContextFactory.cs** that creates new DbContexts.
#### View Models Structures
* AdminHomeViewModel
    * UsersListingViewModel
        * UsersListingItemViewModel
    * FormDetailsMainViewModel
        * FormAddTaskViewModel
        * FormUserDetailsViewModel
        * FormAddTaskViewModel
* HomeViewModel
    * TasksListingViewModel
        * TasksListingItemViewModel
    * TaskDetailsViewModel
* RegisterViewModel
* LoginViewModel
* ProfileViewModel
#### Commands
Commands are inheriting from **ICommand**.\
The logic of commands is based on making changes to the database and modifying values in stores. In ViewModels, if necessary, when the values in stores change, the corresponding elements are refreshed.
