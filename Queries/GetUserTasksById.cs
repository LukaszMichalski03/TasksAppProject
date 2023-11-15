using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksProject.DTOs;
using TasksProject.EF;

namespace TasksProject.Queries
{
    public class GetUserTasksById
    {
        private readonly DbContextFactory _contextFactory;
        private readonly Guid _currentUserId;
        public GetUserTasksById(Guid id)
        {
            _contextFactory = new DbContextFactory();
            _currentUserId = id;
        }

        public async Task<List<TaskDTO>> Execute()
        {
            using (DataContext context = _contextFactory.Create())
            {
                List<TaskDTO> tasksForUser = context.Users
                    .Where(user => user.Id == _currentUserId)
                    .SelectMany(user => user.Tasks)
                    .ToList();

                return tasksForUser;
            }

        }

    }
}
