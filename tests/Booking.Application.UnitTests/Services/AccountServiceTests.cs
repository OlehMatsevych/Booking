using AutoMapper;
using Booking.Application.MappingProfiles;
using Booking.Application.Models;
using Booking.Application.Services;
using Booking.DataAccess;
using Booking.DataAccess.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NSubstitute;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Booking.Application.UnitTests.Services
{
    public class AccountServiceTests
    {
        private readonly AccountService _accountService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly BookingContext _context;


        public AccountServiceTests()
        {
            _mapper = new MapperConfiguration(conf =>
            {
                conf.AddMaps(typeof(UserProfile));
            }).CreateMapper();

            var configurationRoot = new Dictionary<string, string>
            {
                {"JwtConfiguration:SecretKey","Super secret token key"},
            };
            _configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(configurationRoot)
                .Build();
            var user = Substitute.For<IUserStore<ApplicationUser>>();
            _userManager = Substitute.For<UserManager<ApplicationUser>>(user, null, null, null, null, null, null, null,null);
            var contextAccessor = Substitute.For<IHttpContextAccessor>();
            var userPrincipalFactory = Substitute.For<IUserClaimsPrincipalFactory<ApplicationUser>>();
            _signInManager = Substitute.For<SignInManager<ApplicationUser>>(_userManager, contextAccessor,
                userPrincipalFactory, null, null, null);
            var mockSet = new Mock<DbSet<ApplicationUser>>();

            var context = new Mock<BookingContext>();
            context.Setup(m => m.Users).Returns(mockSet.Object);

            _accountService = new AccountService(_userManager, _signInManager, _mapper, context.Object, _configuration);
        }
        [Fact]
        public async Task CreateAsync_AddUserToDb()
        {
            //Arrange
            var createUserModel = new UserModel() { 
                UserName="John",
                Email="test@test.com",
                PhoneNumber="+224346345232",
                Password="TryCreate132"
            };
            //Act
            var result = await _accountService.CreateAsync(createUserModel);

            //Assert

            var expectedResult = JsonSerializer.Serialize(
                new
            {
                Success = true,
                UserName = createUserModel.UserName
            });
            Assert.Equal(expectedResult, result);

        }
        [Fact]
        public async Task LoginAsync_ReturnTokenAndUserName()
        {
            //Arrange
            var loginUserModel = new UserModel()
            {
                UserName = "John",
                Email = "test@test.com",
                PhoneNumber = "+224346345232",
                Password = "TryCreate132"
            };
            //Act

            var result = await _accountService.LoginAsync(loginUserModel);
            //Assert

            NameToken expectedResult = JsonSerializer.Deserialize<NameToken>(result);

            Assert.NotNull(expectedResult.Token);
        } 
    }

    public class NameToken
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
