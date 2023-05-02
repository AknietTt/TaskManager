using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO {
    public class EmployeeDto {
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
        [Range(1,int.MaxValue)]
        public int ManagerID { get; set; }
    }
}
