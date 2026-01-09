using Buchstaben;
using System.IO;
using System.Threading;
using System.Diagnostics;
namespace anzeigen
{

    public class Anzeigen
    {
        public static void showAdminInfos()
        {
            int number = 0;
            DriveInfo drive = new DriveInfo("C");
            string user = Environment.UserName;
            long freeSpaceGB = drive.AvailableFreeSpace / (1024 * 1024 * 1024);
            long totalSpaceGB = drive.TotalSize / (1024 * 1024 * 1024);

            float cpuValue = 0;
            float ramValue = 0;

            try
            {
                using (var cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
                using (var ram = new PerformanceCounter("Memory", "Available MBytes"))
                {
                    cpu.NextValue();
                    Thread.Sleep(1000);
                    cpuValue = cpu.NextValue();
                    ramValue = ram.NextValue();
                }
            }
            catch
            {
                // PerformanceCounter ist möglicherweise nicht verfügbar
            }

            string[] admin =
                {
                $"Du hast: {freeSpaceGB} GB Speicherplatz frei.",
                $"Du bist auf der {drive.Name} Festplatte.",
                $"Du bist mit {user} angemeldet.",
                $"CPU: {cpuValue:0.0}%   ",
                $"RAM frei: {ramValue:0} MB   "
            };

            Console.SetCursorPosition(0, 0);
            Console.WriteLine(Variablen.xxlHello);

            
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(110, number);
                Console.Write("|");
                number++;
            }

            for (int i = 0; i < admin.Length; i++)
            {
                Console.SetCursorPosition(120, 8 + i);
                Console.Write(admin[i]);
            }

        }
    }
}