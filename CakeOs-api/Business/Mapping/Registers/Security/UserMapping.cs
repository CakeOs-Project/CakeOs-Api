using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.User;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Security
{
    public class UserMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserListDto>()
                .Map(dest => dest.FullName, src => src.Person != null
                    ? $"{src.Person.Name} {src.Person.LastName}"
                    : string.Empty)
                .Map(dest => dest.RolName, src => src.Rol != null ? src.Rol.Name : string.Empty);

            config.NewConfig<UserCreateDto, User>()
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.IsDeleted, src => false)
                .Ignore(dest => dest.Person);

            config.NewConfig<UserUpdateDto, User>()
                .Ignore(dest => dest.Person)
                .Ignore(dest => dest.Password);
        }
    }
}
