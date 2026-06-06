using CakeOs.Business.Base;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Auth;
using CakeOS.Entity.DTOs.Security.User;

namespace CakeOs.Business.Interfaces.Security
{
    public interface IUserServices : IServices<UserListDto, UserCreateDto, User>
    {
        Task<UserListDto?> GetByEmailAsync(string email);
        Task<bool> ChangePasswordAsync(int userId, ChangePasswordDto dto);
    }
}
