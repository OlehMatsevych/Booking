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
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace Booking.Application.UnitTests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _repository;
        private readonly Mock<IReservationRepository> _reservationRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _service;

        public UserServiceTests()
        {
            _mapper = new MapperConfiguration(config => {
                config.AddMaps(typeof(ApartmentRequestProfile));
            }).CreateMapper();
            _repository = new Mock<IUserRepository>();
            _reservationRepository = new Mock<IReservationRepository>();

            _service = new UserService(_repository.Object,_mapper,_reservationRepository.Object, null);
        }
        [Fact]
        public async Task AddReservationTest_ReturnSuccess()
        {
            // Arrange
            ReservationModel model = new ReservationModel()
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(7),
                ApartmentId = Guid.NewGuid(),
                RoomId = Guid.NewGuid()
            };

            // Act
            var result = await _service.AddReservation(model);

            // Assert 
            Assert.True(result.IsSuccesed);
        }
        [Fact]
        public async Task CancelReservationTest_ReturnSuccess()
        {
            // Arrange
            var testId = Guid.NewGuid();
            var reservations = new List<Reservation>()
            {
                new Reservation()
                { 
                    Id = testId,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Apartment = new Apartment(),
                    Room = new Room()
                },
                new Reservation()
                { 
                    Id = Guid.NewGuid(),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Apartment = new Apartment(),
                    Room = new Room()
                },
                new Reservation()
                {
                    Id = Guid.NewGuid(),
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Apartment = new Apartment(),
                    Room = new Room()
                },
            };
            var query = reservations.Where(x => x.Id == x.Id).AsQueryable();
            _reservationRepository.Setup(x => x.GetWhere(It.IsAny<Expression<Func<Reservation, bool>>>())).Returns(query);

            // Act
            var result = await  _service.CancelReservation(testId);

            // Assert 
            Assert.True(result.IsSuccesed);
        }
        [Fact]
        public async Task DeleteUserAsyncTest_ReturnSuccess()
        {
            // Arrange
            Guid testId = Guid.NewGuid();
            var expectedRequest = new Guest() { Id = testId, Name = "Test1", Surname = "Test1", Email = "Test1@test1.com", Password = "Qwerty123" };
            var requests = new List<Guest>()
            {
                 new Guest() { Id = testId, Name="Test1", Surname="Test1", Email="Test1@test1.com", Password="Qwerty123"},
                 new Guest() { Id = Guid.NewGuid(), Name="Test2", Surname="Test2", Email="Test2@test2.com", Password="Qwerty1233"},
                 new Guest() { Id = Guid.NewGuid(), Name="Test3", Surname="Test3", Email="Test3@test3.com", Password="Qwerty1234"},
            };
            var query = requests.Where(x => x.Id == testId).AsQueryable();
            _repository.Setup(x => x.GetWhere(It.IsAny<Expression<Func<Guest, bool>>>())).Returns(query);

            // Act
            var result = await _service.DeleteUserAsync(testId);

            // Assert 
            Assert.True(result.IsSuccesed);
        }
    }
}
