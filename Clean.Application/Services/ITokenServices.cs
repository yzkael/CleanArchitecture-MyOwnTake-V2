using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Contracts.ResponseModel;

namespace Clean.Application.Services
{
    public interface ITokenServices
    {
        public string PopulateAccessToken(LoginResponseDto responseDto);
        public string PopulateRefreshToken(LoginResponseDto responseDto);
    }
}