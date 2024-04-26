namespace InventoryApp.Models
{
    public class Item : BaseEntity
    {     
        public Guid ProductId { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public string? Photo { get; set; }

    }
}
