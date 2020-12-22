using System;
using iCBM.Domain.Models;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;

namespace iCBM.Application.Dtos
{
    public class SupplierDto : IMapFrom<Supplier>
    {
        public Guid Id { get; }
        public string Name { get;  }
        public string Description { get;  }

        public ContactDetailsDto ContactDetails { get; }

        public SupplierDto(Guid id, string name, string description, ContactDetailsDto contactDetails)
        {
            Id = id;
            Name = name;
            Description = description;
            ContactDetails = contactDetails;
        }
    }
}