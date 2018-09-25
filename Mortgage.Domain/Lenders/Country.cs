namespace Mortgage.Domain.Lenders
{
    using System;
    using Common;

    public class Country : Entity<string>
    {
        private Country()
        {
        }

        public string Code { get; private set; }

        public static Country Create(string name, string code)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(name);
            if (string.IsNullOrEmpty(code)) throw new ArgumentNullException(code);

            return new Country
            {
                Id = name,
                Code = code
            };
        }
    }
}