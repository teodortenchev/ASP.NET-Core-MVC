using Eventures.Domain;
using System.Linq;

namespace Eventures.Data.Seeding
{
    public class EventuresUserRolesSeeder : ISeeder
    {
        private readonly EventuresDbContext context;

        public EventuresUserRolesSeeder(EventuresDbContext context)
        {
            this.context = context;
        }


        public void Seed()
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new UserRole { Name = "Admin", NormalizedName = "ADMIN" });
                context.Roles.Add(new UserRole { Name = "User", NormalizedName = "USER" });
                context.SaveChanges();
            }
        }
    }
}
