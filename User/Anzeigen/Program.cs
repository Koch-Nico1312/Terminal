using Buchstaben;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
namespace anzeigen;


public class Anzeigen
{
    public static void showAdminInfos()
    {
        int number = 0;

        DriveInfo drive = new DriveInfo("C");
        string user = Environment.UserName;
        long freeSpaceGB = drive.AvailableFreeSpace / (1024 * 1024 * 1024);
        long totalSpaceGB = drive.TotalSize / (1024 * 1024 * 1024);
        float ramValue = 0;

        string[] admin =
        {
                $"Du hast: {freeSpaceGB} GB Speicherplatz frei.",
                $"Du bist auf der {drive.Name} Festplatte.",
                $"Du bist mit {user} angemeldet.",
                $"RAM frei: {ramValue:0} MB   "
            };

        Console.SetCursorPosition(0, 0);
        Console.WriteLine(Variablen.xxlHello);

        for (int i = 0; i < 20; i++)
        {
            Console.SetCursorPosition(60, number);
            Console.Write("|");
            number++;
        }

        for (int i = 0; i < admin.Length; i++)
        {
            Console.SetCursorPosition(80, 8 + i);
            Console.Write(admin[i]);
            number = 8 + i;
        }

        Console.SetCursorPosition(80, number);
        Console.WriteLine($"Aktuelle Uhrzeit: {DateTime.Now.ToString("HH:mm:ss")}");
        
        Console.SetCursorPosition(80, number + 1);
        Console.WriteLine($"Datum: {DateTime.Now.ToString("dd.MM.yyyy")}");
    }
}
