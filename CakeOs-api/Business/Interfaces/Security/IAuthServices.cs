using CakeOS.Entity.DTOs.Security.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Interfaces.Security
{
    public interface IAuthServices
    {
        Task<TokenDto> LoginAsync(LoginDto dto);
        Task<TokenInfoDto> GetTokenInfoAsync(string token);
    }
}
