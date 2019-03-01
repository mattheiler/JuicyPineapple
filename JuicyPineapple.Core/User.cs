using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JuicyPineapple.Core
{
    public class User
    {
        public virtual Guid Id { get; private set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual ICollection<OrganizationMembership> Organizations { get; } = new HashSet<OrganizationMembership>();
    }
}