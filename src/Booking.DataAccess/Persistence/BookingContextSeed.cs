using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataAccess.Persistence
{
    public static class BookingContextSeed
    {
        public static async Task SeedDatabaseAsync(BookingContext context, UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser { UserName = "admin", Email = "admin@gmail.com" };
                await userManager.CreateAsync(user, "admin123");
            }
            await context.SaveChangesAsync();
        }
    }
}
