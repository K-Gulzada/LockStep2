using LockStep2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep2.Library.Domain.DAO.Common
{
    public class BookComment : BaseModel
    {
        public string Email { get; set; }
        public Book Book { get; set; }
        public string Description { get; set; }
        public BookVote BookVote { get; set; }
    }
}
