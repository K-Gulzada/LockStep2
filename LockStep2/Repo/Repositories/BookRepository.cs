using LockStep2.Models;
using LockStep2.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LockStep2.Repo.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }
    }

}