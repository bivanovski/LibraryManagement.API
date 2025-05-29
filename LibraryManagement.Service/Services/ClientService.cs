using AutoMapper;
using LibraryManagement.Data.Db;
using LibraryManagement.Data.Entities;
using LibraryManagement.Service.DTOs;
using LibraryManagement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Services
{
    public class ClientService : IClientService
    {

            private readonly LibraryDbContext _context;
            private readonly IMapper _mapper;

            public ClientService(LibraryDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

       async Task<ClientDTO> IClientService.createClientAsync(ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClientDTO>(client);
        }

        async Task<bool> IClientService.DeleteClientAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<List<ClientDTO>> IClientService.getAllClientsAsync()
        {
            var clients = await _context.Clients.ToListAsync();
            return _mapper.Map<List<ClientDTO>>(clients);
        }

        async Task<ClientDTO> IClientService.getClientByIdAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            return client == null ? null : _mapper.Map<ClientDTO>(client);
        }

        async Task<ClientDTO> IClientService.UpdateClientAsync(int id, ClientDTO clientDTO)
        {
            var guest = await _context.Clients.FindAsync(id);
            if (guest == null) return null;
            _mapper.Map(clientDTO, guest);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClientDTO>(guest);
        }
    }
}
