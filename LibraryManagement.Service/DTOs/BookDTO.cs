using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        
        public int IBAN { get; set; }
        
        public string Name { get; set; }
        
        public string Author { get; set; }
        
        public string Publisher { get; set; }
        
        public int Year { get; set; }
        
        public int NumberOfCopies { get; set; }

    }
}
