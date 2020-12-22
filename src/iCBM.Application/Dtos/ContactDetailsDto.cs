using iCBM.Domain.ValueObjects;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;

namespace iCBM.Application.Dtos
{
    public class ContactDetailsDto : IMapFrom<ContactDetails>
    {
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public string Zipcode { get; }
        public string City { get; }
        public string PhoneNumber { get; }
        public string EmailAddress { get; }

        public ContactDetailsDto(string addressLine1, string addressLine2, string zipcode, string city, string phoneNumber, string emailAddress)
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