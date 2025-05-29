using LibraryManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDTO>> getAllBooksAsync();
        Task<BookDTO> getBookByIdAsync(int id);

        Task<BookDTO> createBookAsync(BookDTO bookDTO);

        Task<BookDTO> UpdateBookAsync(int id, BookDTO bookDTO);

        Task<bool> DeleteBookAsync(int id);

    }
}
