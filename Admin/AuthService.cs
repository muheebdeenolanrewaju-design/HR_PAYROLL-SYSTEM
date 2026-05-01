namespace HR_PAYROLL_SYSTEM.Services;

public class AuthService
{
    private readonly string _adminId = "ADM111";
    private readonly string _password = "0419";

    public bool Login(string adminId, string password)
    {
        return adminId == _adminId && password == _password;
    }
}