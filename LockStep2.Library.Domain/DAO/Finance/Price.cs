using LockStep2.Library.Domain.DAO.Common;
using LockStep2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockStep2.Library.Domain.DAO.Finance
{
    public class Price : BaseModel
    {
        public Book Book { get; set; }
        public string Value { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
    }
}
