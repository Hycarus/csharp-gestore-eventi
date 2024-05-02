namespace GestoreEventi;

class Program
{
    static void Main(string[] args)
    {
        

        Console.Write("Inserisci il nome dell'evento ");
        string? eventName = Console.ReadLine();
        Console.Write("\nInserisci la data dell'evento (gg/mm/yyyy) ");
        var eventDate = Convert.ToDateTime(Console.ReadLine());
        Console.Write("\nInserisci il numero di posti totali ");
        int eventMaxPlaces = Convert.ToInt32(Console.ReadLine());

        Event evento = new Event(eventName, eventDate, eventMaxPlaces);

        Console.WriteLine("Quanti posti desideri prenotare?");
        int reservedPlace = Convert.ToInt32(Console.ReadLine());
        evento.PrenotaPosti(reservedPlace);

        string choice;
        do
        {
            Console.WriteLine($"Numero di posti prenotati {evento.NumberReservedPlace}");
            Console.WriteLine($"Numero di posti disponibili {evento.MaxSpace - evento.NumberReservedPlace}");

            Console.Write("\nVuoi disdire dei posti (si/no)? ");
            choice = Console.ReadLine();

            if(choice == "si")
            {
                Console.Write("\nIndica il numero di posti da disdire: ");
                int cancelPlace = Convert.ToInt32(Console.ReadLine());
                evento.DisdiciPosti(cancelPlace);
            }
            else
            {
                Console.WriteLine("Ok va bene!");
            }
        } while (choice != "no");
    }
}

