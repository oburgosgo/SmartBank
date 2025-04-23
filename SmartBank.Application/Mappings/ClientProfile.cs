using AutoMapper;
using SmartBank.Application.DTOs;
using SmartBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Application.Mappings
{
    public class ClientProfile:Profile
    {
        public ClientProfile()
        {
            CreateMap<AddClientRequest, Client>()
                .ForMember(to => to.PersonId, property => property.MapFrom(src => Guid.NewGuid()))
                .ForMember(createdAt => createdAt.CreatedAt, property => property.MapFrom(src => DateTime.Now));
                

            CreateMap<Client, ClientDto>();
        }
    }
}
