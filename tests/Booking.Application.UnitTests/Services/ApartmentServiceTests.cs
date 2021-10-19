using AutoMapper;
using Booking.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Application.UnitTests.Services
{
    public class ApartmentServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IApartmentRepository _repository;
        public ApartmentServiceTests()
        {

        }

        [Fact]
        public async Task CreateApartmentsAsync_ReturnNewApartment()
        {

        }
        [Fact]
        public async Task DeleteApartmentsAsync_DeleteApartmentById()
        {

        }
        [Fact]
        public async Task GetApartments_ReturnListOfApartments()
        {

        }
        [Fact]
        public async Task GetApartmentsByLocationAsync_ReturnListOfApartments()
        {

        }
        [Fact]
        public async Task UpdateApartmentsAsync_ReturnUpdatedApartment()
        {

        }
    }
}
