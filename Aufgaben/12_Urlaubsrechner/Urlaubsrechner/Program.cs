namespace Urlaubsrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            string vorname, nachname, antwortBenutzer, nachrichtFalscheAntwort = "Leider verstehe ich nicht. Versuchen Sie nochmal bitte\n";
            int alter, prozentBehinderung, betriebszugehörigkeit, urlaubsTage = 26;
            bool checkIntVariable, hatBehinderung = false;

            // Abfrage von Vor- und Nachnamen
            Console.Write("Schreiben Sie Ihren Vorname: ");
            vorname = (Console.ReadLine() ?? "").Trim();

            Console.Write("Schreiben Sie Ihren Nachname: ");
            nachname = (Console.ReadLine() ?? "").Trim();

            Console.WriteLine($"Guten Tag, {vorname} {nachname}\n");

            // Abfrage von Alter
            do
            {
                Console.Write("Geben Sie Ihr Alter. Nur Zahlen bitte: ");

                checkIntVariable = int.TryParse(Console.ReadLine(), out alter);

                if (!checkIntVariable) Console.WriteLine(nachrichtFalscheAntwort);
                else
                {
                    if (alter < 18) urlaubsTage = 30;
                    else if (alter > 55) urlaubsTage = 28;
                }
            }
            while (!checkIntVariable);

            Console.WriteLine();

            // Zusätzliche Fragen
            Console.WriteLine($"In diesem Moment haben Sie {urlaubsTage} Urlaubstage.\nAber stelle ich Ihnen noch ein paar Fragen " +
                $"extra und vielleicht haben Sie noch zusätzliche Tagen dazu.");

            Console.WriteLine();

            // Frage 1. hatBehinderung
            do
            {
                Console.Write("Haben Sie eine Behinderung? Schreiben Sie einfach einen Buchstabe ja oder nein: ");
                antwortBenutzer = (Console.ReadLine() ?? "").Trim().ToLower();

                if (antwortBenutzer == "ja")
                {
                    hatBehinderung = true;
                    do
                    {
                        Console.Write("Schreiben Sie, wie hoch Ihre Behinderung ist. Nur Zahlen bitte: ");

                        checkIntVariable = int.TryParse(Console.ReadLine(), out prozentBehinderung);

                        if (!checkIntVariable) Console.WriteLine(nachrichtFalscheAntwort);
                        else
                        {
                            if (prozentBehinderung >= 50 && prozentBehinderung <= 100) urlaubsTage += 5;
                        }

                    }
                    while (!checkIntVariable);
                }
                else if (antwortBenutzer == "nein") hatBehinderung = false;
                else Console.WriteLine(nachrichtFalscheAntwort);
            }
            while (antwortBenutzer != "ja" && antwortBenutzer != "nein");

            Console.WriteLine();

            // Frage 2 Berufserfahrung
            do
            {
                Console.Write("Schreiben Sie, wie viele Jahre Berufserfahrung haben Sie. Nur Zahlen bitte: ");
                checkIntVariable = int.TryParse(Console.ReadLine(), out betriebszugehörigkeit);
                if (!checkIntVariable)
                {
                    Console.WriteLine(nachrichtFalscheAntwort);

                }
                else
                {
                    if (betriebszugehörigkeit >= 10) urlaubsTage += 2;
                }

            } while (!checkIntVariable);

            Console.WriteLine();
            Console.WriteLine($"Glückwunsch. Ihr Urlaub beträgt {urlaubsTage} Tage. Ich wünsche Ihnen eine gute Erholung.");
        }
    }
}