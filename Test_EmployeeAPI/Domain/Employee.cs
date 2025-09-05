using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Domain
{
    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public decimal? Comm { get; set; }
        public int DeptNo { get; set; }
    }

    public class EmployeeDto
    {
        public int EmpNo { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public string HireDate { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Comm { get; set; } = string.Empty;
        public int DeptNo { get; set; }
    }
}

