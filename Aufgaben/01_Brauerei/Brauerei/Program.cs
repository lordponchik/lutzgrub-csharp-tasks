/*
Eine Brauerei gewährt Kunden
bei Abnahme von mindestens 10 Kästen 5% Rabatt
bei Abnahme von mindestens 50 Kästen 7% Rabatt
bei Abnahme von mindestens 100 Kästen 10% Rabatt

Erstellen Sie ein Programm, welches die Eingabe
der Menge (in Anzahl Kästen) erlaubt und dann den Prozentsatz
richtig ermittelt und anschließend ausgibt.
*/

namespace Brauerei
{
    class Program
    {
        static void Main(string[] args)
        {
            int anzahlKästen, rabatt = 0;
            bool checkVariable;
            string nachricht = "";

            Console.WriteLine("Guten Tag");

            do
            {
                Console.Write("Schreiben Sie, wie viele Kästen Sie kaufen möchten: ");

                checkVariable = int.TryParse(Console.ReadLine(), out anzahlKästen);

                if (!checkVariable) Console.WriteLine("Leider verstehe ich Sie nicht. Schreiben Sie nur Zahlen bitte.\n");
                else
                {
                    if (anzahlKästen <= 0)
                    {
                        Console.WriteLine("Schreiben Sie bitte die Zahl größer als 0.\n");
                        checkVariable = false;
                    }
                }

            } while (!checkVariable);

            if (anzahlKästen >= 100) rabatt = 10;
            else if (anzahlKästen >= 50) rabatt = 7;
            else if (anzahlKästen >= 10) rabatt = 5;

            nachricht = rabatt == 0 ? $"Beim Kauf von {anzahlKästen} Kartons gibt es leider keinen Rabatt." :
             $"Beim Kauf von {anzahlKästen} Kästen erhalten Sie {rabatt}% Rabatt";
            Console.WriteLine(nachricht);
        }
    }
}