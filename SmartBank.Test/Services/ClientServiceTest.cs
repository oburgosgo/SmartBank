﻿using AutoMapper;
using FluentAssertions;
using Moq;
using SmartBank.Application.DTOs;
using SmartBank.Application.Interfaces;
using SmartBank.Application.Services;
using SmartBank.Domain.Entities;
using SmartBank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartBank.Test.Services
{
    public class ClientServiceTest
    {
        private readonly ClientService _clientService;
        private readonly Mock<IClientRepository> _clientRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public ClientServiceTest()
        {
            this._clientRepositoryMock = new Mock<IClientRepository>();
            this._mapperMock = new Mock<IMapper>();
            this._clientService = new ClientService(this._clientRepositoryMock.Object, this._mapperMock.Object);
        }

        [Fact]
        public async Task AddClient_ShouldReturnTrue_WhenClientIsValid()
        {

            var client = GetClient();
            var addClientRequest = GetAddClientRequest();

            this._mapperMock.Setup(x=>x.Map<Client>(addClientRequest)).Returns(client);
            this._clientRepositoryMock.Setup(x => x.AddClient(client)).ReturnsAsync(true);

            var result = await _clientService.AddClient(addClientRequest);

            result.Should().BeTrue();

            _mapperMock.Verify(m => m.Map<Client>(addClientRequest), Times.Once);
            _clientRepositoryMock.Verify(repo => repo.AddClient(client), Times.Once);
        }

        [Fact]
        public async Task AddClient_ShouldReturnFalse_WhenClientIsInvalid()
        {
            var client = GetClient();
            var addClientRequest = GetAddClientRequest();

            this._mapperMock.Setup(x => x.Map<Client>(addClientRequest)).Returns(client);
            this._clientRepositoryMock.Setup(x => x.AddClient(client)).ReturnsAsync(false);

            var result = await _clientService.AddClient(addClientRequest);

            result.Should().BeFalse();

            _mapperMock.Verify(m => m.Map<Client>(addClientRequest), Times.Once);
            _clientRepositoryMock.Verify(repo => repo.AddClient(client), Times.Once);
        }

        [Fact]
        public async Task UpdateClient_ShouldReturnTrue_WhenClientIsUpdated()
        {
           
            var updateClientRequest = GetUpdateClientRequest();
            var client = GetClient();
            var clientId = new Guid("0FE03CC3-A5D8-4D7B-AA1D-78F58E113280");

            this._clientRepositoryMock.Setup(x=>x.GetClientById(clientId)).ReturnsAsync(client);
            this._clientRepositoryMock.Setup(x => x.UpdateClient(client)).ReturnsAsync(true);

            var result = await _clientService.UpdateClient(clientId,updateClientRequest);

            result.Should().BeTrue();

            _clientRepositoryMock.Verify(repo => repo.GetClientById(clientId), Times.Once);
            _clientRepositoryMock.Verify(repo => repo.UpdateClient(client), Times.Once);

        }
   
        [Fact]
        public async Task UpdateClient_ShouldReturnFalse_WhenClientIsNotUpdated()
        {

            var updateClientRequest = GetUpdateClientRequest();
            var clientId = new Guid("0FE03CC3-A5D8-4D7B-AA1D-78F58E113280");

            var client = GetClient();

            this._clientRepositoryMock.Setup(x=>x.GetClientById(clientId)).ReturnsAsync(client);
            this._clientRepositoryMock.Setup(x => x.UpdateClient(client)).ReturnsAsync(false);

            var result = await _clientService.UpdateClient(clientId, updateClientRequest);

            result.Should().BeFalse();

            _clientRepositoryMock.Verify(repo => repo.UpdateClient(client), Times.Once);
            _clientRepositoryMock.Verify(repo => repo.GetClientById(clientId), Times.Once);
        }

        [Fact] 
        public async Task GetClientById_ShouldReturnClient_WhenClientExist()
        {
            var client = GetClient();
            var clientId = new Guid("0FE03CC3-A5D8-4D7B-AA1D-78F58E113280");
            var clientDto = GetClientDto();

            this._clientRepositoryMock.Setup(x=>x.GetClientById(clientId)).ReturnsAsync(client);
            this._mapperMock.Setup(x => x.Map<ClientDto>(client)).Returns(clientDto);

            var result =await _clientService.GetClientById(clientId);

            result.Should().NotBeNull();

            _clientRepositoryMock.Verify(repo => repo.GetClientById(clientId), Times.Once);
            _mapperMock.Verify(m => m.Map<ClientDto>(client), Times.Once);
        }

        [Fact]
        public async Task GetClientById_ShouldReturnNull_WhenClientDoesntExist()
        {

            var clientId = new Guid("0FE03CC3-A5D8-4D7B-AA1D-78F58E113280");
            var clientDto = GetClientDto();

            var result = await _clientService.GetClientById(clientId);

            result.Should().BeNull();

        }

        [Fact]
        public async Task DeleteClientById_ShouldReturnTrue_WhenClientIsDeleted()
        {
            var client = GetClient();
            var clientId = new Guid("0FE03CC3-A5D8-4D7B-AA1D-78F58E113280");

            this._clientRepositoryMock.Setup(x => x.DeleteClient(client)).ReturnsAsync(true);
            this._clientRepositoryMock.Setup(x => x.GetClientById(clientId)).ReturnsAsync(client);

            var result = await _clientService.DeleteClientById(clientId);

            result.Should().BeTrue();

            this._clientRepositoryMock.Verify(x => x.DeleteClient(client), Times.Once);
            this._clientRepositoryMock.Verify(x => x.GetClientById(clientId), Times.Once);
        }

        [Fact]
        public async Task DeleteClientById_ShouldReturnFalse_WhenClientIsNotDeleted()
        {
            var client = GetClient();
            var clientId = new Guid("0FE03CC3-A5D8-4D7B-AA1D-78F58E113280");

            this._clientRepositoryMock.Setup(x=>x.DeleteClient(client)).ReturnsAsync(false);
            this._clientRepositoryMock.Setup(x => x.GetClientById(clientId)).ReturnsAsync(client);

            var result =await _clientService.DeleteClientById(clientId);

            result.Should().BeFalse();

            this._clientRepositoryMock.Verify(x=>x.DeleteClient(client),Times.Once);
            this._clientRepositoryMock.Verify(x=>x.GetClientById(clientId),Times.Once);
        }

        [Fact]
        public async Task GetClients_ShouldReturnList_WhenClientsExist()
        {
            var clients = GetClients();
            var clientsDto = GetClientsDto();

            this._clientRepositoryMock.Setup(x => x.GetClients()).ReturnsAsync(clients);
            this._mapperMock.Setup(x => x.Map<List<ClientDto>>(clients)).Returns(clientsDto);

            var result = await _clientService.GetClients();

            result.Should().NotBeNullOrEmpty();

            _mapperMock.Verify(x => x.Map<List<ClientDto>>(clients), Times.Once);
            _clientRepositoryMock.Verify(x => x.GetClients(), Times.Once);
        }

        [Fact]
        public async Task GetClients_ShouldReturnEmptyList_WhenClientsDontExist()
        {

            var clients = new List<Client>();
            var clientsDto = new List<ClientDto>();

            this._clientRepositoryMock.Setup(x=>x.GetClients()).ReturnsAsync(clients);
            this._mapperMock.Setup(x=>x.Map<List<ClientDto>>(clients)).Returns(clientsDto);

            var result = await this._clientService.GetClients();

            result.Should().BeEmpty();

            this._clientRepositoryMock.Verify(x=>x.GetClients(),Times.Once);
            this._mapperMock.Verify(x => x.Map<List<ClientDto>>(clients), Times.Once);
        }
        
        private List<Client> GetClients()
        {
            var result = new List<Client>();
            result.Add(GetClient());
            result.Add(GetClient());
            result.Add(GetClient());

            return result;
        }

        private List<ClientDto> GetClientsDto()
        {
            var result = new List<ClientDto>();
            result.Add(GetClientDto());
            result.Add(GetClientDto());
            result.Add(GetClientDto());

            return result;
        }
        private ClientDto GetClientDto()
        {
            return new ClientDto()
            {
                BurnDate = 10,
                Email = "oburgosgo@gmail.com",
                FirstName = "Oscar",
                LastName = "Burgos Gonzalez",
                Gender = GenderType.Male,
                Id = "115900291",
                Phone = "+50687229082",
                IdType = IdType.DNI,
                CreatedAt = DateTime.UtcNow,

            };
        }
        private Client GetClient()
        {
            return new Client()
            {
                BurnDate = 10,
                Email = "oburgosgo@gmail.com",
                FirstName = "Oscar",
                LastName = "Burgos Gonzalez",
                Gender = GenderType.Male,
                Id = "115900291",
                Phone = "+50687229082",
                IdType = IdType.DNI,
                CreatedAt = DateTime.UtcNow,

            };
        }
        private AddClientRequest GetAddClientRequest()
        {
            return new AddClientRequest()
            {
                BurnDate = 10,
                Email = "oburgosgo@gmail.com",
                FirstName = "Oscar",
                LastName ="Burgos Gonzalez",
                Gender=GenderType.Male,
                Id="115900291",
                Phone="+50687229082",
                IdType = IdType.DNI

            };
        }
        private UpdateClientRequest GetUpdateClientRequest()
        {
            return new UpdateClientRequest()
            {
                BurnDate = 10,
                Email = "oburgosgo@gmail.com",
                FirstName = "Oscar",
                LastName = "Burgos Gonzalez",
                Gender = GenderType.Male,
                Id = "115900291",
                Phone = "+50687229082",
                IdType = IdType.DNI

            };
        }
    }
}
