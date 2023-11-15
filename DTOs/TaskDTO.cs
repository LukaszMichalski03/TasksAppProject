using System;
using TasksProject.Models;

namespace TasksProject.DTOs
{
    public class TaskDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserDTO User { get; set; }
        public string Title { get; set; }        
        public PriorityEnum Priority { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}
