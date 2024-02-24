using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternExample.Models
{
    public class EmployeeDataModel
    {
        [Key]
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}
