using LockStep2.Library.Domain.DAO.Common;
using LockStep2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep2.Library.Domain.DAO.Finance
{
    public class Check : BaseModel
    {
        public string IdRequest { get; set; }
        public string Email { get; set; }
        public Book Book { get; set; }
        public int Status { get; set; }
    }
}
