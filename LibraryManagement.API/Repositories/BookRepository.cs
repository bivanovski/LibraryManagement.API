using LibraryManagement.API.Interfaces;
using LibraryManagement.Data.Db;
using LibraryManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.API.Repositories
{
    public class BookRepository : IBookInterface
    {

        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
       async Task<Book> IBookInterface.AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        async Task<bool> IBookInterface.DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        async Task<List<Book>> IBookInterface.GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        async Task<Book> IBookInterface.GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        async Task<Book> IBookInterface.UpdateAsync(Book book)
        {
            var existing = await _context.Books.FindAsync(book.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(book);
            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
