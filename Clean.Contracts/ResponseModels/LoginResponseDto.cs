using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Contracts.ResponseModel
{
    public record LoginResponseDto
    {
        public string Id { get; set; } = string.Empty!;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IList<string> Roles { get; set; } = [];
        public bool Succeded { get; set; } = false;
    }
}