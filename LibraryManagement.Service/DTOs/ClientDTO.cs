using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.DTOs
{
    public class ClientDTO
    {
        public int Id { get; set; }
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public DateTime DOB { get; set; }
        
        public string Address { get; set; }
        
        public int MembershipCardNumber { get; set; }
        
        public DateTime MembershipValidityDate { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int BookId { get; set; }
    }
}
