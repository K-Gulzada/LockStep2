using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep2.Library.Domain.DTO.Common
{
    public class AuthorVM
    {
        [Required]
        public string FullName { get; set; }
        public List<BookVM> Books { get; set; }
    }
}
