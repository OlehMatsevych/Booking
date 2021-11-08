using AutoMapper;
using Booking.Application.Models;
using LiqPay.SDK.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.Application.MappingProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentModel, LiqPayRequest>();
            CreateMap<LiqPayRequest, PaymentModel>();
        }
    }
}
