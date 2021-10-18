using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Booking.DataAccess.Persistence
{
    public static class BookingContextSeed
    {
        public static async Task SeedDatabaseAsync(BookingContext context, UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser { UserName = "Admin", Email = "Admin@gmail.com" };
                await userManager.CreateAsync(user, "Admin123");
            }
            if (!context.Apartments.Any())
            {
                context.Apartments.Add(new Core.Entities.Apartment() { Id = Guid.NewGuid() });
                context.Apartments.Add(new Core.Entities.Apartment() { Id = Guid.NewGuid() });
                context.Apartments.Add(new Core.Entities.Apartment() { Id = Guid.NewGuid() });
                context.Apartments.Add(new Core.Entities.Apartment() { Id = Guid.NewGuid() });
            }
            if (!context.Rooms.Any())
            {
                context.Rooms.Add(new Core.Entities.Room() { Id = Guid.NewGuid(), IsFree = false });
                context.Rooms.Add(new Core.Entities.Room() { Id = Guid.NewGuid(), IsFree = true });
                context.Rooms.Add(new Core.Entities.Room() { Id = Guid.NewGuid(), IsFree = true });
                context.Rooms.Add(new Core.Entities.Room() { Id = Guid.NewGuid(), IsFree = false });
                context.Rooms.Add(new Core.Entities.Room() { Id = Guid.NewGuid(), IsFree = true });
            }
            if (!context.Locations.Any())
            {
                context.Locations.Add(new Core.Entities.Location() { Id = Guid.NewGuid(), Country = "UK", City = "London" });
                context.Locations.Add(new Core.Entities.Location() { Id = Guid.NewGuid(), Country = "Ukraine", City = "Lviv" });
                context.Locations.Add(new Core.Entities.Location() { Id = Guid.NewGuid(), Country = "Ukraine", City = "Kyiv" });
                context.Locations.Add(new Core.Entities.Location() { Id = Guid.NewGuid(), Country = "USA", City = "New-York" });
                context.Locations.Add(new Core.Entities.Location() { Id = Guid.NewGuid(), Country = "USA", City = "Boston" });
            }
            await context.SaveChangesAsync();
        }
    }
}
