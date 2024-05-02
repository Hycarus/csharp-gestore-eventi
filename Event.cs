using System;
namespace GestoreEventi
{
	public class Event
	{
		private string title;
		private DateTime date;
		private int maxSpace;
		private int numberReservedPlace;
        


        public Event(string title, DateTime date, int maxSpace)
		{
			if(date < DateTime.Now)
			{
				throw new ArgumentException("La data dell'evento non può essere nel passato");
			}

			if (string.IsNullOrWhiteSpace(title))
			{
				throw new ArgumentException("Il titolo non può essere lasciato vuoto");
			}

			if(maxSpace <= 0)
			{
				throw new ArgumentException("La capienza massima deve essere un numero positivo");
			}

			this.title = title;
			this.date = date;
			this.maxSpace = maxSpace;
			numberReservedPlace = 0;
		}

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Il titolo non può essere lasciato vuoto");
                }
                title = value;
            }
        }

		public DateTime Date
		{
			get
			{
				return date;
			}
			set
			{
				if(value < DateTime.Now)
				{
					throw new ArgumentException("La data dell'evento non può essere nel passato");
				}
				date = value;
			}
		}

		public int MaxSpace
		{
			get
			{
				return maxSpace;
			}
		}

		public int NumberReservedPlace
		{
			get
			{
				return numberReservedPlace;
			}
			set
			{
				numberReservedPlace = value;
			}
		}

		public void PrenotaPosti(int places)
		{
			if(places <= 0)
			{
				throw new ArgumentException("Devi prenotare almeno un posto");
			}

			if(numberReservedPlace + places > maxSpace)
			{
				throw new ArgumentException("Non ci sono abbastanza posti disponibili");
			}

			if(date < DateTime.Now)
			{
				throw new ArgumentException("Non puoi prenotare posti per un evento già passato");
			}

			numberReservedPlace += places;
		}

		public void DisdiciPosti(int placesToDelete)
		{
			if(date < DateTime.Now)
			{
				throw new ArgumentException("Non puoi disdire per un evento già passato");
			}

			if(placesToDelete > numberReservedPlace)
			{
				throw new ArgumentException("Non ci sono abbastanza posti da disdire");
			}

			if(placesToDelete <= 0)
			{
				throw new ArgumentException("Il numero di posti da disdire deve essere maggiore di 0");
			}

			numberReservedPlace -= placesToDelete;
		}

        public override string ToString()
        {
			return $"{date.ToString("dd/MM/yyyy")} - {title}";
        }
    }
}

