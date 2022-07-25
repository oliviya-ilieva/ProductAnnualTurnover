namespace ProductAnnualTurnover.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; } = default!;
        public string EAN { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = default!;
    }
}
