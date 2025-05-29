using LibraryManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDTO>> getAllClientsAsync();
        Task<ClientDTO> getClientByIdAsync(int id);

        Task<ClientDTO> createClientAsync(ClientDTO clientDTO);

        Task<ClientDTO> UpdateClientAsync(int id, ClientDTO clientDTO);

        Task<bool> DeleteClientAsync(int id);

    }
}
