using LiqPay.SDK.Dto;
using LiqPay.SDK.Dto.Enums;
using System.Collections.Generic;

namespace Booking.Application.Models
{
    public class PaymentModel
    {
        public string Email { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentId { get; set; }
        public LiqPayRequestAction Action { get; set; }
        public List<LiqPayRequestGoods> Goods { get; set; }
    }
}
