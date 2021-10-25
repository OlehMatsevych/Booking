namespace Booking.Application.Models
{
    public class ApartmentRequestModel: BaseModel
    {
        public bool IsApproved { get; set; }
        public string Message { get; set; }
    }
}
