/*
Wassermelone
Es ist Sommer und sehr warm. Sie befinden sich im Großraum München und sollen ein Programm
für einen Wassermelonenverkäufer schreiben. Erwartet wird bei allen Eingaben, dass diese
DAU-sicher sind.

1.
Es sollen die Rechnungen automatisiert werden.
Sie müssen also den Preis pro Melone und die Anzahl der Bestellmenge eintragen können.
Am Ende soll der Betrag, den der Kunde zahlen muss, ausgegeben werden.
Ab einen Bestellwert von mindestens 5 Melonen soll es 5% Rabatt geben.
Ab 10 Melonen 10%.
Hinweis: Runden Sie den Betrag auf 2 Nachkommastellen, um korrekt einen Preis zu simulieren. Schauen Sie Sich Math.Round() dazu an.

2.
Simulieren Sie eine Quittung: Also Preis, Bestellmenge, Datum, Mehrwertsteuer us.
Erzeugen Sie ein ansprechendes Ausgabeformat in der Konsole.

Viel Erfolg!
*/

namespace Wassermelone
{
    class Program
    {
        static void Main(string[] args)
        {
            double preisProWassermelone, betrag, zurZahlung, mwst, netto, rabatt = 0;
            int mengeWassermelone;
            bool checkVariable;
            string falscheBenutzerAntwort = "Leider verstehe ich Sie nicht. Versuchen Sie nochmal.\n";


            Console.Clear();
            //Abfrage Preis
            do
            {
                Console.Write("Format \"Euro,Cents\". z.B. 2,50\nGeben Sie den Preis pro Wassermelone: ");

                checkVariable = double.TryParse(Console.ReadLine().Replace(".", ","), out preisProWassermelone);

                if (!checkVariable) Console.WriteLine(falscheBenutzerAntwort);

            } while (!checkVariable);

            Console.WriteLine();

            //Abfrage Menge
            do
            {
                Console.Write("Nur Zahlen Bitte. Geben Sie die Anzahl der Wassermelone: ");

                checkVariable = int.TryParse(Console.ReadLine(), out mengeWassermelone);

                if (!checkVariable) Console.WriteLine(falscheBenutzerAntwort);

            } while (!checkVariable);

            Console.WriteLine();

            // Betrag

            betrag = preisProWassermelone * mengeWassermelone;


            //Rabatt

            if (mengeWassermelone >= 10) rabatt = Math.Round(betrag * 0.1, 2);
            else if (mengeWassermelone >= 5) rabatt = Math.Round(betrag * 0.05, 2);

            //zur Zahlung, MWST, Netto
            zurZahlung = betrag - rabatt;
            netto = Math.Round(zurZahlung / 1.07);
            mwst = zurZahlung - netto;


            // Quittung
            //40
            Console.WriteLine();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"{"       Wassermeloneverkäufer         "}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"{"EUR",40}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Wassermelonen {preisProWassermelone,6:F2} x {mengeWassermelone,4} {betrag,12:F2} A");
            if (rabatt != 0)
            {
                int rabattProzent = mengeWassermelone >= 10 ? 10 : 5;
                Console.WriteLine($"     RABATT {rabattProzent,2}% {-rabatt,24:F2}");
            }
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"zu zahlen {zurZahlung,30:F2}");
            Console.WriteLine();
            Console.WriteLine("MWST%   MWST    +    Netto   =    Brutto");
            Console.WriteLine($"A  7% {mwst,6:F2}        {netto,6:F2} {zurZahlung,13:F2}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"          {DateTime.Now}");
        }
    }
}