using System.Reflection.Metadata.Ecma335;
using Buchstaben;
using anzeigen;
namespace Steuerung;

public class MenuSteuerung
{
    public static int Auswaehlen(string[] options)
    {
        int selectedIndex = 0;
        ConsoleKey key;

        do
        {
            Console.Clear();

            
            Console.WriteLine(Variablen.xxlHello);

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"> {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {options[i]}");
                }
            }

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (selectedIndex > options.Length - 1)
            {
                selectedIndex = 0;
                
            }

        } while (key != ConsoleKey.Enter);
        return selectedIndex;
    }
    public static int AuswaehlenAdmin(string[] options)
    {
        int selectedIndex = 0;

        ConsoleKey key;

        do
        {
            Console.Clear();

            Anzeigen.showAdminInfos();

            Console.SetCursorPosition(0,10);

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"  {options[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {options[i]}");
                }
            }

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (selectedIndex > options.Length - 1)
            {
                selectedIndex = 0;
                
            }

        } while (key != ConsoleKey.Enter);
        return selectedIndex;
    }
}
