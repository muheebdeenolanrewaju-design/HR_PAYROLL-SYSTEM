namespace HR_PAYROLL_SYSTEM.Models;

public class ContractEmployee: Employee
{
   public decimal HourlyRate { get; set; }

   public decimal HoursWorked { get; set; }
   //Implements variable pay based on time.
   
   public override decimal CalculatePay()
   {
      return HourlyRate * HoursWorked;
   }

}