using AutoMapper;
using Booking.Application.MappingProfiles;
using Booking.Application.Models;
using Booking.Application.Services;
using Booking.Application.Services.Interfaces;
using Booking.Core.Entities;
using Booking.DataAccess.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Application.UnitTests.Services
{
    public class AdminServiceTests
    {
        private readonly Mock<IApartmentRequestRepository> _requestsRepository;
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;
        private readonly Mock<IAdminRepository> _repository;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly IMapper _mapper;


        public AdminServiceTests()
        {
            _mapper = new MapperConfiguration(config => {
                config.AddMaps(typeof(AdminProfile));
            }).CreateMapper();
            var reservationRepository = new Mock<IReservationRepository>();
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_userRepository.Object,_mapper, reservationRepository.Object);
            _repository = new Mock<IAdminRepository>();
            _requestsRepository = new Mock<IApartmentRequestRepository>();
            _adminService = new AdminService(_repository.Object, _mapper, _requestsRepository.Object, _userService);
        }
        [Fact]
        public async Task ApproveRequestTest_ReturnSuccess()
        {
            //Arrange
            Guid testId = Guid.NewGuid();
            var expectedRequest = new ApartmentRequest() { Id = testId, IsApproved = false, Message = "Test1" };
            var requests = new List<ApartmentRequest>()
            {
                new ApartmentRequest(){ Id = testId, IsApproved = false, Message = "Test1" },
                new ApartmentRequest(){ Id = Guid.NewGuid(), IsApproved = false, Message = "Test2" },
                new ApartmentRequest(){ Id = Guid.NewGuid(), IsApproved = false, Message = "Test3" },
            };
            var query = requests.Where(x => x.Id == testId).AsQueryable();
            _requestsRepository.Setup(x => x.GetWhere(It.IsAny<Expression<Func<ApartmentRequest, bool>>>())).Returns(query);

            //Act
            var result = await  _adminService.ApproveRequest(_mapper.Map<ApartmentRequestModel>(expectedRequest));

            //Assert
            Assert.True(result.IsSuccesed);
        }
        [Fact] 
        public async Task BlockUserTest_ReturnSuccess()
        {
            // Arrange
            Guid testId = Guid.NewGuid();
            var expectedRequest = new Guest() { Id = testId, Name="Test1", Surname="Test1", Email="Test1@test1.com", Password="Qwerty123"};
            var requests = new List<Guest>()
            {
                 new Guest() { Id = testId, Name="Test1", Surname="Test1", Email="Test1@test1.com", Password="Qwerty123"},
                 new Guest() { Id = Guid.NewGuid(), Name="Test2", Surname="Test2", Email="Test2@test2.com", Password="Qwerty1233"},
                 new Guest() { Id = Guid.NewGuid(), Name="Test3", Surname="Test3", Email="Test3@test3.com", Password="Qwerty1234"},
            };
            var query = requests.Where(x => x.Id == testId).AsQueryable();
            _userRepository.Setup(x => x.GetWhere(It.IsAny<Expression<Func<Guest, bool>>>())).Returns(query);

            // Act
            var result = await _adminService.BlockUser(_mapper.Map<UserModel>(expectedRequest));

            // Assert 
            Assert.True(result.IsSuccesed);
        }
    }
}
