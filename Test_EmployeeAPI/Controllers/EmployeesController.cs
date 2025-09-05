using EmployeeApi.Domain;
using EmployeeApi.Infrastructure; 
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeesController(AppDbContext context)
    {
        _context = context;
    }

    // GET all
    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = _context.Employees.ToList();
        return Ok(employees.Select(e => new
        {
            e.EmpNo,
            e.FirstName,
            e.LastName,
            e.Designation,
            HireDate = e.HireDate.ToString("yyyy-MM-dd"),
            e.Salary,
            e.Comm,
            e.DeptNo
        }));
    }

    // GET by id
    [HttpGet("{empNo}")]
    public IActionResult GetById(int empNo)
    {
        var emp = _context.Employees.FirstOrDefault(e => e.EmpNo == empNo);
        if (emp == null) return NotFound();
        return Ok(new
        {
            emp.EmpNo,
            emp.FirstName,
            emp.LastName,
            emp.Designation,
            HireDate = emp.HireDate.ToString("yyyy-MM-dd"),
            emp.Salary,
            emp.Comm,
            emp.DeptNo
        });
    }

    // POST
    [HttpPost]
    public IActionResult Create([FromBody] EmployeeDto dto)
    {
        if (!DateTime.TryParseExact(dto.HireDate, "dd-MMM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var hireDate))
            return BadRequest("HireDate format invalid. Use dd-MMM-yy, e.g., 17-Aug-99");

        decimal? comm = dto.Comm == "-" ? null : decimal.Parse(dto.Comm);

        var employee = new Employee
        {
            EmpNo = dto.EmpNo,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Designation = dto.Designation,
            HireDate = hireDate,
            Salary = dto.Salary,
            Comm = comm,
            DeptNo = dto.DeptNo
        };

        _context.Employees.Add(employee);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { empNo = employee.EmpNo }, employee);
    }

    // PUT
    [HttpPut("{empNo}")]
    public IActionResult Update(int empNo, [FromBody] EmployeeDto dto)
    {
        var emp = _context.Employees.FirstOrDefault(e => e.EmpNo == empNo);
        if (emp == null) return NotFound();

        if (!DateTime.TryParseExact(dto.HireDate, "dd-MMM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var hireDate))
            return BadRequest("HireDate format invalid. Use dd-MMM-yy, e.g., 17-Aug-99");

        decimal? comm = dto.Comm == "-" ? null : decimal.Parse(dto.Comm);

        emp.FirstName = dto.FirstName;
        emp.LastName = dto.LastName;
        emp.Designation = dto.Designation;
        emp.HireDate = hireDate;
        emp.Salary = dto.Salary;
        emp.Comm = comm;
        emp.DeptNo = dto.DeptNo;

        _context.SaveChanges();

        return Ok(emp);
    }

    // DELETE
    [HttpDelete("{empNo}")]
    public IActionResult Delete(int empNo)
    {
        var emp = _context.Employees.FirstOrDefault(e => e.EmpNo == empNo);
        if (emp == null) return NotFound();

        _context.Employees.Remove(emp);
        _context.SaveChanges();

        return NoContent();
    }
}
