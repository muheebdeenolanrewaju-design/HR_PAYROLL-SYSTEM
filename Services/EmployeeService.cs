using HR_PAYROLL_SYSTEM.Data;
using HR_PAYROLL_SYSTEM.Models;
using System.Linq;

namespace HR_PAYROLL_SYSTEM.Services;

public class EmployeeService
{
    private List<Employee> _employees;

    public EmployeeService()
    {
        _employees = DataStore.Employees;
    }

    // -------------------------------
    // VIEW ALL EMPLOYEES
    // -------------------------------
    public List<Employee> GetAllEmployees()
    {
        return _employees;
    }

    // -------------------------------
    // ADD EMPLOYEE
    // -------------------------------
    public bool AddEmployee(Employee employee)
    {
        // Validation
        if (employee == null) return false;

        if (string.IsNullOrWhiteSpace(employee.Name) ||
            string.IsNullOrWhiteSpace(employee.Department))
            return false;

        // Unique ID check
        if (_employees.Any(e => e.Id == employee.Id))
            return false;

        _employees.Add(employee);
        return true;
    }

    // -------------------------------
    // REMOVE EMPLOYEE
    // -------------------------------
    public bool RemoveEmployee(string id)
    {
        var emp = _employees.FirstOrDefault(e => e.Id == id);

        if (emp == null)
            return false;

        _employees.Remove(emp);
        return true;
    }

    // -------------------------------
    // UPDATE SALARY
    // -------------------------------
    public bool UpdateSalary(string id, decimal newSalary, decimal bonus = 0)
    {
        var emp = _employees.FirstOrDefault(e => e.Id == id);

        if (emp == null)
            return false;

        if (emp is FullTimeEmployee fullTime)
        {
            if (newSalary <= 0) return false;

            fullTime.BaseSalary = newSalary;
            fullTime.BonusProperty = bonus;
        }
        else if (emp is ContractEmployee contract)
        {
            if (newSalary <= 0) return false;

            contract.HourlyRate = newSalary;
        }

        return true;
    }

    // -------------------------------
    // GET EMPLOYEE BY ID
    // -------------------------------
    public Employee GetById(string id)
    {
        return _employees.FirstOrDefault(e => e.Id == id);
    }

    // -------------------------------
    // CHECK IF EMPLOYEE EXISTS
    // -------------------------------
    public bool Exists(string id)
    {
        return _employees.Any(e => e.Id == id);
    }
}