using System.ComponentModel.DataAnnotations;

namespace ProductAnnualTurnover.Entities
{
    public class ProductTurnover
    {
        public ProductTurnover()
        {
            this.DateCreated = DateTime.Now;

        }
       

        [Required]
        public string ProductName { get; set; }

        [StringLength(maximumLength: 13, MinimumLength = 8)]
        public string EAN { get; set; }

        [Required]
        public decimal GrossTurnover { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
