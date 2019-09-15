using Eventures.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Data.Seeding
{
    public class EventuresUserRolesSeeder : ISeeder
    {
        public void Seed(EventuresDbContext context)
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
