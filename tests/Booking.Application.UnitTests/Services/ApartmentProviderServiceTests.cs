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
using System.Threading.Tasks;
using Xunit;

namespace Booking.Application.UnitTests.Services
{
    public class ApartmentProviderServiceTests
    {
        private readonly Mock<IApartmentRequestRepository> _repository;
        private readonly IMapper _mapper;
        private readonly IApartmentProviderService _service;

        public ApartmentProviderServiceTests()
        {
            _repository = new Mock<IApartmentRequestRepository>();
            _mapper = new MapperConfiguration(config => {
                config.AddMaps(typeof(ApartmentRequestProfile));
            }).CreateMapper();
            _service = new ApartmentProviderService(_repository.Object, _mapper);
        }
        [Fact]
        public async Task CreateRequestTest_ReturnSuccess()
        {
            // Arrange
            ApartmentRequestModel model = new ApartmentRequestModel() {Id = Guid.NewGuid(), IsApproved = false, Message="Palace hotel need Booking service" };

            // Act
            var result = await _service.CreateRequest(model);

            // Assert 
            Assert.True(result.IsSuccesed);
        }
        [Fact]
        public void GetAllProvidersTest_ReturnList()
        {
            // Arrange
            var providerRequests = new List<ApartmentRequest>()
            {
                new ApartmentRequest(){Id=Guid.NewGuid(), IsApproved = true, Message="Test1"},
                new ApartmentRequest(){Id=Guid.NewGuid(), IsApproved = false, Message="Test2"},
                new ApartmentRequest(){Id=Guid.NewGuid(), IsApproved = false, Message="Test3"},
            };
            var query = providerRequests.Where(x => x.Id == x.Id).AsQueryable();

            _repository.Setup(x => x.GetAll(It.IsAny<Expression<Func<ApartmentRequest, object>>[]>())).Returns(query);
            
            // Act
            var requests = _service.GetAllRequests();

            // Assert 
            Assert.Equal(providerRequests.Count,requests.Count());
        }
    }
}
