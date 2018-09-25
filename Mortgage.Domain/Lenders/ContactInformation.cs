namespace Mortgage.Domain.Lenders
{
    using Common;

    public class ContactInformation : ValueObject<ContactInformation>
    {
        private ContactInformation(string name, string phoneNumber, bool directLine)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            DirectLine = directLine;
        }

        private ContactInformation() { }

        public static ContactInformation Create(string name, string phoneNumber, bool directLine)
        {
            return new ContactInformation(name, phoneNumber, directLine);
        }

        public static ContactInformation Empty()
        {
            return new ContactInformation(string.Empty, string.Empty, false);
        }

        public bool DirectLine { get; private set; }

        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }

        private bool IsEmpty()
        {
            return string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(PhoneNumber);
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                return "No Information";
            }

            if (DirectLine)
            {
                return string.IsNullOrEmpty(Name) ? $"{PhoneNumber} (D)" : $"{Name} - {PhoneNumber} (D)";
            }

            return string.IsNullOrEmpty(Name) ? $"{PhoneNumber}" : $"{Name} - {PhoneNumber}";
        }
    }
}