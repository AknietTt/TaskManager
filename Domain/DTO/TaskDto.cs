using Domain.Models;
using Domain.Validation;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.DTO {
    public class TaskDto {

        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [NumberGreaterThanZero]
        [Range(1, int.MaxValue)]
        public int EmployeeID { get; set; }
        [Range(1,int.MaxValue)]
        [NumberGreaterThanZero]
        public int ManagerID { get; set; }
    }
}
