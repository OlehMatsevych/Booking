using AutoMapper;
using Booking.Application.MappingProfiles;
using Booking.Application.Models.Apartment;
using Booking.Application.Services.Apartment;
using Booking.Core.Entities;
using Booking.DataAccess.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Application.UnitTests.Services
{
    public class ApartmentServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _repository;
        private readonly IApartmentService _service;
        public ApartmentServiceTests()
        {
            _mapper = new MapperConfiguration(config => {
                config.AddMaps(typeof(ApartmentProfile));
            }).CreateMapper();
            _repository = Substitute.For<IApartmentRepository>();
            _service = new ApartmentService(_repository,_mapper);
        }

        [Fact]
        public async Task CreateApartmentsAsync_ReturnNewApartment()
        {
            //Arrange
            var apartmentModel = new ApartmentModel()
            {
                Id = Guid.NewGuid(),
                Location = new Core.Entities.Location() { 
                    Id = Guid.NewGuid(),
                    Country = "USA",
                    City = "New-York"
                }
            };
            
            //Act
            var result = await _service.CreateApartmentsAsync(apartmentModel);
            
            //Assert
            Assert.Equal(result, apartmentModel);

        }
        [Fact]
        public async Task DeleteApartmentsAsync_DeleteApartmentById()
        {
            //Arrange
            Guid testId = Guid.NewGuid();
            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment() { Id = Guid.NewGuid() },
                new Apartment() { Id = Guid.NewGuid() },
                new Apartment() { Id = testId }
            };

            var query = apartments.Where(x=>x.Id == x.Id).AsQueryable();
            _repository.GetWhere(Arg.Any<Expression<Func<Apartment,bool>>>()).Returns(query);

            //Act
            var result = await _service.DeleteApartmentsAsync(testId);
            
            //Assert
            var expectedResult = JsonSerializer.Serialize(
                new
                {
                    Success = true
                });
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public async Task GetApartments_ReturnListOfApartments()
        {
            //Arrange
            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment() { Id = Guid.NewGuid() },
                new Apartment() { Id = Guid.NewGuid() },
                new Apartment() { Id = Guid.NewGuid() }
            };

            var query = apartments.Where(x => x.Id == x.Id).AsQueryable();
            _repository.GetAll(Arg.Any<Expression <Func<Apartment, object>>[]>()).Returns(query);
            
            //Act
            var result =  _service.GetApartments();
           
            //Assert
            Assert.Equal(apartments.Count, result.Count());
        }
        [Fact]
        public async Task GetApartmentsByLocationAsync_ReturnListOfApartments()
        {
            //Arrange
            Guid testId = Guid.NewGuid();
            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment() { 
                    Id = Guid.NewGuid() ,
                    Location = new Location(){
                        Id = testId,
                        Country = "Russian",
                        City = "Moscow"
                    }
                },
                new Apartment() { 
                    Id = Guid.NewGuid() ,
                    Location = new Location(){
                        Id = Guid.NewGuid(),
                        Country = "Russian",
                        City = "Saint-Peterburg"
                    }
                },
                new Apartment() {
                    Id = Guid.NewGuid(),
                    Location = new Location(){
                        Id = Guid.NewGuid(),
                        Country = "Russian",
                        City = "Kazan"
                    }
                }
            };

            Location location = new Location()
            {
                Id = testId,
                Country = "Russian",
                City = "Moscow"
            };

            var query = apartments.Where(x => x.Location.Equals(location)).AsQueryable();
            _repository.GetAll(Arg.Any<Expression<Func<Apartment, object>>[]>()).Returns(query);

            //Act
            var result = _service.GetApartmentsByLocationAsync(location);
            //Assert
            Assert.Equal(testId, result.First().Id);

        }
        [Fact]
        public async Task UpdateApartmentsAsync_ReturnUpdatedApartment()
        {
            //TODO: Create Constants
            //Arrange
            Guid testId = Guid.NewGuid();
            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment() {
                    Id = testId ,
                    Location = new Location(){
                        Id = Guid.NewGuid(),
                        Country = "Russian",
                        City = "Moscow"
                    }
                },
                new Apartment() {
                    Id = Guid.NewGuid() ,
                    Location = new Location(){
                        Id = Guid.NewGuid(),
                        Country = "Russian",
                        City = "Saint-Peterburg"
                    }
                },
                new Apartment() {
                    Id = Guid.NewGuid(),
                    Location = new Location(){
                        Id = Guid.NewGuid(),
                        Country = "Russian",
                        City = "Kazan"
                    }
                }
            };
            var updateApartment = new ApartmentModel()
            {
                Id = Guid.NewGuid(),
                Location = new Location()
                {
                    Id = Guid.NewGuid(),
                    Country = "Russian",
                    City = "Ryazan"
                }
            };

            var query = apartments.Where(x => x.Id == x.Id).AsQueryable();
            _repository.GetWhere(Arg.Any<Expression<Func<Apartment, bool>>>()).Returns(query);
            //Act
            var result = await _service.UpdateApartmentsAsync(testId, updateApartment);
            //Assert
            Assert.Equal(testId,result.Id);
        }
    }
}
