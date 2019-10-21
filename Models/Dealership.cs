using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_1B.Models
{
    public class Dealership
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter an Email")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
