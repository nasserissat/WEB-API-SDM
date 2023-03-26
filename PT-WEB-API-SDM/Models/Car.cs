using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PT_WEB_API_SDM.Models
{
	public class Car
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		[Required]
        [MinLength(3)]
		public string Brand { get; set; } = null!;
        [Required]
        public string Model { get; set; } = null!;
        [Required]
        public int Year { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Boolean StatusIsNew { get; set; }
        
        public string? Image { get; set; }

    }
}

