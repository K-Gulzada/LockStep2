using LockStep2.Library.Domain.NewFolder1;
using LockStep2.Models;
using LockStep2.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LockStep2.Repo.Repositories
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context) { }
    }
}