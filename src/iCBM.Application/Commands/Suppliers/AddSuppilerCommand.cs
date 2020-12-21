using iCBM.Domain.Models;
using iCBM.Domain.ValueObjects;
using Misio.Common.CQRS.Commands.Abstractions;
using System;
using System.Threading.Tasks;

namespace iCBM.Application.Commands.Suppliers
{
    public class AddSupplierCommand : ICommand<Guid>
    {
        public string Name { get; }
        public string Description { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public string Zipcode { get; }
        public string City { get; }
        public string PhoneNumber { get; }
        public string EmailAddress { get; }

        public AddSupplierCommand(string name, string description, string addressLine1, string addressLine2, string zipcode, string city, string phoneNumber, string emailAddress)
        {
            Name = name;
            Description = description;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            Zipcode = zipcode;
            City = city;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }
    }

    public class AddSupplierCommandHandler : ICommandHandler<AddSupplierCommand, Guid>
    {
        private readonly ICbmContext _ctx;

        public AddSupplierCommandHandler(ICbmContext ctx)
        {
            _ctx = ctx;
        }

        public Task<Guid> Handle(AddSupplierCommand cmd)
        {
            var supplier = Supplier.New(cmd.Name, cmd.Description,
                new ContactDetails(cmd.AddressLine1, cmd.AddressLine2, cmd.Zipcode, cmd.City, cmd.PhoneNumber,
                    cmd.EmailAddress));

            _ctx.Suppliers.Add(supplier);

            return Task.FromResult(supplier.Id);
        }
    }
}
