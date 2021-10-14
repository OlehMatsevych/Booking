using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.DataAccess.Persistence
{
    public static class BookingContextSeed
    {
        public static async Task SeedDatabaseAsync(BookingContext context, UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser { UserName = "Admin", Email = "Admin@gmail.com" };
                await userManager.CreateAsync(user, "admin123");
            }
            await context.SaveChangesAsync();
        }
    }
}
