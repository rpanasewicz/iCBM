using iCBM.Domain.Models;
using Misio.Domain.Types;
using System;

namespace iCBM.Domain.Common
{
    public abstract class OwnedEntity : EntityBase, IOwnedEntity
    {
        public Guid OwnerId { get; protected set; }
        public User Owner { get; protected set; }
    }

    public abstract class EntityBase : Entity, IAuditableEntity, IIdentifiableEntity, ISoftDeleteEntity
    {
        public Guid Id { get; protected set; }

        public string CreatedBy { get; protected set; }
        public string ModifiedBy { get; protected set; }
        public DateTime CreatedOn { get; protected set; }
        public DateTime ModifiedOn { get; protected set; }
        public bool IsDeleted { get; protected set; }
    }
}
