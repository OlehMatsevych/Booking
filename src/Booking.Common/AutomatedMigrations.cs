using Booking.DataAccess;
using Booking.DataAccess.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Common
{
    public static class AutomatedMigrations
    {
        public static async Task MigrateAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<BookingContext>();
            var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                await context.Database.MigrateAsync();
            }

            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            await BookingContextSeed.SeedDatabaseAsync(context,userManager);
        }
    }
}
