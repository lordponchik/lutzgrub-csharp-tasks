/*
Zahlen in Worten

Der Anwender soll eine beliebige Zahl zwischen 1-999 eingeben.
Diese Zahl soll dann als String ausgegeben werden.

Ein Beispiel:
Eingabe: 128
Ausgabe: einhundertachtundzwanzig

Viel Efolg :)
*/

namespace Zahlen_in_Worten
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] einhiten = { "ein", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun" };
            string[] zahlenZweitenZehn = { "zehn", "elf", "zwölf", "dreizehn", "vierzehn", "fünfzehn", "sechzehn", "siebzehn", "achtzehn", "neunzehn" };
            string[] zehner = { "zwanzig", "dreißig", "vierzig", "fünfzig", "sechzig", "siebzig", "achtzig", "neunzig" };

            int zahl;
            string zahlInStr = "", zehnerStr = "";
            bool checkVariable;

            do
            {
                Console.Write("Nur Zahlen bitte.\nSchreiben Sie eine Zahl zwischen 1 und 999, damit ich sie in eine Zeichenfolge umwandeln kann: ");

                checkVariable = int.TryParse(Console.ReadLine(), out zahl);

                if (!checkVariable) Console.WriteLine("Leider versteh ich nicht. Versuchen Sie nochmal\n");
                else
                {
                    if (zahl < 1 || zahl > 999)
                    {
                        checkVariable = false;
                        Console.WriteLine("Zahl soll zwischen 1 und 999 sein\n");
                    }
                }
            } while (!checkVariable);

            if (zahl >= 100)
            {
                zahlInStr += einhiten[(int)Math.Truncate((double)zahl / 100) - 1] + "hundert";
                zahl %= 100;
            }

            if (zahl >= 20)
            {

                zehnerStr = zehner[(int)Math.Truncate((double)zahl / 10) - 2];
                Console.WriteLine((int)Math.Truncate((double)zahl / 10));
                zahl %= 10;
            }
            else if (zahl >= 10)
            {
                zahlInStr += zahlenZweitenZehn[zahl % 10];
                zahl = 0;
            }

            if (zahl > 0)
            {
                zahlInStr += zahl == 1 && zahlInStr.Length == 0 || zehnerStr.Length == 0 ? einhiten[zahl - 1] + "s" : einhiten[zahl - 1];
                if (zehnerStr.Length > 0) zahlInStr += "und" + zehnerStr;
            }


            Console.WriteLine(zahlInStr);
        }
    }
}