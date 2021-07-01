using LockStep2.Library.Domain.NewFolder1;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LockStep2.Models
{
    public class Genre : BaseModel
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }

    }
}