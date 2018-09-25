using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mortgage.Domain.Services
{
    using Infrastructure;
    using Lenders;

    public class LenderService
    {
        public Lender Create(string name)
        {
            var lender = Lender.Create(name);

            using (var db = new MortgageDbContext())
            {
                db.Lenders.Add(lender);
                db.SaveChanges();
            }

            return lender;
        }
    }
}
