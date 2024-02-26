using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternExample.Models.Entities
{
    public class CustomerDataModel
    {
        [Key]
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
