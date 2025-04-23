using Microsoft.EntityFrameworkCore;
using SmartBank.Application.Interfaces;
using SmartBank.Domain.Entities;
using SmartBank.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context) { 
            this._context = context;
        }
        public async Task<bool> AddClient(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> UpdateClient(Client client)
        {
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientById(Guid id) {

            var client = await _context.Clients.AsNoTracking().FirstOrDefaultAsync(x => x.PersonId == id);

            return client;
        }

        public async Task<bool> DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
