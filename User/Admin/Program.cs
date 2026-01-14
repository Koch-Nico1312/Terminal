using System.Security.Cryptography.X509Certificates;
using Namen;
using Steuerung;
using Buchstaben;
using anzeigen;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using System.Net.Http;
using System.Reflection;
using AI;
namespace admin;


public class Admin
{

    public static void admin()
    {

        string[] options =
        {
            "Youtube schauen",
            "Serie schauen",
            "Schule",
            "AI",
            "Beenden"
        };

        string[] optionsSchule =
        {
          "VS Code",
          "Edufs",
          "Zurück",
        };

        string[] optionsSerie =
        {
            "Mentalist",
            "Originals",
            "Zurück"
        };

        string[] urls =
        {
            "Platzhalter",
            "www.youtube.com",
            "https://www.joyn.at/serien/the-mentalist",
            "https://www.joyn.at/serien/the-originals",
            "https://edufs.edu.htl-leonding.ac.at",
        };

        var auswahl = MenuSteuerung.AuswaehlenAdmin(options);

        switch (auswahl)
        {
            case 0:
                var youtube = new ProcessStartInfo
                {
                    FileName = "firefox",
                    Arguments = urls[1],
                    UseShellExecute = true,
                };
                Process.Start(youtube);
                break;
            case 1:
                auswahl = MenuSteuerung.AuswaehlenAdmin(optionsSerie);
                switch (auswahl)
                {
                    case 0:
                        var mentalist = new ProcessStartInfo
                        {
                            FileName = "firefox",
                            Arguments = urls[2],
                            UseShellExecute = true,
                        };
                        Process.Start(mentalist);
                        break;
                    case 1:
                        var originals = new ProcessStartInfo
                        {
                            FileName = "firefox",
                            Arguments = urls[3],
                            UseShellExecute = true,
                        };
                        Process.Start(originals);
                        break;
                    case 2:
                        admin();
                        break;
                }
                break;
            case 2:
                auswahl = MenuSteuerung.AuswaehlenAdmin(optionsSchule);
                switch (auswahl)
                {
                    case 0:
                        var vscode = new ProcessStartInfo
                        {
                            FileName = "code",
                            UseShellExecute = true,
                        };
                        Process.Start(vscode);
                        break;
                    case 1:
                        var edufs = new ProcessStartInfo
                        {
                            FileName = "firefox",
                            Arguments = urls[4],
                            UseShellExecute = true,
                        };
                        Process.Start(edufs);
                        break;
                    case 2:
                        admin();
                        break;
                }
                break;
            case 3:
                AIChat.Start().Wait();
                admin();  
                break;
            case 4:
                break;
        }
    }
}