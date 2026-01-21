using Namen;
using admin;
using casualUser;
namespace user;

public class User
{
    public static void user()
    {
        string name = namenAbfrage.main();
        if (name == "NicoA" || name == "PALI")
        {
            Admin.admin();
        }
        else
        {
            CasualUser.main();
        }
    }
}