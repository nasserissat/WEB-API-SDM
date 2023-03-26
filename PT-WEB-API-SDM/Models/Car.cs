using System;
namespace PT_WEB_API_SDM.Models
{
	public class Car
	{
		public int Id { get; set; }
		public string Brand { get; set; } = null!;
		public string Model { get; set; } = null!;
        public int Year { get; set; }
		public decimal Price { get; set; }
		public Boolean StatusIsNew { get; set; }
		public string Image { get; set; } = null!;

    }
}

