using Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO {
    public class TaskDto {
        public int Id { get; set; }
        public string Description { get; set; }
        public int EmployeeID { get; set; }
        public int ManagerID { get; set; }
    }
}
