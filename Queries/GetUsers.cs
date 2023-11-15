using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksProject.DTOs;
using TasksProject.EF;

namespace TasksProject.Queries
{
    public class GetUsers
    {
        private readonly DbContextFactory _contextFactory;
        
        public GetUsers()
        {
            _contextFactory = new DbContextFactory();
            
        }

        public async Task<List<UserDTO>> Execute()
        {
            using (DataContext context = _contextFactory.Create())
            {
                List<UserDTO> tasksForUser = context.Users
                    .Where(user => user.IsAdmin == false)
                    .ToList();


                return tasksForUser;
            }

        }
    }
}
