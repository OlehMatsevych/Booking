using Booking.Core.Common;
using Booking.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.DataAccess.Persistence
{
    public class BookingContext: IdentityDbContext<ApplicationUser>
    {
        public BookingContext(DbContextOptions<BookingContext> options): base(options)
        {}
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentProvider> ApartmentProviders { get; set; }
        public DbSet<ApartmentRequest> ApartmentRequests { get; set; }
        public DbSet<ApartmentReview> ApartmentReviews { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomDetails> RoomsDetails { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public async new Task<int> SaveChangesAsync(CancellationToken token = new CancellationToken()) 
        {
            foreach (var entry in ChangeTracker.Entries<IChangeEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedOn = DateTime.Now;
                        break;
                }
            }

            return await base.SaveChangesAsync(token);
        }
        //TODO: ADD Dispose
    }
}
