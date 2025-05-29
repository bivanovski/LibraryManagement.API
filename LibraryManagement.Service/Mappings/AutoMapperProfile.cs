using AutoMapper;
using LibraryManagement.Data.Entities;
using LibraryManagement.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            // Entity to DTO
            CreateMap<Client, ClientDTO>();
            CreateMap<Book, BookDTO>();

            // DTO to Entity
            CreateMap<ClientDTO, Client>();
            CreateMap<BookDTO, Book>();
        }
    }
}
