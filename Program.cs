using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestoreEventi;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inserisci il nome del tuo programma eventi: ");
        string? programEventTitle = Console.ReadLine();

        ProgrammaEventi programmaEventi = new ProgrammaEventi(programEventTitle);

        Console.WriteLine("Indica il numero di eventi da inserire: ");
        int numberOfEvents;
        while (!int.TryParse(Console.ReadLine(), out numberOfEvents) || numberOfEvents <= 0)
        {
            Console.WriteLine("Per favore, inserisci un numero intero positivo per il numero di eventi: ");
        }

        for (int i = 0; i < numberOfEvents; i++)
        {
            try
            {
                Console.WriteLine($"Inserisci il nome dell'evento {i + 1}: ");
                string? name = Console.ReadLine();
                Console.WriteLine("Inserisci la data dell'evento (gg/mm/yyyy): ");
                //DateTime date = DateTime.Parse(Console.ReadLine());
                DateTime date;
                while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", new CultureInfo("it-IT"), DateTimeStyles.None, out date))
                {
                    Console.WriteLine(date);
                    Console.WriteLine("Data non valida. Inserisci di nuovo (formato: gg/mm/yyyy): ");
                }
                Console.WriteLine("Inserisci il numero di posti totali: ");
                int places;
                while (!int.TryParse(Console.ReadLine(), out places) || places <= 0)
                {
                    Console.WriteLine("Capienza massima non valida. Inserisci di nuovo: ");
                }

                Event newEvent = new Event(name, date, places);

                programmaEventi.AddNewEvent(newEvent);
                Console.WriteLine("Evento aggiunto con successo");

                Console.WriteLine("Vuoi prenotare dei posti? (si/no): ");
                string? choice = Console.ReadLine();
                while (choice.ToLower() == "si")
                {
                    Console.WriteLine("Quanti posti vuoi prenotare?");
                    int reservedPlaces;
                    while (!int.TryParse(Console.ReadLine(), out reservedPlaces) || reservedPlaces <= 0)
                    {
                        Console.WriteLine("Inserisci un numero valido:");
                    }

                    newEvent.PrenotaPosti(reservedPlaces);

                    Console.WriteLine($"Posti prenotati: {newEvent.NumberReservedPlace}");
                    Console.WriteLine($"Posti disponibili: {newEvent.MaxSpace - newEvent.NumberReservedPlace}");

                    Console.WriteLine("Vuoi continuare a prenotare posti? (si/no):");
                    choice = Console.ReadLine();
                }

                Console.WriteLine("Vuoi disdire dei posti? (si/no):");
                string? choice2 = Console.ReadLine();
                while (choice2.ToLower() == "si")
                {
                    Console.WriteLine("Quanti posti vuoi disdire?");
                    int postiDaDisdire;
                    while (!int.TryParse(Console.ReadLine(), out postiDaDisdire) || postiDaDisdire <= 0)
                    {
                        Console.WriteLine("Inserisci un numero valido:");
                    }

                    newEvent.DisdiciPosti(postiDaDisdire);

                    Console.WriteLine($"Posti prenotati: {newEvent.NumberReservedPlace}");
                    Console.WriteLine($"Posti disponibili: {newEvent.MaxSpace - newEvent.NumberReservedPlace}");

                    Console.WriteLine("Vuoi continuare a disdire posti? (si/no):");
                    choice2 = Console.ReadLine();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Errore: {e.Message}");
            }
            
        }

        Console.Write($"\nIl numero degli eventi nel programma è: \n{programmaEventi.HowManyEvents()}");

        Console.WriteLine($"\nEcco il tuo programma eventi: {programmaEventi.ShowProgramTitleAndEvents()}");
        
        Console.Write("Inserisci una data per sapere che eventi ci saranno (gg/mm/yyyy): ");
        DateTime dateForSearch;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", new CultureInfo("it-IT"), DateTimeStyles.None, out dateForSearch))
        {
            Console.Write("\nData non valida. Inserisci di nuovo (formato: gg/mm/yyyy): ");
        }
        List<Event> eventsInDate = programmaEventi.ShowEventsByDate(dateForSearch);
        Console.WriteLine("\nEventi in data: ");
        ProgrammaEventi.ShowEventListByDate(eventsInDate);

        programmaEventi.DeleteAllEvents();
        Console.WriteLine("\nTutti gli eventi sono stati eliminati");

        Console.WriteLine("Premi un tasto per chiudere il programma");
        Console.ReadLine();
    }
}

