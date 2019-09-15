using Eventures.Domain;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Eventures.Data.Seeding
{
    public class EventuresRootAdminSeeder
    {
         
        //TODO: Find a way to do it. 

        //private readonly UserManager<User> userManager;

        //public EventuresRootAdminSeeder(UserManager<User> userManager)
        //{
        //    this.userManager = userManager;
        //}


        //public async Task SeedAsync()
        //{
        //    var admin = new User
        //    {
        //        UserName = "root",
        //        Email = "teodorccmp@gmail.com",
        //        FirstName = "Root",
        //        LastName = "Admin",
        //        UniqueCitizenNumber = "1234567890"
        //    };

        //    await userManager.CreateAsync(admin, "root");
        //    await userManager.AddToRoleAsync(admin, "Admin");
        //}
    }
}
