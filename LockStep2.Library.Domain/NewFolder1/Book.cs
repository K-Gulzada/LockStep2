﻿using LockStep2.Library.Domain.NewFolder1;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LockStep2.Models
{
    public class Book : BaseModel
    {

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public string Description { get; set; }

        public int Price { get; set; }
        public int Amount { get; set; }

        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}