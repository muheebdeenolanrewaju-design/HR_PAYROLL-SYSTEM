namespace HR_PAYROLL_SYSTEM.Models;

public class Employee
{
   public string Id { get; set; }
   public string Name { get; set; }
   public string Department { get; set; }
   public decimal  BaseSalary { get; set; }
   
   
   
   public virtual decimal CalculatePay() => 0 ;
   
   public static string GetRandomString(string prefix)
   {
      int randomNumber = new Random().Next(1000, 9999);
      return $"{prefix}/{randomNumber}";
   }
   
}