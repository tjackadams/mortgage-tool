namespace Mortgage.Domain.Lenders
{
    using Common;

    public class UsedProperty : ValueObject<UsedProperty>
    {
        private UsedProperty(int maxNumberOfFloors, bool acceptBuyToLet, decimal buyToLetMaxLoanToValue, bool acceptResidential, decimal residentialMaxLoanToValue)
        {
            MaxNumberOfFloors = maxNumberOfFloors;
            AcceptBuyToLet = acceptBuyToLet;
            BuyToLetMaxLoanToValue = buyToLetMaxLoanToValue;
            AcceptResidential = acceptResidential;
            ResidentialMaxLoanToValue = residentialMaxLoanToValue;
        }

        private UsedProperty() { }

        public bool AcceptBuyToLet { get; private set; }
        public bool AcceptResidential { get; private set; }
        public bool HousingAndMultipleOccupancy { get; private set; }
        public decimal BuyToLetMaxLoanToValue { get; private set; }

        public int MaxNumberOfFloors { get; private set; }
        public decimal ResidentialMaxLoanToValue { get; private set; }

        public static UsedProperty Create(int maxNumberOfFloors, bool acceptBuyToLet, decimal buyToLetMaxLoanToValue, bool acceptResidential, decimal residentialMaxLoanToValue)
        {
            return new UsedProperty(maxNumberOfFloors, acceptBuyToLet, buyToLetMaxLoanToValue, acceptResidential, residentialMaxLoanToValue);
        }

        public static UsedProperty Empty()
        {
            return new UsedProperty(0, false, 0, false, 0);
        }
    }
}