using System.Security.Cryptography.X509Certificates;
using Namen;
using Steuerung;
using Buchstaben;
namespace admin;


public class Admin
{
    namenAbfrage n = new namenAbfrage();
    MenuSteuerung m = new MenuSteuerung();
    Variablen v = new Variablen();
    
    public void admin()
    {
        string [] options = {};
        DriveInfo drive = new DriveInfo("C");
        long freeSpaceGB = drive.AvailableFreeSpace / (1024 * 1024 * 1024);
        long totalSpaceGB = drive.TotalSize / (1024 * 1024 * 1024);

        m.Auswaehlen();
    }
}