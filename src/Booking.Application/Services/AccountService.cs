using AutoMapper;
using Booking.Application.Constants;
using Booking.Application.Exceptions;
using Booking.Application.Helpers;
using Booking.Application.Models;
using Booking.Application.Services.Interfaces;
using Booking.Core.Entities;
using Booking.DataAccess;
using Booking.DataAccess.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Booking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly BookingContext _context;
        private readonly IConfiguration _configuration;
        public AccountService(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            IMapper mapper,
            BookingContext context,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        //TODO: private method for bl
        //TODO: extension method object
        public async Task<string> LoginAsync(UserModel loginUserModel)
        {
            try
            {
                var user = _userManager.Users.FirstOrDefault(u => u.UserName == loginUserModel.UserName);
                if (user == null)
                {
                    throw new UserNotFoundException(AccountErrorMessages.UserNotFoundException);
                }
                var signInResult = await _signInManager.PasswordSignInAsync(user,loginUserModel.Password, false, false);
                if (!signInResult.Succeeded)
                {
                    throw new UserNotFoundException(AccountErrorMessages.UserNotFoundException);
                }
                var token = JwtGenerator.GenerateToken(user, _configuration);
                var response = new
                {
                    Token = token,
                    UserName = user.UserName
                };
                return JsonSerializer.Serialize(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CreateAsync(UserModel createUserModel)
        {
            try
            {
                var user = _mapper.Map<ApplicationUser>(createUserModel);
                var result = await _userManager.CreateAsync(user, createUserModel.Password);
                if (!result.Succeeded)
                {
                    throw new ArgumentRequestException(
                        AccountErrorMessages.ArgumentRequestException + ':' + result.Errors.FirstOrDefault().Description);
                }
                var newUser = await _userManager.FindByEmailAsync(user.Email);
                await _userManager.AddToRoleAsync(newUser,"User");

                var guest = _mapper.Map<Guest>(createUserModel);
                await _context.AddAsync(guest);
                await _context.SaveChangesAsync();
                var response = new
                {
                    Success = true,
                    UserName = user.UserName
                };
                return JsonSerializer.Serialize(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
