using HR_PAYROLL_SYSTEM.Data;
using HR_PAYROLL_SYSTEM.Models;
using System.Linq;

namespace HR_PAYROLL_SYSTEM.Services;

public class PayrollService
{
    private List<Employee> _employees;
    private List<Payroll> _payrolls;

    public PayrollService()
    {
        _employees = DataStore.Employees;
        _payrolls = DataStore.PayrollRecords;
    }

    // -------------------------------
    // PROCESS PAYROLL
    // -------------------------------
    public bool ProcessPayroll(string employeeId)
    {
        var emp = _employees.FirstOrDefault(e => e.Id == employeeId);

        if (emp == null)
            return false;

        var payment = new Payroll
        {
            EmployeeId = emp.Id,
            EmployeeName = emp.Name,
            AmountPaid = emp.CalculatePay(),
            PaymentDate = DateTime.Now
        };

        _payrolls.Add(payment);

        return true;
    }

    // -------------------------------
    // VIEW ALL PAYROLL HISTORY
    // -------------------------------
    public List<Payroll> GetPayrollHistory()
    {
        return _payrolls;
    }

    // -------------------------------
    // SEARCH PAYROLL BY EMPLOYEE ID
    // -------------------------------
    public List<Payroll> SearchPayroll(string employeeId)
    {
        return _payrolls
            .Where(p => p.EmployeeId == employeeId)
            .ToList();
    }

    // -------------------------------
    // TOTAL PAYROLL (LINQ)
    // -------------------------------
    public decimal GetTotalPayroll()
    {
        return _payrolls.Sum(p => p.AmountPaid);
    }

    // -------------------------------
    // HIGHEST PAID EMPLOYEE (FROM PAYROLL)
    // -------------------------------
    public Payroll GetHighestPayment()
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
        if (!_payrolls.Any())
            return 0;

        return _payrolls.Average(p => p.AmountPaid);
    }

    // -------------------------------
    // TOP 5 HIGHEST PAYMENTS
    // -------------------------------
    public List<Payroll> GetTop5Payments()
    {
        return _payrolls
            .OrderByDescending(p => p.AmountPaid)
            .Take(5)
            .ToList();
    }
}