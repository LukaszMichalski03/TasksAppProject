namespace TasksProject.EF
{
    public class DbContextFactory
    {
        public DataContext Create()
        {
            return new DataContext();
        }
    }
}
