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
using static LibraryManagement.Service.Services.BookService;

namespace LibraryManagement.Service.Services
{
        public class BookService : IBookService
        {
            private readonly LibraryDbContext _context;
            private readonly IMapper _mapper;

            public BookService(LibraryDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            async Task<BookDTO> IBookService.createBookAsync(BookDTO bookDTO)
            {
            var book = _mapper.Map<Book>(bookDTO);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookDTO>(book);
        }

           async Task<bool> IBookService.DeleteBookAsync(int id)
            {
            var guest = await _context.Books.FindAsync(id);
            if (guest == null) return false;

            _context.Books.Remove(guest);
            await _context.SaveChangesAsync();
            return true;
        }

            async Task<List<BookDTO>> IBookService.getAllBooksAsync()
            {
            var guests = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookDTO>>(guests);
        }

           async Task<BookDTO> IBookService.getBookByIdAsync(int id)
            {
            var book = await _context.Books.FindAsync(id);
            return book == null ? null : _mapper.Map<BookDTO>(book);
        }

            async Task<BookDTO> IBookService.UpdateBookAsync(int id, BookDTO bookDTO)
            {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return null;
            _mapper.Map(bookDTO, book);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookDTO>(book);
        }
    }
}
