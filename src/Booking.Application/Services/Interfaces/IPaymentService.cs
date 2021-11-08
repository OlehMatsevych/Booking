using Booking.Application.Models;
using LiqPay.SDK.Dto;
using System.Threading.Tasks;

namespace Booking.Application.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<LiqPayResponse> PayAsync(PaymentModel model);
    }
}
