/*Programmieren Sie eine Konsolen-Variante des Spiels "Wordle".

Am Anfang des Spiels wird ein zufälliges Wort, welches
aus genau 5 Buchstaben besteht vom Spiel ausgewählt.
(Hierfür wäre eine Liste von Worten mit 5 Buchstaben
gut, aus der ausgewählt werden kann).

Danach hat der Spieler maximal 6 Versuche, das Wort
zu erraten.

Nach jeder Eingabe wird überprüft, ob die Buchstaben,
welche der Anwender eingegeben hat, in dem Wort vorkommen
und ob sie an der richtigen Stelle stehen.

Buchstaben, welche im gesuchten Wort vorkommen, aber nicht
an der richtigen Stelle stehen, sollen gelb eingefärbt werden.

Buchstaben, welche im gesuchten Wort vorkommen und an der
richtigen Stelle stehen, sollen grün eingefärbt werden.

Diese Informationen sollen dem Anwender angezeigt werden,
bevor er ein neues Wort eingibt.

Ein Beispiel:
Zu findendes Wort: Salbe
1. Versuch: Nabel

Bei diesem Beispiel würde der Buchstabe "a" grün eingefärbt
werden, da er im gesuchten Wort vorkommt und an 2. Stelle
steht, wie auch im gesuchten Wort "Salbe".
Die Buchstaben "b", "e" und "l" würden gelb eingefärbt werden,
weil sie in "Salbe" vorkommen, aber an der falschen stelle
stehen.
Der Buchstabe "N" bleibt wie er ist, da er in "Salbe" nicht
vorkommt.

Der Anweder soll auch alle vorherigen Versuche immmer angezeigt
bekommen (Korrekt eingefärbt).

Sollte der Anwender das Wort in maximal 6 Versuchen erraten,
hat er gewonnen, andernfalls nicht.

Viel Erfolg!*/

namespace Wordle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int anzahlVersuche = 6, count = anzahlVersuche;

            string[] worten = { "GLANZ", "TRAUM", "FLUCH", "STADT", "LICHT", "STURM", "BLUME", "SPITZ", "FREUD", "KUNST", "STAAT", "PUPPE", "MESSE", "MIETE", "MITTE" };
            string[] gewählteWorten = new string[anzahlVersuche];
            Random rand = new Random();
            string gesuchtesWort = worten[rand.Next(0, worten.Length)], wortVonBenutzer = "";
            char[] gesuchtesWortInArr = gesuchtesWort.ToCharArray();

            Begruessung(anzahlVersuche);

            for (int i = 0; i < anzahlVersuche; i += 1)
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Schreib einfach ein Wort: ");

                    wortVonBenutzer = (Console.ReadLine() ?? "").Trim().ToUpper();

                    if (wortVonBenutzer.Length != 5) Console.WriteLine("Das gesuchte Wort besteht aus 5 Buchstaben.\n");
                    else
                    {
                        Console.Clear();

                        Begruessung(--count);

                        gewählteWorten[i] = wortVonBenutzer;

                        foreach (string elem in gewählteWorten)
                        {
                            char[] iterator = (char[])gesuchtesWortInArr.Clone();
                            if (elem == null) continue;

                            for (int j = 0; j < elem.Length; j += 1)
                            {
                                if (elem[j] == gesuchtesWort[j])
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(elem[j]);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    iterator[j] = '_';
                                }
                                else if (iterator.Contains(elem[j]) && Array.LastIndexOf(iterator, elem[j]) != gewählteWorten[i].LastIndexOf(elem[j]))
                                {

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(elem[j]);
                                    Console.ForegroundColor = ConsoleColor.White;

                                    iterator[Array.IndexOf(iterator, elem[j])] = '_';

                                }
                                else Console.Write(elem[j]);

                            }

                            Console.WriteLine();
                        }
                    }
                }
                while (wortVonBenutzer.Length != 5);


                if (gewählteWorten[i] == gesuchtesWort)
                {
                    Console.WriteLine($"\nGlückwunsch! Du hast das Wort in {i + 1} Versuchen erraten. Super gemacht! ");
                    break;
                }
                else if (i == anzahlVersuche - 1)
                {
                    Console.WriteLine("\nLeider hast du das Wort nicht erraten. Versuch es doch gleich noch einmal – du schaffst das! ");
                }

            }



            void Begruessung(int versuch)
            {
                Console.WriteLine("Willkommen beim Spiel \"Wordle\"");

                Console.WriteLine();

                Console.Write("Du hast jetzt ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{versuch}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Versuche, um das Wort zu erraten.\n");

                Console.WriteLine("Das gesuchte Wort besteht aus 5 Buchstaben.");

                Console.WriteLine("Nach jedem Versuch überprüft das Spiel, ob die eingegebenen Buchstaben\nim gesuchten Wort vorhanden sind und ob sie an der richtigen Stelle stehen.\n");

                Console.WriteLine("Buchstaben, die im gesuchten Wort vorkommen,\naber an der falschen Stelle sind, werden gelb markiert.\n");

                Console.WriteLine("Buchstaben, die im gesuchten Wort vorkommen\nund an der richtigen Stelle stehen, werden grün markiert.\n");

                Console.WriteLine("-----------------------------------");

                Console.WriteLine();
            }

        }
    }
}
