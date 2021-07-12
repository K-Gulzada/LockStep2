using LockStep2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep2.Library.Domain.DAO.Common
{
    public class BookGenre : BaseModel
    {
        public Book Book { get; set; }
        public Genre Genre { get; set; }
    }
}
