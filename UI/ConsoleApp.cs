using HR_PAYROLL_SYSTEM.Services;
using HR_PAYROLL_SYSTEM.Admin;
using HR_PAYROLL_SYSTEM.Models;

namespace HR_PAYROLL_SYSTEM.UI;

public class ConsoleApp
{
    // -------------------------------
    // MAIN ENTRY
    // -------------------------------
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n===== MAIN MENU =====");
            Console.WriteLine("1. Employee Operations");
            Console.WriteLine("2. Payroll Operations");
            Console.WriteLine("3. Admin Panel ");
            Console.WriteLine("0. Exit");

            Console.Write("Select option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    EmployeeMenu();
                    break;

                case "2":
                    PayrollMenu();
                    break;

                case "3":
                    if (AdminLogin())
                        AdminMenu();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }


    // EMPLOYEE MENU
    private void EmployeeMenu()
    {
        var employeeService = new EmployeeService();

        while (true)
        {
            Console.WriteLine("\n--- EMPLOYEE MENU ---");
            Console.WriteLine("1. View All Employees");
            Console.WriteLine("2. Add Employee");
            Console.WriteLine("3. Update Salary");
            Console.WriteLine("4. Remove Employee");
            Console.WriteLine("0. Back");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var employees = employeeService.GetAllEmployees();
                    foreach (var e in employees)
                        Console.WriteLine($"{e.Id} | {e.Name} | {e.Department}");
                    break;
                case "2":
                {
                    Console.Write("Enter Name: ");
                    var name = Console.ReadLine();

                    Console.Write("Enter Department: ");
                    var dept = Console.ReadLine();

                    Console.WriteLine("Select Type: 1. Full-Time  2. Contract");
                    var type = Console.ReadLine();

                    Employee newEmployee;

                    if (type == "1")
                    {
                        Console.Write("Base Salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine());

                        Console.Write("Bonus: ");
                        decimal bonus = decimal.Parse(Console.ReadLine());

                        newEmployee = new FullTimeEmployee
                        {
                            Id = Employee.GetRandomString("FUL"),
                            Name = name,
                            Department = dept,
                            BaseSalary = salary,
                            BonusProperty = bonus
                        };
                    }
                    else
                    {
                        Console.Write("Hourly Rate: ");
                        decimal rate = decimal.Parse(Console.ReadLine());

                        Console.Write("Hours Worked: ");
                        decimal hours = decimal.Parse(Console.ReadLine());

                        newEmployee = new ContractEmployee
                        {
                            Id = Employee.GetRandomString("CON"),
                            Name = name,
                            Department = dept,
                            HourlyRate = rate,
                            HoursWorked = hours
                        };
                    }

                    bool added = employeeService.AddEmployee(newEmployee);
                    Console.WriteLine(added ? "Added successfully" : "Failed to add");
                }
                    break;
                case "3":
                {

                    Console.Write("Enter Employee ID: ");
                    string id = Console.ReadLine();

                    Console.Write("Enter New Base Salary: ");
                    int salary = int.Parse(Console.ReadLine());

                    Console.Write("Enter Bonus (0 if none): ");
                    int bonus = int.Parse(Console.ReadLine());

                    bool updated = employeeService.UpdateSalary(id, salary, bonus);
                    Console.WriteLine(updated ? "Updated successfully" : "Failed");
                }

                    break;

                case "4":
                    Console.Write("Enter Employee ID: ");
                    string removeId = Console.ReadLine();

                    bool removed = employeeService.RemoveEmployee(removeId);
                    Console.WriteLine(removed ? "Removed" : "Not found");
                    break;

                case "0":
                    return;
            }
        }
    }


    // PAYROLL MENU
    // -------------------------------
    private void PayrollMenu()
    {
        var payrollService = new PayrollService();
        
        while (true)
        {
            
            Console.WriteLine("\n--- PAYROLL MENU ---");
            Console.WriteLine("1. Process Payroll");
            Console.WriteLine("2. View Payroll History");
            Console.WriteLine("0. Back");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Employee ID: ");
                    string id = Console.ReadLine();
                    

                    bool success = payrollService.ProcessPayroll(id);
                    Console.WriteLine(success ? "Processed successfully" : "Invalid ID");
                    break;

                case "2":
                   

                    var records = payrollService.GetPayrollHistory();
                    foreach (var p in records)
                        Console.WriteLine($"{p.EmployeeName} | {p.AmountPaid} | {p.PaymentDate}");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    private bool AdminLogin()
    {
        Console.Write("Admin ID: ");
        string id = Console.ReadLine();

        Console.Write("Password: ");
        string pass = Console.ReadLine();

        var authService = new AuthService();
        if (!authService.Login(id, pass))
        {
            Console.WriteLine("Access Denied");
            return false;
        }

        return true;
    }

    private void AdminMenu()
    {
        var adminService = new AdminService();

        while (true)
        {
            Console.WriteLine("\n--- ADMIN MENU ---");
            Console.WriteLine("1. Total Payroll");
            Console.WriteLine("2. Highest Salary");
            Console.WriteLine("3. Average Salary");
            Console.WriteLine("4. Top 5 Earners");
            Console.WriteLine("5. Department Distribution");
            Console.WriteLine("6. Salary Ranking");
            Console.WriteLine("7. Check Department Exists");
            Console.WriteLine("8. List Departments");
            Console.WriteLine("0. Back");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine(adminService.GetTotalPayroll());
                    break;

                case "2":
                    var top = adminService.GetHighestPaid();
                    if (top == null)
                        Console.WriteLine("No payroll data yet");
                    else
                        Console.WriteLine($"{top.EmployeeName} - {top.AmountPaid}");
                    break;

                case "3":
                    Console.WriteLine(adminService.GetAverageSalary());
                    break;

                case "4":
                    var top5 = adminService.GetTop5Earners();
                    foreach (var p in top5)
                        Console.WriteLine($"{p.EmployeeName} - {p.AmountPaid}");
                    break;

                case "5":
                {
                    var dept = adminService.GetDepartmentAnalytics();

                    foreach (var d in dept)
                    {
                        dynamic item = d;

                        Console.WriteLine(
                            $"Department: {item.Department} | " +
                            $"Employees: {item.EmployeeCount} | " +
                            $"Total Salary: {item.TotalSalary}"
                        );
                    }
                }
                    break;

                case "6":
                    var ranking = adminService.GetSalaryRanking();
                    foreach (var e in ranking)
                        Console.WriteLine($"{e.Name} - {e.CalculatePay()}");
                    break;

                case "7":
                {
                    Console.Write("Enter Department: ");
                    string d = Console.ReadLine();
                    Console.WriteLine(adminService.DepartmentExists(d));
                }
                    break;

                case "8":
                    var list = adminService.GetAllDepartments();
                    foreach (var dep in list)
                        Console.WriteLine(dep);
                    break;

                case "0":
                    return;
            }
        }
    }









} 



