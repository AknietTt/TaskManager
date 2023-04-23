using System.ComponentModel.DataAnnotations;

namespace Domain.Models {
    public class Manager {
        [Key]

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Domain.Models.Task>? Tasks { get; set; }
    }
}