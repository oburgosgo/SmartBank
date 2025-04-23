using SmartBank.Application.DTOs;
using SmartBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Application.Interfaces
{
    public interface IClientService
    {
        Task<bool> AddClient(AddClientRequest request);
        Task<IEnumerable<ClientDto>> GetClients();
        Task<ClientDto> GetClientById(Guid id);
        Task<bool> DeleteClientById(Guid id);
        Task<bool> UpdateClient(Guid id, UpdateClientRequest request);
    }
}
