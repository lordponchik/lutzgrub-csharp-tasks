/*
Taschen-Rechner

Schreiben Sie ein Programm, das zwei Zahlen einliest und anschließend mit Hilfe
einer Switch-Anweisung ein Menü anbietet, in welchem der Benutzer zwischen
den 4 Grundrechnungsarten wählen kann. Inkludieren Sie einen Menüpunkt für
einen Abbruch des Programmes.

Nach entsprechender Wahl soll der Anwender das Ergebnis (wenn mathematisch möglich)
ausgegeben bekommen.

Nach der Ausgabe der Berechnung soll das Programm automatisch von neuem starten.


// optional: Das Programm wird dauernd wiederholt ✅
// optional: DAU-Sicherheit der Eingaben ✅
// optional: Sicherstellen, dass eine Berechnung mathematisch möglich ist ✅
*/

namespace Taschen_Rechner_v1
{
    class Program
    {
        static void Main(string[] args)
        {
            double zahl_1, zahl_2, ergebnis = 0;
            string rechenart;
            bool istZahl = false, istRechenart = false, berechnungGestartet = true;

            while (berechnungGestartet)
            {
                Console.WriteLine("Willkommen in unserem Taschenrechner!");
                Console.WriteLine();

                do
                {
                    Console.Write("Geben Sie eine Zahl_1: ");

                    istZahl = double.TryParse(Console.ReadLine()?.Replace(".", ","), out zahl_1);

                    if (!istZahl)
                    {
                        Console.WriteLine("Das ist keine Zahl. Versuchen Sie nochmal\n");
                    }
                }
                while (!istZahl);

                Console.WriteLine();

                do
                {
                    Console.Write("Geben Sie eine Zahl_2: ");

                    istZahl = double.TryParse(Console.ReadLine()?.Replace(".", ","), out zahl_2);

                    if (!istZahl)
                    {
                        Console.WriteLine("Das ist keine Zahl. Versuchen Sie nochmal");
                        Console.WriteLine();
                    }


                } while (!istZahl);

                Console.WriteLine();

                do
                {
                    Console.WriteLine("Rechenarten: ");
                    Console.WriteLine("(+) plus");
                    Console.WriteLine("(-) minus");
                    Console.WriteLine("(*) mal");
                    Console.WriteLine("(/) durch");

                    Console.Write("Geben Sie ein Rechenart: ");

                    rechenart = Console.ReadLine() ?? "";

                    istRechenart = rechenart != "+" && rechenart != "-" && rechenart != "*" && rechenart != "/";

                    if (istRechenart)
                    {
                        Console.WriteLine("\nLeider ist dies keine der vorgeschlagenen Rechnenarten. " +
                       "Versuchen Sie nochmal");
                    }

                } while (istRechenart);

                Console.WriteLine();

                if (zahl_2 == 0 && rechenart == "/")
                {
                    Console.WriteLine("Leider ist eine Division durch Null nicht möglich.");
                }
                else
                {
                    switch (rechenart)
                    {
                        case "+":
                            ergebnis = zahl_1 + zahl_2;
                            break;
                        case "-":
                            ergebnis = zahl_1 - zahl_2;
                            break;
                        case "*":
                            ergebnis = zahl_1 * zahl_2;
                            break;
                        case "/":
                            ergebnis = zahl_1 / zahl_2;
                            break;
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