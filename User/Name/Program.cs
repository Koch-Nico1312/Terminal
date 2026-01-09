namespace Namen;
public class namenAbfrage
{
    public static string main()
    {
        Console.Clear();
        
        Console.WriteLine("Gib deinen Namen ein:");

        Console.ForegroundColor = ConsoleColor.Green;
        string name = Console.ReadLine()!;
        Console.ResetColor();

        return name;
    }
}