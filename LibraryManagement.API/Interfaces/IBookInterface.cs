using LibraryManagement.Data.Entities;

namespace LibraryManagement.API.Interfaces
{
    public interface IBookInterface
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<bool> DeleteAsync(int id);
    }
}
