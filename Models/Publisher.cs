﻿using System.ComponentModel.DataAnnotations;

namespace Pop_Claudia_Lab2.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        public string? PublisherName { get; set; } = string.Empty;
        public ICollection<Book>? Books { get; set; } 
    }
}
