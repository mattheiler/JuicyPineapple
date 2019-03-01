using System;
using System.Linq;
using JuicyPineapple.Core;
using JuicyPineapple.Data;

namespace JuicyPineapple.WebApi
{
    public class Query
    {
        private readonly JuicyPineappleDbContext _context;

        public Query(JuicyPineappleDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public Organization GetOrganization(Guid id) => _context.Organizations.Find(id);

        public IQueryable<Organization> GetOrganizations() => _context.Organizations;

        public User GetUser(string id) => _context.Users.Find(id);

        public IQueryable<User> GetUsers() => _context.Users;
    }
}