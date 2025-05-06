/* Programmiere in C# nur mit der nutzung von Arrays folgendes:
In einem Lagersystem hat 100 Plätze. Über ein Menü können wir 
Bauteile und schrauben über die Konsole in unser Lagersysten eintragen. 
Wenn ein Lagerplatz bereits belegt ist soll darauf verwiesen werden das element woander zu lagern. 
Wir können über die Lagerplatznummer uns auch Elemente anfordern die wir dann entfernen können wen wir das wollen. 
und wir müssen die möglichkeit haben Das Lager auszugeben in der Konsole.
*/
using static System.Console;

namespace Lagersystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string?[] lager = new string[100];
            bool istZahl = false;
            int platznummer;

            while (true)
            {
                WriteLine("---Lagerverwaltung Menü---");
                WriteLine("1.Bauteil oder Schraube einlagern\r\n" +
                          "2.Element anzeigen\r\n" +
                          "3.Element entfernen\r\n" +
                          "4.Gesamtes Lager anzeigen\r\n" +
                          "5.Beenden");
                Write("Bitte wählen Sie eine Option(1 - 5): ");

                string opt = (ReadLine() ?? "").Trim();

                switch (opt)
                {
                    case "1":

                        if (Array.IndexOf(lager, null) == -1)
                        {
                            WriteLine("\nLeider gibt es kein Platz.\n");
                            break;
                        }
                        ;

                        Write("\nWas möchten Sie einlagern (Bauteil / Schraube)? ");
                        string el = (ReadLine() ?? "").Trim(); //Bauteil / Schraube
                        el = el[0].ToString().ToUpper() + el.Substring(1).ToLower();

                        do
                        {
                            Write("\nAuf welchen Lagerplatz (1–100) möchten Sie das Element legen? ");
                            istZahl = int.TryParse(ReadLine(), out platznummer);

                            if (!istZahl) WriteLine("\nLeider ist das keine Zahl. Versuchen Sie nochmal.");
                            else if (platznummer > lager.Length || platznummer <= 0)
                            {
                                WriteLine("\nUngültige Lagerplatznummer.");
                                istZahl = !istZahl;
                            }
                            else if (lager[platznummer - 1] != null)
                            {
                                WriteLine("\nIst dieser Platz belegt. Bitte wählen Sie ein anderes aus.");
                                WriteLine($"Der freie Lagerplatz ist Nummer {Array.IndexOf(lager, null) + 1}.");
                                istZahl = !istZahl;
                            }
                        } while (!istZahl);

                        lager[platznummer - 1] = el;

                        WriteLine($"\n{el} wurde erfolgreich auf Lagerplatz {platznummer} eingelagert.\n");
                        break;
                    case "2":
                        do
                        {
                            Write("\nBitte geben Sie eine Zahl zwischen 1 und 100 ein: ");
                            istZahl = int.TryParse(ReadLine(), out platznummer);

                            if (!istZahl) WriteLine("\nLeider ist das keine Zahl. Versuchen Sie nochmal.\n");
                            if (platznummer > lager.Length && platznummer <= 0)
                            {
                                WriteLine("\nUngültige Lagerplatznummer.\n");
                                istZahl = !istZahl;
                            }
                        } while (!istZahl);

                        WriteLine($"\nPlatz {platznummer}: {lager[platznummer - 1] ?? "leer"}\n");
                        break;
                    case "3":
                        do
                        {
                            Write("\nBitte geben Sie eine Zahl zwischen 1 und 100 ein: ");
                            istZahl = int.TryParse(ReadLine(), out platznummer);

                            if (!istZahl) WriteLine("\nLeider ist das keine Zahl. Versuchen Sie nochmal.\n");
                            if (platznummer > lager.Length && platznummer <= 0)
                            {
                                WriteLine("\nUngültige Lagerplatznummer.\n");
                                istZahl = !istZahl;
                            }
                        } while (!istZahl);

                        lager[platznummer - 1] = null;

                        WriteLine($"\nLagerplatz {platznummer} ist jetzt frei.\n");
                        break;
                    case "4":
                        WriteLine();
                        for (int i = 0; i < lager.Length; i += 1)
                        {
                            string inhalt = lager[i] ?? "leer";

                            Write($"[{i + 1:D3}:{inhalt,-9}] ");

                            if ((i + 1) % 5 == 0) WriteLine();
                        }
                        WriteLine();
                        break;
                    case "5":
                        return;
                    default:
                        WriteLine("\nLeider verstehe ich nicht. Versuchen Sie nochmal.\n");
                        break;
                }
            }
        }
    }
}