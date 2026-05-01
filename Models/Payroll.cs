namespace HR_PAYROLL_SYSTEM.Models;

public class Payroll
{
    public string EmployeeId { get; set; }

    public string EmployeeName { get; set; }

    public decimal AmountPaid { get; set; }

    public DateTime PaymentDate { get; set; }
}