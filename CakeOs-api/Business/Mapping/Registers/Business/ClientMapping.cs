using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Business.Client;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Business
{
    public class ClientMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Client, ClientListDto>()
                .Map(dest => dest.FullName, src => src.Person != null
                    ? $"{src.Person.Name} {src.Person.LastName}"
                    : string.Empty)
                .Map(dest => dest.TypeDocument, src => src.Person != null ? src.Person.TypeDocument : string.Empty)
                .Map(dest => dest.Document, src => src.Person != null ? src.Person.Document: string.Empty)
                .Map(dest => dest.Phone, src => src.Person != null ? src.Person.Phone : string.Empty);

            config.NewConfig<ClientCreateDto, Client>()
                .Map(dest => dest.IsActive, src => true)
                .Ignore(dest => dest.Person);

            config.NewConfig<ClientCreateDto, Person>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.Address, src => src.Address)
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.CreateAt, src => DateTime.UtcNow);

            config.NewConfig<ClientUpdateDto, Person>()
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.Phone, src => src.Phone)
                .Map(dest => dest.Address, src => src.Address);
        }
    }
}
