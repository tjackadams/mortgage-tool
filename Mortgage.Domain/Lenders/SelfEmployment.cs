namespace Mortgage.Domain.Lenders
{
    using Common;

    public class SelfEmployment : ValueObject<SelfEmployment>
    {
        private SelfEmployment(bool accept, decimal minimumIncome, int yearsBooks)
        {
            Accept = accept;
            MinimumIncome = minimumIncome;
            YearsBooks = yearsBooks;
        }

        private SelfEmployment() { }

        public bool Accept { get; private set; }
        public decimal MinimumIncome { get; private set; }
        public int YearsBooks { get; private set; }

        public static SelfEmployment Create(bool accept, decimal minimumIncome, int yearsBooks)
        {
            return new SelfEmployment(accept, minimumIncome, yearsBooks);
        }

        public static SelfEmployment Empty()
        {
            return new SelfEmployment(false, 0, 0);
        }
    }
}