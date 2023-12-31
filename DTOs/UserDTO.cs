﻿using System;
using System.Collections.Generic;

namespace TasksProject.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public List<TaskDTO> Tasks { get; set; }
    }
    
}
