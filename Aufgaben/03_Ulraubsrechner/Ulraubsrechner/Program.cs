namespace Ulraubsrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            int urlaubsTage = 26, betriebszugehörigkeit, behinderungProzent, alter;
            bool checkVariable, hatBehinderung;
            string name, jeinBenutzerAntwort, falscheBenutzerAntwort = "Leider verstehe ich Sie nicht. Vesuchen Sie nochmal bitte.\n";

            Console.Clear();
            // Abfrage Name.
            Console.Write("Schreiben Sie bitte Ihren Namen bitte: ");
            name = Console.ReadLine() ?? "User";
            Console.WriteLine($"Guten Tag, {name}");
            Console.WriteLine();

            // Abfrage Alter
            do
            {
                Console.Write("Schreiben Sie Ihr Alter. Nur Zahlen bitte: ");
                checkVariable = int.TryParse(Console.ReadLine(), out alter);

                if (!checkVariable) Console.WriteLine(falscheBenutzerAntwort);
                else if (alter <= 0)
                {
                    Console.WriteLine("Das ist unmöglich. Schreiben Sie bitte die Zahl größer als 0.\n");
                    checkVariable = false;
                }
                else
                {
                    // Überprüfung Urlaubstage for Alter
                    if (alter < 18) urlaubsTage = 30;
                    else if (alter > 55) urlaubsTage = 28;
                }
            } while (!checkVariable);

            Console.WriteLine();

            // Abfrage HatBehinderung
            do
            {
                Console.Write("Haben Sie eine Behindreung? Schreiben Sie einfach ja oder nein: ");
                jeinBenutzerAntwort = Console.ReadLine().ToLower();

                switch (jeinBenutzerAntwort)
                {
                    case "ja":
                        hatBehinderung = true;
                        //Abfrage wie Hoch Behinderung
                        do
                        {
                            Console.Write("\nSchreiben Sie, wie hoch Ihre Behinderung ist. Nur Zahlen bitte: ");
                            checkVariable = int.TryParse(Console.ReadLine(), out behinderungProzent);

                            if (!checkVariable) Console.WriteLine(falscheBenutzerAntwort);
                            else
                            {
                                if (behinderungProzent >= 50 && behinderungProzent <= 100) urlaubsTage += 5;
                            }
                        } while (!checkVariable);
                        break;
                    case "nein":
                        hatBehinderung = false;
                        break;
                    default:
                        Console.WriteLine(falscheBenutzerAntwort);
                        break;
                }

            } while (jeinBenutzerAntwort != "ja" && jeinBenutzerAntwort != "nein");

            Console.WriteLine();

            //Abfrage Berufserfahrung
            do
            {
                Console.Write("Schreiben Sie, wie viele Jahre Berufserfahrung haben Sie. Nur Zahlen bitte: ");
                checkVariable = int.TryParse(Console.ReadLine(), out betriebszugehörigkeit);

                if (!checkVariable) Console.WriteLine(falscheBenutzerAntwort);
                else
                {
                    if (betriebszugehörigkeit >= 10) urlaubsTage += 2;
                }
            } while (!checkVariable);

            Console.WriteLine();

            // Ergebnis
            Console.WriteLine($"Glückwunsch. Ihr Urlaub beträgt {urlaubsTage} Tage. Ich wünsche Ihnen eine gute Erholung.");
        }
    }
}