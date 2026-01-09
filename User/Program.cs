using Namen;
using admin;
using casualUser;
namespace user;

public class User
{
    public static void main()
    {
        if (namenAbfrage.main() == "Admin")
        {
            Admin.admin();
        }
        else
        {
            CasualUser.main();
        }
    }
}