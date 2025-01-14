using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Contracts.RequestModel;
using Clean.Contracts.ResponseModel;

namespace Clean.Application.Interfaces
{
    public interface IAuthRepository
    {
        public Task<LoginResponseDto> Login(LoginRequestDto loginModel);
    }
}