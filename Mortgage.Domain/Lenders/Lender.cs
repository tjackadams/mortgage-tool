namespace Mortgage.Domain.Lenders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class Lender : AggregateRoot<Guid>
    {
        private readonly HashSet<LenderCountry> _countries = new HashSet<LenderCountry>();

        private Lender()
        {
        }

        public bool AcceptInterestOnly { get; set; }

        public List<LenderCountry> AllowedCountries => Countries
            .Where(c => c.Allowed)
            .ToList();

        public Citizenship Citizenship { get; private set; }

        public IEnumerable<LenderCountry> Countries => _countries?.ToList();
        public string CriteriaUrl { get; private set; }

        public bool FirstTimeBuyer { get; private set; }
        public decimal InterestOnlyMaxLoanToValue { get; set; }

        public string LenderUrl { get; private set; }

        public int MaximumAge { get; private set; }

        public decimal MinimumIncome { get; private set; }

        public string Name { get; private set; }

        public NewProperty NewProperty { get; private set; }
        public string Notes { get; set; }

        public ContactInformation PrimaryContactInformation { get; private set; }
        public string RatesUrl { get; private set; }

        public List<LenderCountry> SanctionedCountries => Countries
            .Where(c => !c.Allowed)
            .ToList();

        public ContactInformation SecondaryContactInformation { get; private set; }

        public SelfEmployment SelfEmployment { get; private set; }

        public UsedProperty UsedProperty { get; private set; }

        public void AcceptFirstTimeBuyer(bool value)
        {
            FirstTimeBuyer = value;
        }

        public void AcceptOther()
        {
            Citizenship = Citizenship.Other;
        }

        public void AcceptUkOnly()
        {
            Citizenship = Citizenship.UnitedKingdom;
        }

        public void AddCountry(Country country)
        {
            if (_countries.Any(c => c.Name.Equals(country.Id)))
            {
                return;
            }

            _countries.Add(new LenderCountry(country.Id, Id));
        }

        public static Lender Create(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(Name));
            }

            Lender lender = new Lender
            {
                Name = name,
                NewProperty = NewProperty.Empty(),
                PrimaryContactInformation = ContactInformation.Empty(),
                SecondaryContactInformation = ContactInformation.Empty(),
                SelfEmployment = SelfEmployment.Empty(),
                UsedProperty = UsedProperty.Empty()
            };

            lender.DomainEvents.Add(new NewLenderEvent(lender));

            return lender;
        }
    }
}