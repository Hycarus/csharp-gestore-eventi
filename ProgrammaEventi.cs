using System;
using System.Diagnostics.Tracing;

namespace GestoreEventi
{
	public class ProgrammaEventi
	{
		public string Title { get; set; }
		public static List<Event> Events { get; set; }

		public ProgrammaEventi(string title)
		{
			Events = new List<Event>();
			title = Title; 
		}

        public void AddNewEvent(Event evento)
        {
            Events.Add(evento);
        }

		public List<Event> ShowEventsByDate(DateTime date)
		{
			List<Event> EventsOnDate = new List<Event>();
			foreach(var evento in Events)
			{
				if(date == evento.Date)
				{
					EventsOnDate.Add(evento);
				}
			}
			return EventsOnDate;
		}

		public static string ShowEventsList()
		{
			string path = "";
			foreach(var evento in Events)
			{
				path += $"\n{evento.Date.ToString("gg/mm/yyyy")} - {evento.Title}";
			}
			return path;
		}

		public int HowManyEvents()
		{
			return Events.Count();
		}

		public void DeleteAllEvents()
		{
			Events.Clear();
		}

		public string ShowProgramTitleAndEvents()
		{
			return $"{Title}{ShowEventsList()}";
		}
    }

	
}

