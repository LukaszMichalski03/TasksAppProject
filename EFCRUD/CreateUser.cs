using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TasksProject.DTOs;
using TasksProject.EF;

namespace TasksProject.EFCRUD
{
    public class CreateUser
    {
        private readonly DbContextFactory _contextFactory;

        public CreateUser(DbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(UserDTO user)
        {
            using (DataContext context = _contextFactory.Create())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

        }
        public async Task<bool> IsTakenAsync(string username)
        {
            using (DataContext context = _contextFactory.Create())
            {
                bool userExists = await context.Users.AnyAsync(u => u.Username == username);
                return userExists;
            }
        }
    }
}
