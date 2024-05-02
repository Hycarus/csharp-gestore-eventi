namespace GestoreEventi;

class Program
{
    static void Main(string[] args)
    {
        

        //Console.Write("Inserisci il nome dell'evento: ");
        //string? eventName = Console.ReadLine();
        //Console.Write("\nInserisci la data dell'evento (gg/mm/yyyy): ");
        //DateTime eventDate = Convert.ToDateTime(Console.ReadLine());
        //Console.Write("\nInserisci il numero di posti totali: ");
        //int eventMaxPlaces = Convert.ToInt32(Console.ReadLine());

        //Event evento = new Event(eventName, eventDate, eventMaxPlaces);

        //Console.WriteLine("Quanti posti desideri prenotare? ");
        //int reservedPlace = Convert.ToInt32(Console.ReadLine());
        //evento.PrenotaPosti(reservedPlace);

        //string choice;
        //do
        //{
        //    Console.WriteLine($"Numero di posti prenotati {evento.NumberReservedPlace}");
        //    Console.WriteLine($"Numero di posti disponibili {evento.MaxSpace - evento.NumberReservedPlace}");

        //    Console.Write("\nVuoi disdire dei posti (si/no)? ");
        //    choice = Console.ReadLine();

        //    if(choice == "si")
        //    {
        //        Console.Write("\nIndica il numero di posti da disdire: ");
        //        int cancelPlace = Convert.ToInt32(Console.ReadLine());
        //        evento.DisdiciPosti(cancelPlace);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Ok va bene!");
        //    }
        //} while (choice != "no");

        Console.Write("Inserisci il nome del tuo programma eventi: ");
        string? programEventTitle = Console.ReadLine();

        ProgrammaEventi programmaEventi = new ProgrammaEventi(programEventTitle);

        Console.Write("\nIndica il numero di eventi da inserire: ");
        int numberOfEvents;
        while (!int.TryParse(Console.ReadLine(), out numberOfEvents) || numberOfEvents <= 0)
        {
            Console.WriteLine("Per favore, inserisci un numero intero positivo per il numero di eventi: ");
        }

        for (int i = 0; i < numberOfEvents; i++)
        {
            try
            {
                Console.Write($"Inserisci il nome dell'evento {i + 1}: ");
                string? name = Console.ReadLine();
                Console.Write("\nInserisci la data dell'evento (gg/mm/yyyy): ");
                DateTime date;
                while(!DateTime.TryParse(Console.ReadLine(), out date))
                {
                    Console.WriteLine("Data non valida. Inserisci di nuovo (formato: gg/mm/yyyy): ");
                }
                Console.Write("\nInserisci il numero di posti totali: ");
                int places;
                while (!int.TryParse(Console.ReadLine(), out places) || places <= 0)
                {
                    Console.WriteLine("Capienza massima non valida. Inserisci di nuovo: ");
                }

                Event nuovoEvento = new Event(name, date, places);

                programmaEventi.AddNewEvent(nuovoEvento);
                Console.WriteLine("Evento aggiunto con successo");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Errore: {e.Message}");
            }
            
        }

        Console.Write($"Il numero degli eventi nel programma è: \n{programmaEventi.HowManyEvents()}");

        Console.WriteLine($"Ecco il tuo programma eventi: {programmaEventi.ShowProgramTitleAndEvents()}");

        Console.Write("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
        DateTime dateForSearch;
        while (!DateTime.TryParse(Console.ReadLine(), out dateForSearch))
        {
            Console.Write("\nData non valida. Inserisci di nuovo (formato: gg/mm/yyyy): ");
        }
        List<Event> eventsInDate = programmaEventi.ShowEventsByDate(dateForSearch);
        ShowEventListByDate(eventsInDate);

        programmaEventi.DeleteAllEvents();
    }

    public static void ShowEventListByDate(List<Event> events)
    {
        if(events.Count() == 0)
        {
            Console.WriteLine("Nessun evento presente");
        }
        else
        {
            foreach(var evento in events)
            {
                Console.WriteLine(evento);
            }
        }
    }
}

