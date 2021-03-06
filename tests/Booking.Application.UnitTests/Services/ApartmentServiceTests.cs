using AutoMapper;
using Booking.Application.Helpers;
using Booking.Application.MappingProfiles;
using Booking.Application.Models.Apartment;
using Booking.Application.Services.Apartment;
using Booking.Application.UnitTests.Constants;
using Booking.Core.Entities;
using Booking.DataAccess.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            _service = new ApartmentService(_repository,_mapper, null);
        }

        [Fact]
        public async Task CreateApartmentsAsync_ReturnNewApartment()
        {
            //Arrange
            var apartmentModel = new ApartmentModel()
            {
                Id = Guid.NewGuid(),
                Location = new Location() {
                    Id = Guid.NewGuid(),
                    Country = Countries.USA.ToString(),
                    City = Cities.New_York.ToString()
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
            var expectedResult = new OperationStatus() { IsSuccesed = true, Message = "OK 200" };
            Assert.Equal(expectedResult.IsSuccesed, result.IsSuccesed);
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
                        Country = Countries.Russian.ToString() ,
                        City = Cities.Moscow.ToString()
                    }
                },
                new Apartment() { 
                    Id = Guid.NewGuid() ,
                    Location = new Location(){
                        Id = Guid.NewGuid(),
                        Country = Countries.Russian.ToString(),
                        City = Cities.Saint_Peterburg.ToString()
                    }
                },
                new Apartment() {
                    Id = Guid.NewGuid(),
                    Location = new Location(){
                        Id = Guid.NewGuid(),
                        Country = Countries.Russian.ToString(),
                        City = Cities.Kazan.ToString()
                    }
                }
            };

            Location location = new Location()
            {
                Id = testId,
                Country = Countries.Russian.ToString(),
                City = Cities.Moscow.ToString()
            };

            var query = apartments.Where(x => x.Location.Id == location.Id).AsQueryable();
            _repository.GetWhere(Arg.Any<Expression<Func<Apartment, bool>>>()).Returns(query);

            //Act
            var result = _service.GetApartmentsByLocationAsync(location);
            //Assert
            Assert.Equal(testId, result.First().Location.Id);

        }
        [Fact]
        public async Task UpdateApartmentsAsync_ReturnUpdatedApartment()
        {
            //Arrange
            Guid testId = Guid.NewGuid();
            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment() {
                    Id = testId ,
                    Location = new Location(){
                        Id = Guid.NewGuid(),
                        Country = Countries.Russian.ToString(),
                        City = Cities.Moscow.ToString()
                    }
                },
                new Apartment() {
                    Id = Guid.NewGuid() ,
                    Location = new Location(){
                        Id = Guid.NewGuid(),
                        Country = Countries.Russian.ToString(),
                        City = Cities.Saint_Peterburg.ToString()
                    }
                },
                new Apartment() {
                    Id = Guid.NewGuid(),
                    Location = new Location(){
                        Id = Guid.NewGuid(),
                        Country = Countries.Russian.ToString(),
                        City = Cities.Kazan.ToString()
                    }
                }
            };
            var updateApartment = new ApartmentModel()
            {
                Id = Guid.NewGuid(),
                Location = new Location()
                {
                    Id = Guid.NewGuid(),
                    Country = Countries.Russian.ToString(),
                    City = Cities.Ryazan.ToString()
                }
            };

            var query = apartments.Where(x => x.Id == x.Id).AsQueryable();
            _repository.GetWhere(Arg.Any<Expression<Func<Apartment, bool>>>()).Returns(query);
            //Act
            var result =  _service.UpdateApartmentsAsync(testId, updateApartment);
            //Assert
            Assert.Equal(testId,result.Id);
        }
    }
}
