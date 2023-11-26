# Tasks App
**A desktop application written in WPF based on the MVVM pattern, utilizing Entity Framework Core. The functionality of the application includes:**
* Creating and logging into accounts stored in a database.
* Administrators can check the tasks currently assigned to individual users. Using the database, they can create and assign tasks to users, delete tasks, and remove user accounts.
* Users have access only to tasks assigned to them and can mark them as completed.
* Each account has the ability to change its login and password.

### Project Setup
To run this project you need to set your own **connection string** for the database, which can be found in [DataContext.cs](EF/DataContext.cs) file, line 16
### Project Structure
