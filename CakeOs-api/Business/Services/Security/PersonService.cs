using CakeOs.Business.Base;
using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.PersonaDtos;

namespace CakeOs.Business.Services.Security
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con personas.
    /// </summary>
    public class PersonService : BaseService<Person, PersonListDTO>
    {
        /// <summary>
        /// Inicializa una nueva instancia del servicio de personas.
        /// </summary>
        /// <param name="data">Repositorio de datos de personas.</param>
        public PersonService(IData<Person> data) : base(data)
        {
        }

        /// <summary>
        /// Convierte un DTO a una entidad Person.
        /// </summary>
        protected override Person MapToEntity(PersonListDTO dto)
        {
            return new Person
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Phone = dto.Phone,
                CreateAt = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Actualiza una entidad Person existente con los datos del DTO.
        /// </summary>
        protected override void MapToEntity(PersonListDTO dto, Person entity)
        {
            entity.Name = dto.Name;
            entity.LastName = dto.LastName;
            entity.Phone = dto.Phone;
        }

        /// <summary>
        /// Convierte una entidad Person a un DTO.
        /// </summary>
        protected override PersonListDTO MapToDto(Person entity)
        {
            return new PersonListDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                Phone = entity.Phone,
                IsActive = entity.IsActive
            };
        }
    }
}
