using AutoMapper;
using Booking.Application.Constants;
using Booking.Application.Exceptions;
using Booking.Application.Helpers;
using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using Booking.DataAccess.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IApartmentRequestRepository _requestsRepository;
        private readonly IUserService _userService;
        private readonly IAdminRepository _repository;
        private readonly IMapper _mapper;
        public AdminService(IAdminRepository repository, IMapper mapper, IApartmentRequestRepository requestsRepository, IUserService userService)
        {
            _repository = repository;
            _requestsRepository = requestsRepository;
            _mapper = mapper;
            _userService = userService;
        }
        public OperationStatus ApproveRequest(ApartmentRequestModel request)
        {
            if (request == null)
            {
                throw new EmptyObjectException(AdminErrorMessages.EmptyRequestModel);
            }
            var requestEntity = _requestsRepository.GetWhere(x => x.Id == request.Id).FirstOrDefault();
            requestEntity.IsApproved = true;
            return new OperationStatus() { IsSuccesed = true, Message = "OK 200" };
        }

        public async Task<OperationStatus> BlockUser(UserModel user)
        {
            if (user == null)
            {
                throw new EmptyObjectException(AdminErrorMessages.EmptyRequestModel);
            }
            await _userService.DeleteUserAsync(user.Id);
            return new OperationStatus() { IsSuccesed = true, Message = "OK 200" };
        }
    }
}
