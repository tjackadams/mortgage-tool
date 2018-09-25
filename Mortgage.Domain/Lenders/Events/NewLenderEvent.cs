namespace Mortgage.Domain.Lenders
{
    using Common;

    public class NewLenderEvent : IDomainEvent
    {
        public NewLenderEvent(Lender lender)
        {
            Lender = lender;
        }

        public Lender Lender { get; set; }
    }
}