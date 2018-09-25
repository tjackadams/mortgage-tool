namespace Mortgage.Domain.Lenders
{
    using Common;

    public class NewProperty : ValueObject<NewProperty>
    {
        private NewProperty(int maxNumberOfFloors, bool acceptBuyToLet, decimal buyToLetMaxLoanToValue, bool acceptResidential, decimal residentialMaxLoanToValue)
        {
            MaxNumberOfFloors = maxNumberOfFloors;
            AcceptBuyToLet = acceptBuyToLet;
            BuyToLetMaxLoanToValue = buyToLetMaxLoanToValue;
            AcceptResidential = acceptResidential;
            ResidentialMaxLoanToValue = residentialMaxLoanToValue;
        }

        private NewProperty() { }

        public bool AcceptBuyToLet { get; private set; }
        public bool AcceptResidential { get; private set; }
        public decimal BuyToLetMaxLoanToValue { get; private set; }

        public int MaxNumberOfFloors { get; private set; }
        public decimal ResidentialMaxLoanToValue { get; private set; }

        public static NewProperty Create(int maxNumberOfFloors, bool acceptBuyToLet, decimal buyToLetMaxLoanToValue, bool acceptResidential, decimal residentialMaxLoanToValue)
        {
            return new NewProperty(maxNumberOfFloors, acceptBuyToLet, buyToLetMaxLoanToValue, acceptResidential, residentialMaxLoanToValue);
        }

        public static NewProperty Empty()
        {
            return new NewProperty(0, false, 0, false, 0);
        }
    }
}