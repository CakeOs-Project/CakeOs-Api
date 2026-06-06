using CakeOS.Entity.DTOs.Security.Auth;
using CakeOS.Entity.Domain.security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Interfaces
{
    public interface IToken
    {
        Task<TokenDto> GenerateTokensAsync(User user, string fullName, string rolName);
    }
}
