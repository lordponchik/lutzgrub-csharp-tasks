/*
Schreiben Sie ein Programm, welches das Spiel "Warm oder Kalt" simuliert.
Das soll wie folgt funktionieren:
- Das Programm bestimmt eine zufällige ganze Zahl zwischen 1 und 100
- Der Spieler/Anwender soll diese Zahl nun erraten, indem er eine Zahl eingibt
- nun wird der vorherige Versuch (falls es einen gab, es also nicht der erste Versuch war) mit dem aktuellen Versuch verglichen werden:
- ist man näher dran als bei dem vorherigen Versuch: wärmer
- ist man weiter weg als bei dem vorherigen Versuch: kälter
- Errät der Spieler die Zahl, hat er gewonnen
- Nachdem die Zahl erraten wurde, soll die Anzahl der Versuche ausgegeben werden (damit man zu anderen Spielern einen Vergleich hat)
- Am Ende des Programms soll der Spieler gefragt werden, ob er noch eine Partie spielen möchte
Optional:
- Am Anfang des Programms kann der Spieler auch einen "Hardmode" auswählen.
- Das bedeutet, dass die gesuchte Zahl zwischen 1 und 1800 liegt
Viel Erfolg-
*/

namespace Warm_Kalt
{
    class Program
    {
        enum Spiellvl
        {
            Anfänger,
            Hardmode
        }
        static void Main(string[] args)
        {
            int modi, maxZahl = 0, anzahlVersuch = 0;
            int letzteZahl = 0, aktuelleZahl = 0, randomZahl = 0;
            bool neuesSpiel = true, gibtEsModi = false;
            string jeinAntwort = "";

            Console.Clear();
            Console.WriteLine("Willkommen beim Spiel „Rate die Zahl“");
            Console.WriteLine($"Es gibt zwei Spielmodi:\nAnfänger - Sie müssen eine Zahl zwischen 1 und 100 erraten.\nHardmode - Sie müssen eine Zahl zwischen 1 und 1000 erraten.");


            while (neuesSpiel)
            {
                Console.WriteLine();

                // Wähl Modi
                do
                {
                    modi = IstZahl("Geben Sie einfach\nFür den Anfängermodus 0\nFür den Hardmode 1\nein: ");

                    gibtEsModi = modi != (int)Spiellvl.Anfänger && modi != (int)Spiellvl.Hardmode;

                    if (gibtEsModi) Console.WriteLine("\nLeider verstehe ich nicht. Versuchen Sie nochmal.\n");
                } while (gibtEsModi);

                // Random Zahl
                if (modi == (int)Spiellvl.Anfänger)
                {
                    maxZahl = 100;
                    randomZahl = new Random().Next(1, maxZahl + 1);
                }
                else if (modi == (int)Spiellvl.Hardmode)
                {
                    maxZahl = 1000;
                    randomZahl = new Random().Next(1, maxZahl + 1);
                }

                Console.WriteLine("\nSpiel wurde begonnen.\n");

                // Spiel 
                do
                {
                    aktuelleZahl = IstZahl($"Geben Sie die Zahl von 1 bis {maxZahl} ein: ");
                    if (aktuelleZahl == randomZahl)
                    {
                        anzahlVersuch += 1;
                        Console.WriteLine($"\nGlückwunsch. Sie haben es erraten.\nEs gab insgesamt {anzahlVersuch} Versuche\n");
                        break;
                    }
                    if (anzahlVersuch == 0)
                    {
                        Console.WriteLine("\nLeider haben Sie beim ersten Versuch nicht richtig geraten. Probiern Sie nochmal aus\n");
                        anzahlVersuch += 1;
                        letzteZahl = aktuelleZahl;
                    }
                    else
                    {
                        if (Math.Abs(letzteZahl - randomZahl) > Math.Abs(aktuelleZahl - randomZahl)) Console.WriteLine("Wärmer\n");
                        else Console.WriteLine("Kälter\n");

                        anzahlVersuch += 1;
                        letzteZahl = aktuelleZahl;
                    }

                } while (aktuelleZahl != randomZahl);


                //Neues Spiel?
                do
                {
                    Console.Write("Möchten Sie nocmal spielen. Schreiben Sie einfach ja oder nein: ");

                    jeinAntwort = Console.ReadLine().ToLower();

                    if (jeinAntwort == "ja") anzahlVersuch = 0;
                    else if (jeinAntwort == "nein")
                    {
                        Console.WriteLine("Vielen Dank für Ihr Spiel.");
                        neuesSpiel = false;
                    }
                    else
                    {
                        Console.WriteLine("Leider verstehe ich nicht. Versuchen Sie nochmal.\n");
                    }


                } while (jeinAntwort != "ja" && jeinAntwort != "nein");


                static int IstZahl(string nachricht)
                {
                    int zahl;
                    bool prüfungZahl;

                    do
                    {
                        Console.Write(nachricht);

                        prüfungZahl = int.TryParse(Console.ReadLine(), out zahl);

                        if (!prüfungZahl) Console.WriteLine("\nLeider verstehe ich nicht. Versuchen Sie nochmal.\n");

                    } while (!prüfungZahl);
                    return zahl;
                }
            }
        }
    }
}