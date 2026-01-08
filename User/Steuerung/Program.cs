namespace Steuerung;

public class MenuSteuerung
{
    public int Auswaehlen(){
        
        string[] options = { "Option 1", "Option 2", "Option 3", "Option 4" };
        int selectedIndex = 0;

        ConsoleKey key;

        do
        {
            Console.Clear();;

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

        } while (key != ConsoleKey.Enter);
        return selectedIndex;
    }
}
