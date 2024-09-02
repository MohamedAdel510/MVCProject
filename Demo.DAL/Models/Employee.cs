using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(50, ErrorMessage ="Max length is 50")]
        [MinLength(3, ErrorMessage ="Max length is 3")]
        public string Name { get; set; }
        public string Addres { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Range(22, 35, ErrorMessage ="Age Must be in Range( 22 - 35 )")]
        public int? Age { get; set; }
        public bool IsActive { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set;} = DateTime.Now;
    }
}
