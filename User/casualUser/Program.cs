//Author: Nico Koch
//Workspace

using System.Diagnostics;
using Buchstaben;
using Steuerung;
using Namen;
namespace casualUser;

public class CasualUser
{
Variablen v = new Variablen();
namenAbfrage n = new namenAbfrage();
CasualUser c = new CasualUser();
MenuSteuerung m = new MenuSteuerung();

public string[] options = { "Privat", "Schule", "Beenden" };

public void mainPrivat()
{
    string[] options = {"YouTube","Zurück" };

    string[] urls = new string[]
    {
        "Platzhalter",
        "https://www.youtube.com",
    };

    var auswahl = m.Auswaehlen();

    if (auswahl == 0)
    {
        var youtube = new ProcessStartInfo
        {
            FileName = "firefox",
            Arguments = urls[1],
            UseShellExecute = true,
        };
        Process.Start(youtube);
    }
    else if (auswahl == 1)
    {
        c.main();
    }
}

public void mainSchool()
{
    string[] options = { "EDUFS", "VS Code", "Zurück" };

    string[] urls = new string[]
    {
        "Platzhalter",
        "https://edufs.edu.htl-leonding.ac.at/moodle",
    };

    var auswahl = m.Auswaehlen();

    if (auswahl == 0)
    {
        var edufs = new ProcessStartInfo
        {
            FileName = "firefox",
            Arguments = urls[1],
            UseShellExecute = true,
        };
        Process.Start(edufs);
    }
    else if (auswahl == 1)
    {
        string pfad = @"C:\Users\kochn\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Visual Studio Code\Visual Studio Code.lnk";
        Process.Start(pfad);
    }
    else if (auswahl == 2)
    {
        c.main();
    }
}

public void main()
{
    while (true)
    {
        var auswahl = m.Auswaehlen();

        if (auswahl == 0)
        {
            c.mainPrivat();
        }
        else if (auswahl == 1)
        {
            c.mainSchool();
        }
        else if (auswahl == 2)
        {
            break;
        }
    }
}
}