using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep2.Library.Domain.DTO.Common
{
    public class GenreVM
    {
        [Required]
        public string Name { get; set; }
    }
}
