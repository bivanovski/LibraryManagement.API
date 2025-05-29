using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Entities
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(200)]
        public string LastName { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required, MaxLength(400)]
        public string Address { get; set; }
        [Required]
        public int MembershipCardNumber { get; set; }
        [Required]
        public DateTime MembershipValidityDate { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }



    }
}
