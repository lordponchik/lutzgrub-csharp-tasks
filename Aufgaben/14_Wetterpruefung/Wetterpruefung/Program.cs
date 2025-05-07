/*Wetterprüfung: 

Der User soll dir mitteilen, ob das Wetter gerade "sonning" oder "regnerisch" ist. 
Auch die Temperatur soll der User angeben können. 

Liegt die Temperatur bei oder über 20°C und es ist sonning, empfehle dem User ein T-Shirt zu tragen. 

Liegt die Temperatur unter 20°C und es ist sonnig, empfehle eine Jacke anzuziehen. 

Bei regnerischen Wetter werden ebenfalls die zur Temperatur passenden Kleidungsempfehlungen ausgesprochen und der 
User soll darauf hingewiesen werden, dass er einen Regenschirm mitnehmen soll. 

Etwaige falsche Eingaben sollen über einen else-Block abgefangen werden. */

namespace Wetterpruefung
{
    class Program
    {
        static void Main(string[] args)
        {
            string wetter = "";
            int temperatur = 0;

            bool istEntsprechendeWerte = false;

            Console.WriteLine("Willkommen beim WetterPrüfung-Programm");

            do
            {
                Console.Write("Schreiben Sie, wie das Wetter jetzt ist, \"sonnig\" oder \"regnerisch\": \n");

                wetter = (Console.ReadLine() ?? "").ToLower();

                istEntsprechendeWerte = wetter == "sonnig" || wetter == "regnerisch";

                if (!istEntsprechendeWerte) Console.WriteLine("Leider verstehe ich nicht. Versuchen Sie nochmal.\n");

            } while (!istEntsprechendeWerte);

            do
            {

                Console.Write("Schreiben Sie, wie die Temperatur jetzt ist: \n");

                istEntsprechendeWerte = int.TryParse(Console.ReadLine(), out temperatur);

                if (!istEntsprechendeWerte) Console.WriteLine("Leider verstehe ich nicht. Versuchen Sie nochmal.\n");

            } while (!istEntsprechendeWerte);

            Console.Clear();

            Console.WriteLine($"Draußen ist es {wetter} und die Temperatur beträgt {temperatur} °C.");

            switch (wetter)
            {
                case "sonnig":
                    if (temperatur >= 20) Console.WriteLine("Wir empfehlen Ihnen ein T-Shirt zu tragen.");
                    else Console.WriteLine("Wir empfehlen Ihnen eine Jacke zu tragen.");
                    break;
                case "regnerisch":
                    if (temperatur >= 20) Console.WriteLine("Wir empfehlen Ihnen eine leichte Regenjacke oder einen wasserfesten Hoodie zu tragen.");
                    else Console.WriteLine("Wir empfehlen Ihnen eine warme Regenjacke und eventuell wasserfeste Schuhe zu tragen.");
                    Console.WriteLine("Dabei sollten Sie einen Regenschirm mitnehmen.");
                    break;
            }
        }
    }
}