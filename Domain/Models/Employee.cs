using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class Employee {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100,MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100,MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100,MinimumLength = 2)]
        public string Position { get; set; }
        public Manager? Manager { get; set; }
        public ICollection<Domain.Models.Task>? Tasks { get; set; }
    }
}
