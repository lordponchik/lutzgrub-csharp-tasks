/* Programmiere ein Schere, Stein, Papier Spiel.  

Der User soll eines der Handzeichen wählen können. 

Der Computer wählt per Zufall ein eigenes Zeichen. 

Dem User wird dann ausgegeben, welches Zeichen der Computer gewählt hat und ob man gewonnen, verloren oder ein Unentschieden hat. 

Danach kann sich der User entscheiden eine weitere Runde zu spielen, oder nicht. */

namespace Schere_Stein_Papier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] handzeichen = { "schere", "stein", "papier" };
            Random zufallHanzeichen = new Random();

            bool istEntsprechendeWerte = false, spielGestartet = true;

            Console.WriteLine("Willkommen");

            while (spielGestartet)
            {
                string computerWahl = handzeichen[zufallHanzeichen.Next(0, handzeichen.Length)];

                do
                {
                    Console.WriteLine("(0) - Schere");
                    Console.WriteLine("(1) - Stein");
                    Console.WriteLine("(2) - Papier");
                    Console.Write("Gib einfach die Zahl oder schreib ein Wort: ");

                    string benutzerWahl = (Console.ReadLine() ?? "").Trim().ToLower();

                    if (int.TryParse(benutzerWahl, out int i) && i <= 2 && i >= 0)
                    {
                        benutzerWahl = handzeichen[i];
                    }

                    istEntsprechendeWerte = true;

                    switch (benutzerWahl)
                    {

                        case "schere":
                            if (computerWahl == "schere") Console.WriteLine("unentschieden");
                            if (computerWahl == "stein") Console.WriteLine("verloren");
                            if (computerWahl == "papier") Console.WriteLine("gewonnen");
                            break;
                        case "stein":
                            if (computerWahl == "stein") Console.WriteLine("unentschieden");
                            if (computerWahl == "papier") Console.WriteLine("verloren");
                            if (computerWahl == "schere") Console.WriteLine("gewonnen");
                            break;
                        case "papier":
                            if (computerWahl == "papier") Console.WriteLine("unentschieden");
                            if (computerWahl == "schere") Console.WriteLine("verloren");
                            if (computerWahl == "stein") Console.WriteLine("gewonnen");
                            break;
                        default:
                            Console.WriteLine("Leider verstehe ich nicht. Versuch nochmal.");
                            istEntsprechendeWerte = false;
                            break;
                    }
                    //  gewonnen verloren unentschieden
                } while (!istEntsprechendeWerte);
                Console.WriteLine();

                Console.WriteLine("Drücken Sie <Enter>, wenn Sie das Programm beenden möchten, \n " +
                    "oder eine andere Taste, um es erneut zu versuchen: ");

                // optional: das Programm wird dauernd wiederholt
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    spielGestartet = !spielGestartet;
                }

                Console.Clear();
            }
        }
    }
}