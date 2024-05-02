using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestoreEventi
{
	public class Conferenza : Event
	{
		public string Speaker { get; set; }
		public double Price { get; set; }

		public Conferenza(string title, DateTime date, int maxSpace, string speaker, double price) : base(title, date, maxSpace)
		{
			Speaker = speaker;
			Price = price;
		}

		public string FormatPrice()
		{
			return Price.ToString("0.00") + " euro";
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} - {Title} - {Speaker} - {FormatPrice()}";
        }
    }
}

