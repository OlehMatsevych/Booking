namespace Booking.Common
{
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
        public bool UseInMemoryDatabase { get; internal set; }
    }
}
