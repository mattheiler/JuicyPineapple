using System;

namespace JuicyPineapple.Core
{
    public class OrganizationMembership
    {
        private OrganizationMembership()
        {
        }

        public OrganizationMembership(User user) => User = user;

        public virtual Organization Organization { get; private set; }

        public virtual Guid OrganizationId { get; private set; }

        public virtual User User { get; private set; }

        public virtual Guid UserId { get; private set; }
    }
}