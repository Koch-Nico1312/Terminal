using Namen;
using admin;
using casualUser;
namespace user;

public class User
{
    namenAbfrage n = new namenAbfrage();
    Admin a = new Admin();
    CasualUser c = new CasualUser();
    public void user()
    {
        n.main();
        if (n.name == "Admin")
        {
            a.admin();
        }
        else
        {
            c.main();
        }
    }
}