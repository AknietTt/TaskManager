using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models {
    public class Task {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public Employee Employee { get; set; }
        public Manager Manager { get; set; }
    }

}
