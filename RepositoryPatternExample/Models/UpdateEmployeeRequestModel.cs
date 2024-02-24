namespace RepositoryPatternExample.Models
{
    public class UpdateEmployeeRequestModel
    {
        public required long EmployeeId { get; set; }
        public required string EmployeeName { get; set; }
        public required int Age { get; set; }
    }
}
