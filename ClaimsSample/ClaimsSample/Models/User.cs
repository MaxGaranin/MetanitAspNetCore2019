﻿namespace ClaimsSample.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        
        // год рождения пользователя
        public int Year { get; set; }
    }
}