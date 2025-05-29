using LibraryManagement.API.Interfaces;
using LibraryManagement.Data.Db;
using LibraryManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.API.Repositories
{
    public class ClientRepository : IClientInterface
    {
        private readonly LibraryDbContext _context;

        public ClientRepository(LibraryDbContext context)
        {
            _context = context;
        }

        async Task<Client> IClientInterface.AddAsync(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        async Task<bool> IClientInterface.DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<List<Client>> IClientInterface.GetAllAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        async Task<Client> IClientInterface.GetByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        async Task<Client> IClientInterface.UpdateAsync(Client client)
        {
            var existing = await _context.Clients.FindAsync(client.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(client);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
