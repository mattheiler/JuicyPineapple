using System;
using System.Collections.Generic;

namespace JuicyPineapple.Core
{
    public class Organization
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Organization Parent { get; set; }

        public virtual Guid? ParentId { get; private set; }

        public virtual ICollection<Organization> Children { get; } = new HashSet<Organization>();

        public virtual ICollection<OrganizationMembership> Users { get; } = new HashSet<OrganizationMembership>();
    }
}
