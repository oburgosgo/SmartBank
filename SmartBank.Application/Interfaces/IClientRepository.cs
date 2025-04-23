using SmartBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Application.Interfaces
{
    public interface IClientRepository
    {
        Task<bool> AddClient(Client client);
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientById(Guid id);
        Task<bool> DeleteClient(Client client);

        Task<bool> UpdateClient(Client client);
    }
}
