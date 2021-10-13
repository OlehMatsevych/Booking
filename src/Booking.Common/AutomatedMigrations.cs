using Booking.DataAccess;
using Booking.DataAccess.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Common
{
    public class AutomatedMigrations
    {
        public static async Task MigrateAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<BookingContext>();
            if (context.Database.IsSqlServer())
            {
                await context.Database.MigrateAsync();
            }
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            await BookingContextSeed.SeedDatabaseAsync(context,userManager);
        }
    }
}
