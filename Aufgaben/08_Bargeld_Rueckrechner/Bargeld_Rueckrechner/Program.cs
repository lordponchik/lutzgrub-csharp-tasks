/*Der Computer soll einen zufälligen Geldbetrag Ausgeben
Der User soll angeben im nächsten Schritt wie viel Geld er hat.
Der Computer soll danach in Scheinen und Münzen ausgeben die Dieferenz zwischen dem betrag des Computers und des Users.

Beispiel
Computer gibt an was zu zahlen : 455,00 Euro
User macht eingabe 1000,00 Euro
Ausgabe:  1 x 500 Euroschein
          2 x 20 Euroscheine
          1 x 5 Euroschein 

Hilfsetellung: Probiert die nutzung des Modulo Operators %
*/

namespace Bargeld_Rueckrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            decimal zufälligerGeldbetrag = rnd.Next(1, 5001), geldBenutzer, rueckgeld = 0;
            decimal[] euroschein = { 500, 200, 100, 50, 20, 10, 5 }, euromuenzen = { 2, 1 }, centmuenzen = { 50, 25, 10, 5, 2, 1 };
            bool istZahl = false;

            Console.WriteLine("Willkommen.");
            Console.WriteLine($"Dein Geldbetrag ist {zufälligerGeldbetrag:F2} Euro");

            do
            {
                Console.Write("Geben einfach an, wie viel Geld Sie haben: ");

                istZahl = decimal.TryParse(Console.ReadLine()?.Replace(".", ","), out geldBenutzer);

                if (!istZahl) Console.WriteLine("Leider verstehe ich nicht. Geben Sie nur ein Zahl an.\n");

                else if (geldBenutzer < zufälligerGeldbetrag)
                {
                    Console.WriteLine("Leider ist das zu wenig.\n");
                    istZahl = !istZahl;
                }
            }
            while (!istZahl);

            rueckgeld = geldBenutzer - zufälligerGeldbetrag;

            Console.Clear();

            Console.WriteLine("Willkommen.");
            Console.WriteLine($"Betrag: {zufälligerGeldbetrag:F2} Euro");
            Console.WriteLine($"Gegeben: {geldBenutzer:F2} Euro");
            Console.WriteLine("--------------------------------------------");
            if (rueckgeld != 0) Console.WriteLine($"Ihr Rückgeld beträgt: {rueckgeld:F2} Euro");

            rueckgeld = AusgabeAnzahlTeilRueckgeld(euroschein, rueckgeld, "Euroschein");

            rueckgeld = AusgabeAnzahlTeilRueckgeld(euromuenzen, rueckgeld, "Euro-Münze");

            rueckgeld = AusgabeAnzahlTeilRueckgeld(centmuenzen, rueckgeld, "Cent-Münze");

            static decimal AusgabeAnzahlTeilRueckgeld(decimal[] schein, decimal rueckgeld, string typSchein)
            {
                if (rueckgeld < 1) rueckgeld *= 100;

                foreach (decimal elem in schein)
                {
                    decimal anzahlEuroschein = Math.Truncate(rueckgeld / elem);

                    if (anzahlEuroschein >= 1)
                    {
                        Console.WriteLine($"{anzahlEuroschein} x {elem} {typSchein}");

                        rueckgeld %= elem;
                    }
                }

                return rueckgeld;
            }
        }
    }
}