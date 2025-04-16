/*
Taschen-Rechner

Schreiben Sie ein Programm, das zwei Zahlen einliest und anschließend mit Hilfe
einer Switch-Anweisung ein Menü anbietet, in welchem der Benutzer zwischen
den 4 Grundrechnungsarten wählen kann. Inkludieren Sie einen Menüpunkt für
einen Abbruch des Programmes.

Nach entsprechender Wahl soll der Anwender das Ergebnis (wenn mathematisch möglich)
ausgegeben bekommen.

Nach der Ausgabe der Berechnung soll das Programm automatisch von neuem starten.


optional: Das Programm wird dauernd wiederholt 
optional: DAU-Sicherheit der Eingaben 
optional: Sicherstellen, dass eine Berechnung mathematisch möglich ist 

// super-optional: Korrekte Berechnung mit 3 Zahlen: ✅
// Beachten Sie Punkt-vor-Strich ✅
*/

namespace Taschen_Rechner_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] zahlen = new double[3];
            double ergebnis = 0;
            string[] rechenart = new string[2];
            bool berechnungGestartet = true;

            while (berechnungGestartet)
            {
                ergebnis = 0;
                Console.WriteLine("Willkommen in unserem Taschenrechner!\n");

                for (int i = 0; i < 3; i += 1)
                {

                    bool istNotwendigerWert = false;

                    do
                    {
                        Console.Write($"Geben Sie eine Zahl_{i + 1}: ");

                        istNotwendigerWert = double.TryParse(Console.ReadLine()?.Replace(".", ","), out zahlen[i]);

                        if (!istNotwendigerWert)
                        {
                            Console.WriteLine("Das ist keine Zahl. Versuchen Sie nochmal\n");
                        }
                    }
                    while (!istNotwendigerWert);

                    Console.WriteLine();

                    if (i != 2)
                    {
                        do
                        {
                            Console.WriteLine("Rechenarten: ");
                            Console.WriteLine("(+) plus");
                            Console.WriteLine("(-) minus");
                            Console.WriteLine("(*) mal");
                            Console.WriteLine("(/) durch");

                            Console.Write("Geben Sie ein Rechenart: ");

                            rechenart[i] = Console.ReadLine() ?? "";

                            istNotwendigerWert = rechenart[i] != "+" && rechenart[i] != "-" && rechenart[i] != "*" && rechenart[i] != "/";

                            if (istNotwendigerWert)
                            {
                                Console.WriteLine("\nLeider ist dies keine der vorgeschlagenen Rechnenarten. " +
                               "Versuchen Sie nochmal");
                            }

                        } while (istNotwendigerWert);
                    }
                }


                if (rechenart[0] == "+" || rechenart[0] == "-" && rechenart[1] == "/" || rechenart[1] == "*")
                {
                    Array.Reverse(zahlen);
                    Array.Reverse(rechenart);
                }

                if ((zahlen[1] == 0 || zahlen[2] == 0) && (rechenart[0] == "/" || rechenart[1] == "/"))
                {
                    Console.WriteLine("Leider ist eine Division durch Null nicht möglich.");
                }
                else
                {
                    for (int i = 0; i < zahlen.Length; i += 1)
                    {
                        if (i == 0)
                        {
                            ergebnis += zahlen[i];
                            continue;
                        }

                        switch (rechenart[i - 1])
                        {
                            case "+":
                                ergebnis += zahlen[i];
                                break;
                            case "-":
                                ergebnis -= zahlen[i];
                                break;
                            case "*":
                                ergebnis *= zahlen[i];
                                break;
                            case "/":
                                ergebnis /= zahlen[i];
                                break;


                        }
                    }

                    Console.WriteLine($"Ergebnis ist {ergebnis}");
                }

                Console.WriteLine("\nDrücken Sie <Escape>, wenn Sie das Programm beenden möchten, \n " +
                    "oder eine andere Taste, um es erneut zu versuchen: ");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    berechnungGestartet = !berechnungGestartet;
                }

                Console.Clear();

            }
        }
    }

}

