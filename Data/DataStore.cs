using HR_PAYROLL_SYSTEM.Models;

namespace HR_PAYROLL_SYSTEM.Data;

public class DataStore
{
    public static List<Employee> Employees = new List<Employee>
    {
        new ContractEmployee  { Id = Employee.GetRandomString("CON"), Name = "Lambe Richard", Department = "Production", HourlyRate = 5000,  HoursWorked = 12 },
        new ContractEmployee {  Id = Employee.GetRandomString("CON"), Name = "Aisha Bello", Department = "IT", HourlyRate = 4500, HoursWorked = 10 },
        new ContractEmployee {  Id = Employee.GetRandomString("CON"), Name = "Chinedu Okafor", Department = "Finance",  HourlyRate = 6000,  HoursWorked = 8  },
        new ContractEmployee { Id = Employee.GetRandomString("CON"), Name = "Fatima Yusuf", Department = "HR", HourlyRate = 4000, HoursWorked = 9 },
        new ContractEmployee { Id = Employee.GetRandomString("CON"), Name = "Sodiq Adewale", Department = "Logistics", HourlyRate = 5500, HoursWorked = 11 },

        
        
        new FullTimeEmployee { Id = Employee.GetRandomString("FUL"), Name = "Mr Olawale", Department = "Planning", BaseSalary = 150000, BonusProperty = 30000 },
        new FullTimeEmployee { Id = Employee.GetRandomString("FUL"), Name = "Grace Johnson", Department = "Finance", BaseSalary = 180000,  BonusProperty = 25000 },
        new FullTimeEmployee { Id = Employee.GetRandomString("FUL"), Name = "Ibrahim Musa", Department = "IT", BaseSalary = 200000, BonusProperty = 40000  },
        new FullTimeEmployee { Id = Employee.GetRandomString("FUL"), Name = "Ngozi Nwankwo", Department = "HR", BaseSalary = 160000, BonusProperty = 20000 },
        new FullTimeEmployee { Id = Employee.GetRandomString("FUL"), Name = "Tunde Balogun", Department = "Production", BaseSalary = 170000, BonusProperty = 30000 },
        new FullTimeEmployee { Id = Employee.GetRandomString("FUL"), Name = "Zainab Abdullahi", Department = "Admin", BaseSalary = 155000, BonusProperty = 15000 },
        
        
    };
    
    public static List<Payroll> PayrollRecords = new List<Payroll>();
}