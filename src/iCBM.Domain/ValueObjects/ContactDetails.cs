namespace iCBM.Domain.ValueObjects
{
    public class ContactDetails
    {
        public string AddressLine1 { get; private set; }
        public string AddressLine2 { get; private set; }
        public string Zipcode { get; private set; }
        public string City { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }

        public ContactDetails(string addressLine1, string addressLine2, string zipcode, string city, string phoneNumber, string emailAddress)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Zipcode = zipcode;
            City = city;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }
    }
}
