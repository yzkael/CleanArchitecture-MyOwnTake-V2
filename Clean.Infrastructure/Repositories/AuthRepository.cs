using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Application.Interfaces;
using Clean.Contracts.RequestModel;
using Clean.Contracts.ResponseModel;
using Clean.Domain.Entities.AuthRelatedEntities;
using Clean.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clean.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly AppDbContext _context;

        public AuthRepository(UserManager<Usuario> userManager, AppDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginModel)
        {
            var foundUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Username == loginModel.Username);
            if (foundUser == null) return new LoginResponseDto();

            var passwordMatch = await _userManager.CheckPasswordAsync(foundUser, loginModel.Password);
            if (!passwordMatch) return new LoginResponseDto();

            var userInfo = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == foundUser.Email);
            var userRoles = await _userManager.GetRolesAsync(foundUser);

            if (userInfo == null) return new LoginResponseDto();
            return new LoginResponseDto
            {
                Id = userInfo.Id,
                Username = userInfo.UserName!,
                Email = userInfo.Email!,
                Roles = userRoles,
                Succeded = true
            };

        }
    }
}