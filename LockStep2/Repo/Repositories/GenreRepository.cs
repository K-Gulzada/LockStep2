using LockStep2.Models;
using LockStep2.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LockStep2.Repo.Repositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context) { }
    }
}