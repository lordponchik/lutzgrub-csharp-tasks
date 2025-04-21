/*
Promillerechner 
Der User soll angeben können, wieviel Bier in Litern getrunken wurde. 
Daraus wird die Menge des Reinalkohols in Gramm berechnet.  
Getrunkene Menge in Milliliter * Alkoholgehalt * Dichte des Ethanols. 

Bei Bier also: Getrunkene Menge in Milliliter * 0.05 * 0.8 

Der User soll auch sein Gewicht in Kilogramm angeben.  

Dann wird der Blutalkoholgehalt in Promille berechnet und auf 2 Nachkommastellen gerundet. 

(Das bitte selbst Recherchieren) 

c = A / (0.65*G) 

c ist der Promillewert, A der aufgenommene Alkohol in Gramm und G das Körpergewicht in kg. 

Es soll dann eine Ausgabe, abhängig vom Promillewert folgen: 

bis 0.3: "Noch akzeptabel. Dennoch vorsichtig sein!" 

bis 0.5: "Achtung! Hände weg vom Steuer." 

bis 0.8: "Das ist jetzt schon ganz schön ordentlich." 

ab 0.8: "Kein Kommentar..." 

Wähle die passenden Datentypen für die jeweils notwendigen Variablen. 

Etwaige Eingabefehler sollen über einen else-Block abgefangen werden.  
*/

namespace Promillerechner
{
    class Program
    {
        static void Main(string[] args)
        {
            double anzahlLiterBier = 0, koerpergewichtBenutzer = 0, promillewert = 0;
            bool istEntsprechendeWerte = false;

            Console.WriteLine("Willkommen beim Promillerechner.\n");

            do
            {
                Console.Write("Schreiben Sie, wieviel Bier in Litern getrunken wurde: ");
                istEntsprechendeWerte = double.TryParse(Console.ReadLine()?.Replace(".", ","), out anzahlLiterBier);

                if (!istEntsprechendeWerte) Console.WriteLine("Leider verstehe ich nicht. Versuchen Sie nochmal\n");

            } while (!istEntsprechendeWerte);

            anzahlLiterBier = Math.Round(anzahlLiterBier, 2);

            do
            {
                Console.Write("Geben Sie Ihr Gewicht an: ");
                istEntsprechendeWerte = double.TryParse(Console.ReadLine()?.Replace(".", ","), out koerpergewichtBenutzer);

                if (!istEntsprechendeWerte) Console.WriteLine("Leider verstehe ich nicht. Versuchen Sie nochmal\n");

            } while (!istEntsprechendeWerte);

            koerpergewichtBenutzer = Math.Round(koerpergewichtBenutzer, 2);

            promillewert = Math.Round(anzahlLiterBier * 1000 * 0.05 * 0.8 / (0.65 * koerpergewichtBenutzer), 2);

            Console.WriteLine(promillewert);

            if (promillewert <= 0.3) Console.WriteLine("Noch akzeptabel. Dennoch vorsichtig sein!");
            else if (promillewert <= 0.5) Console.WriteLine("Achtung! Hände weg vom Steuer.");
            else if (promillewert <= 0.8) Console.WriteLine("Das ist jetzt schon ganz schön ordentlich.");
            else Console.WriteLine("Kein Kommentar...");
        }
    }
}
