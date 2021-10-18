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
            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole()
                { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" });
                context.Roles.Add(new IdentityRole()
                { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" });
                context.Roles.Add(new IdentityRole()
                { Id = Guid.NewGuid().ToString(), Name = "ApartmentProvider", NormalizedName = "ApartmentProvider" });
            }
            if (userManager.Users.Count() < 3)
            {
                var admin = new ApplicationUser { UserName = "Admin", Email = "Admin@gmail.com" };
                var user = new ApplicationUser { UserName = "User", Email = "User@gmail.com" };
                var apartmentProvider = new ApplicationUser { UserName = "ApartmentProvider", Email = "ApartmentProvider@gmail.com" };

                await userManager.CreateAsync(admin, "Admin123");
                await userManager.CreateAsync(user, "User123");
                await userManager.CreateAsync(apartmentProvider, "ApartmentProvider123");
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
