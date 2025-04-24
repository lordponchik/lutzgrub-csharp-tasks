/*
Taschen-Rechner

Schreiben Sie ein Programm, das zwei Zahlen einliest und anschließend mit Hilfe
einer Switch-Anweisung ein Menü anbietet, in welchem der Benutzer zwischen
den 4 Grundrechnungsarten wählen kann. Inkludieren Sie einen Menüpunkt für
einen Abbruch des Programmes.

Nach entsprechender Wahl soll der Anwender das Ergebnis (wenn mathematisch möglich)
ausgegeben bekommen.

Nach der Ausgabe der Berechnung soll das Programm automatisch von neuem starten.
*/

namespace Taschen_Rechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Willkommen bei unserem Taschenrechner");
            Console.WriteLine();

            int zahl_1, zahl_2, ergebnis = 0;
            string rechenart;

            Console.Write("Geben Sie eine Zahl_1: ");
            zahl_1 = int.Parse(Console.ReadLine() ?? "");

            Console.WriteLine();

            Console.Write("Geben Sie eine Zahl_2: ");
            zahl_2 = int.Parse(Console.ReadLine() ?? "");

            Console.WriteLine();

            Console.WriteLine("Rechenarten: ");
            Console.WriteLine("(+) plus");
            Console.WriteLine("(-) minus");
            Console.WriteLine("(*) mal");
            Console.WriteLine("(/) durch");

            Console.Write("Geben Sie ein Rechenart: ");

            rechenart = Console.ReadLine() ?? "";

            Console.WriteLine();

            switch (rechenart)
            {
                case "+":
                    ergebnis = zahl_1 + zahl_2;
                    Console.WriteLine($"Ergebnis ist {ergebnis}");
                    break;
                case "-":
                    ergebnis = zahl_1 - zahl_2;
                    Console.WriteLine($"Ergebnis ist {ergebnis}");
                    break;
                case "*":
                    ergebnis = zahl_1 * zahl_2;
                    Console.WriteLine($"Ergebnis ist {ergebnis}");
                    break;
                case "/":
                    if (zahl_2 != 0)
                    {
                        ergebnis = zahl_1 / zahl_2;
                        Console.WriteLine($"Ergebnis ist {ergebnis}");
                    }
                    else Console.WriteLine($"Sie können nicht durch Null teilen");
                    break;
            }
        }
    }
}