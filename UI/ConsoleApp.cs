using HR_PAYROLL_SYSTEM.Services;
using HR_PAYROLL_SYSTEM.Admin;

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

                case "3":
                    Console.Write("Enter Employee ID: ");
                    string id = Console.ReadLine();

                    Console.Write("Enter New Base Salary: ");
                    int salary = int.Parse(Console.ReadLine());

                    Console.Write("Enter Bonus (0 if none): ");
                    int bonus = int.Parse(Console.ReadLine());

                    bool updated = employeeService.UpdateSalary(id, salary, bonus);
                    Console.WriteLine(updated ? "Updated successfully" : "Failed");
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
                    var dept = adminService.GetDepartmentAnalytics();
                    Console.WriteLine(dept);
                    break;

                case "6":
                    var ranking = adminService.GetSalaryRanking();
                    foreach (var e in ranking)
                        Console.WriteLine($"{e.Name} - {e.CalculatePay()}");
                    break;

                case "7":
                    Console.Write("Enter Department: ");
                    string d = Console.ReadLine();
                    Console.WriteLine(adminService.DepartmentExists(d));
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



