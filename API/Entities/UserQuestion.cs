﻿namespace API.Entities
{
    public class UserQuestion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
    }
}