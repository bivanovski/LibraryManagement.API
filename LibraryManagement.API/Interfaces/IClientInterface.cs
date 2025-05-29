using LibraryManagement.Data.Entities;

namespace LibraryManagement.API.Interfaces
{
    public interface IClientInterface
    {
        Task<List<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(int id);
        Task<Client> AddAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task<bool> DeleteAsync(int id);
    }
}
