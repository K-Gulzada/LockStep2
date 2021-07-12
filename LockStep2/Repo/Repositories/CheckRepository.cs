using LockStep2.Library.Domain.DAO.Finance;
using LockStep2.Models;
using LockStep2.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LockStep2.Repo.Repositories
{
    public class CheckRepository : GenericRepository<Check>, ICheckRepository
    {
        public CheckRepository(ApplicationDbContext context) : base(context) { }
    }
}