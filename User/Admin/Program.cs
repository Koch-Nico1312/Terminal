using System.Security.Cryptography.X509Certificates;
using Namen;
using Steuerung;
using Buchstaben;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
namespace admin;


public class Admin
{
    public static void admin()
    {
        string[] options =
        {
            "Youtube schauen",
            "Serie schauen",
            "VS Code",
            "Beenden"
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
            "https://www.joyn.at/serien/the-originals"
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
                Process.Start(@"C:\Users\kochn_lrehka5\Desktop\Microsoft VS Code\Code.exe");
                break;
            case 3:
                break;        
        }
    }
}