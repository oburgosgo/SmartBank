using AutoMapper;
using SmartBank.Application.DTOs;
using SmartBank.Application.Interfaces;
using SmartBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Application.Services
{
    public class ClientService: IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper) { 
            this._clientRepository = clientRepository;
            this._mapper = mapper;
        }

        

        public async Task<bool> DeleteClientById(Guid id)
        {
         
            var client = await _clientRepository.GetClientById(id);
            await _clientRepository.DeleteClient(client);

            return true;
        }

        public async Task<ClientDto> GetClientById(Guid id)
        {
            var client = await _clientRepository.GetClientById(id);

            return client is null ? null : _mapper.Map<ClientDto>(client);
        }

        public async Task<IEnumerable<ClientDto>> GetClients()
        {
            var clients = await _clientRepository.GetClients();

            return _mapper.Map<List<ClientDto>>(clients);
        }

        public async Task<bool> AddClient(AddClientRequest request)
        {

            await _clientRepository.AddClient(_mapper.Map<Client>(request));

            return true;
        }

        public async Task<bool> UpdateClient(Guid id, UpdateClientRequest request)
        {

            var client = await _clientRepository.GetClientById(id);
            if (client != null)
            {
                client.Phone = request.Phone;
                client.Email = request.Email;
                client.FirstName = request.FirstName;
                client.LastName = request.LastName;
                client.Id = request.Id;
                client.IdType = request.IdType;
                client.Gender = request.Gender;
                client.BurnDate = request.BurnDate;
                client.UpdatedAt = DateTime.Now;
            }

            await this._clientRepository.UpdateClient(client);

            return true;
        }
    }
}
