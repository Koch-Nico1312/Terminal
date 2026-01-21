using Namen;
using admin;
using casualUser;
namespace user;

public class User
{
    namenAbfrage n = new namenAbfrage();
    Admin a = new Admin();
    CasualUser c = new CasualUser();
    public static void user()
    {
        if (namenAbfrage.main() == "NicoA" ||namenAbfrage.main() == "PALI")
        {
            Admin.admin();
        }
        else
        {
            CasualUser.main();
        }
    }
}