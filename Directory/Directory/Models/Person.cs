using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "LastName is Required")]
        public string LastName { get; set; }
        public int Number { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
    }
}
