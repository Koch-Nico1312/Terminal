using Namen;
using admin;
using casualUser;
namespace user;

public class User
{
    public static void main()
    {
        if (namenAbfrage.main() == "NicoA")
        {
            Admin.admin();
        }
        else
        {
            CasualUser.main();
        }
    }
}