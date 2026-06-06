using CakeOs.Business.Base;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.PersonaDtos;

namespace CakeOs.Business.Interfaces.Security
{
    public interface IPersonServices : IServices<PersonListDTO, PersonCreateDTO, Person>
    {
    }
}
