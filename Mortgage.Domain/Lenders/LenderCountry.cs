namespace Mortgage.Domain.Lenders
{
    using System;
    using Common;

    public class LenderCountry : Entity<Guid>
    {
        public LenderCountry(string name, Guid lenderId, bool allowed = true)
        {
            Allowed = allowed;
            LenderId = lenderId;
            Name = name;
        }

        public bool Allowed { get; private set; }

        public Guid LenderId { get; private set; }
        public Lender Lender { get; set; }

        public string Name { get; set; }

        public void Allow()
        {
            Allowed = true;
        }

        public void Sanction()
        {
            Allowed = false;
        }
    }
}