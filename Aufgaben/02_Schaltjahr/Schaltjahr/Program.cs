/*
Weil die astronomische Dauer einse Jahres (wenn die Erde die Sonne einmal umrundet
hat) etwas länger ist als 365 Tage, wurden Schaltjahre zum Ausgleich eingeführt.

Ein Schaltjahr ist ein Jahr, welches eine Jahreszahl hat, die durch 4 teilbar ist.
Jahreszahlen, die durch 100 teilbar sind, sind allerdings keine Schaltjahre. Es sei denn,
die Jahreszahl ist durch 400 teilbar.

Erstellen Sie ein Programm, welches prüft, ob eine eingegebene 
Jahresziffer ein Schaltjahr ist oder nicht und anschließend eine entsprechende Antwort ausgibt.
*/

namespace Schaltjahr
{
    class Program
    {
        static void Main(string[] args)
        {
            int jahr;
            bool checkVariable;

            Console.WriteLine("Guten Tag");

            do
            {
                Console.Write("Schreiben Sie ein Jahr. Nur Zahlen bitte: ");
                checkVariable = int.TryParse(Console.ReadLine(), out jahr);

                if (!checkVariable) Console.WriteLine("Leider verstehe ich nicht. Versuchen Sie nochmal.\n");

            } while (!checkVariable);

            Console.WriteLine();
            Console.WriteLine("Variante 1:");

            // Variante 1
            if (jahr % 400 == 0) Console.WriteLine("Schaltjahr");
            else if (jahr % 100 == 0) Console.WriteLine("Kein Schaltjahr");
            else if (jahr % 4 == 0) Console.WriteLine("Schaltjahr");

            // Variante 2

            Console.WriteLine();
            Console.WriteLine("Variante 2:");

            Console.WriteLine(jahr % 4 == 0 && jahr % 100 != 0 || jahr % 400 == 0 ? "Schaltjahr" : "Kein Schaltjahr");
        }
    }
}