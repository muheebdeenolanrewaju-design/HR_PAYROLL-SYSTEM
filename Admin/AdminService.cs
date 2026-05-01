using HR_PAYROLL_SYSTEM.Data;
using HR_PAYROLL_SYSTEM.Models;


namespace HR_PAYROLL_SYSTEM.Admin;

public class AdminService
{
    private List<Employee> _employees;
    private List<Payroll> _payrolls;

    public AdminService()
    {
        _employees = DataStore.Employees;
        _payrolls = DataStore.PayrollRecords;
    }

    // -------------------------------
    // TOTAL PAYROLL EXPENDITURE
    // -------------------------------
    public decimal GetTotalPayroll()
    {
        return _payrolls.Sum(p => p.AmountPaid);
    }

    // -------------------------------
    // HIGHEST PAID EMPLOYEE
    // -------------------------------
    public Payroll GetHighestPaid()
    {
        return _payrolls
            .OrderByDescending(p => p.AmountPaid)
            .FirstOrDefault();
    }

    // -------------------------------
    // AVERAGE SALARY
    // -------------------------------
    public decimal GetAverageSalary()
    {
        return _payrolls.Any()
            ? _payrolls.Average(p => p.AmountPaid)
            : 0;
    }

    // -------------------------------
    // HIGH EARNERS FILTER
    // -------------------------------
    public List<Payroll> GetHighEarners(decimal threshold)
    {
        return _payrolls
            .Where(p => p.AmountPaid > threshold)
            .ToList();
    }

    // -------------------------------
    // TOP 5 HIGHEST PAID
    // -------------------------------
    public List<Payroll> GetTop5Earners()
    {
        return _payrolls
            .OrderByDescending(p => p.AmountPaid)
            .Take(5)
            .ToList();
    }

    // -------------------------------
    // SALARY RANKING (EMPLOYEES)
    // -------------------------------
    public List<Employee> GetSalaryRanking()
    {
        return _employees
            .OrderByDescending(e => e.CalculatePay())
            .ToList();
    }

    // -------------------------------
    // DEPARTMENT GROUPING
    // -------------------------------
    public object GetDepartmentAnalytics()
    {
        return _employees
            .GroupBy(e => e.Department)
            .Select(g => new
            {
                Department = g.Key,
                EmployeeCount = g.Count(),
                TotalSalary = g.Sum(e => e.CalculatePay())
            })
            .ToList();
    }

    // -------------------------------
    // CHECK IF DEPARTMENT EXISTS
    // -------------------------------
    public bool DepartmentExists(string department)
    {
        return _employees.Any(e =>
            e.Department.ToLower() == department.ToLower());
    }

    // -------------------------------
    // DISTINCT DEPARTMENTS
    // -------------------------------
    public List<string> GetAllDepartments()
    {
        return _employees
            .Select(e => e.Department)
            .Distinct()
            .ToList();
    }

    // -------------------------------
    // WORKFORCE SUMMARY
    // -------------------------------
    public object GetWorkforceSummary()
    {
        return new
        {
            FullTimeEmployees = _employees.OfType<FullTimeEmployee>().Count(),
            ContractEmployees = _employees.OfType<ContractEmployee>().Count()
        };
    }

    // -------------------------------
    // RESET SYSTEM DATA
    // -------------------------------
    public void ResetSystem()
    {
        _employees.Clear();
        _payrolls.Clear();
    }

    // -------------------------------
    // RESEED SYSTEM DATA
    // -------------------------------
    public void ReseedData()
    {
        _employees.Clear();
        _employees.AddRange(DataStore.Employees);

        _payrolls.Clear();
        _payrolls.AddRange(DataStore.PayrollRecords);
    }
}