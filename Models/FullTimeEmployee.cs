namespace HR_PAYROLL_SYSTEM.Models;

public class FullTimeEmployee:Employee
{
   public decimal BonusProperty { get; set; }
   // Implements fixed salary + bonus logic.
   public override decimal CalculatePay()
   {
      return BaseSalary + BonusProperty;
   }
}