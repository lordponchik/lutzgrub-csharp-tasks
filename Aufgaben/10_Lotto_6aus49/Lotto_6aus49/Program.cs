/*
Schreiben Sie ein Lottoprogramm (6 aus 49)

Erstellen sie eine Klasse "Lotto":
Dieses soll ein Array enthalten, das zufallsbasiert 6 Gewinnzahlen beinhaltet.
(Nutzen Sie dazu ein random-Objekt).

Nun sollte der Anwender 6 Zahlen aus 49 auswählen, die mit den Gewinnzahlen
verglichen werden müssen und es ausgegeben wird, wieviele "Richtige" er hat.

Zu beachtende Schritte:
1. User-Eingaben der 6 getippten Zahlen => Speicherung in einem Array
2. 6 zufällige Zahlen zwischen 1 und 49 "ziehen" => Speicherung in einem neuen Array
3. Vergleich der getippten und gezogenen Zahlen => Speicherung der Anzahl der "Richtigen"
4. Ausgabe der gezogenen Zahlen, der getippten Zahlen und der Anzahl der "Richtigen"
*/

namespace Lotto_6aus49
{
    class Program
    {
        static void Main(string[] args)
        {
            Lotto_6aus49();
        }

        static void Lotto_6aus49()
        {
            //Variablen 

            int[] getipptenZahlen = new int[6], gezogeneZahlen = new int[6]; //gezogeneZahlen
            bool istZahl = false, spielGestartet = true;
            int anzahlRichtige = 0, zahl = 0; ;

            Random rand = new Random();

            Begruessung();

            while (spielGestartet)
            {
                //Begrüssung: Lotto 6 aus 49 (Zahlen von 1 bis 49)

                // Eingabe der 6 Zahlen des Users && Speicherung in einem Array

                for (int i = 0; i < getipptenZahlen.Length; i += 1)
                {
                    do
                    {
                        Console.Write($"Es sind noch {getipptenZahlen.Length - i} Zahlen übrig. Geben Sie eine Zahl: ");

                        istZahl = int.TryParse(Console.ReadLine(), out zahl);

                        if (!istZahl)
                        {
                            Console.WriteLine("Leider ist das keine Zahl. Versuchen Sie nochmal");
                            Console.WriteLine();
                        }
                        else
                        {
                            if (zahl < 1 || zahl > 49)
                            {
                                Console.WriteLine("Die Zahl muss von 1 bis 49 sein. Versuchen Sie nochmal");
                                Console.WriteLine();
                                istZahl = !istZahl;
                            }
                            else if (IstZahlVorhanden(getipptenZahlen, zahl))
                            //else if (getipptenZahlen.Contains(zahl))
                            {
                                Console.WriteLine("Diese Zahl wurde bereits gewählt. Versuchen Sie nochmal");
                                Console.WriteLine();
                                istZahl = !istZahl;
                            }
                            else
                            {
                                getipptenZahlen[i] = zahl;
                                Console.Clear();

                                Begruessung();

                                Console.WriteLine($"Getippte Zahlen: {String.Join(" ", getipptenZahlen)}");
                            }

                        }
                    }
                    while (!istZahl);

                }

                // 6 Zufallszahlen erzeugen && Speicherung in einem anderen Array

                for (int i = 0; i < gezogeneZahlen.Length; i += 1)
                {

                    do
                    {
                        zahl = rand.Next(1, 50);
                    }
                    while (gezogeneZahlen.Contains(zahl));

                    gezogeneZahlen[i] = zahl;
                }

                // Vergleich der Zahlen und Ermittlung der Anzahl der "Richtigen"

                /*
                for (int i = 0; i < getipptenZahlen.Length; i += 1)
                {
                    if (getipptenZahlen.Contains(gezogeneZahlen[i])) anzahlRichtige += 1;  
                }*/

                foreach (int elem in getipptenZahlen)
                {
                    if (gezogeneZahlen.Contains(elem)) anzahlRichtige += 1;
                }

                //Ausgabe: Gezogene Zahlen, getippten Zahlen, Anzahl "Richtige"

                Console.WriteLine($"Gezogene Zahlen: {String.Join(" ", gezogeneZahlen)}");
                Console.WriteLine($"Anzahl \"Richtige\": {anzahlRichtige}");

                Console.WriteLine();

                Console.WriteLine("Drücken Sie <Escape>, wenn Sie das Programm beenden möchten, \n " +
                    "oder eine andere Taste, um es erneut zu versuchen: ");

                // optional: das Programm wird dauernd wiederholt
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    spielGestartet = !spielGestartet;
                }

                Console.Clear();
            }

            bool IstZahlVorhanden(int[] arr, int zahl)
            {
                bool zahlVorhanden = false;

                for (int i = 0; i < arr.Length; i += 1)
                {
                    if (arr[i] == 0) break;

                    if (arr[i] == zahl)
                    {
                        zahlVorhanden = true;
                        break;
                    }
                }

                return zahlVorhanden;
            }


            void Begruessung()
            {
                Console.WriteLine("Willkommen bei unserem Spiel 6 aus 49");
                Console.WriteLine("Die Zahl muss von 1 bis 49 sein.");
                Console.WriteLine();

            }

            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}