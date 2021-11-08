using AutoMapper;
using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using LiqPay.SDK;
using LiqPay.SDK.Dto;
using System.Threading.Tasks;

namespace Booking.Application.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly IMapper _mapper;
        public PaymentService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<LiqPayResponse> PayAsync(PaymentModel model)
        {
            var request = _mapper.Map<LiqPayRequest>(model);
            var liqPayClient = new LiqPayClient("publicKey","privateKey");
            var response = await liqPayClient.RequestAsync("request", request);
            return response;
        }
    }
}
