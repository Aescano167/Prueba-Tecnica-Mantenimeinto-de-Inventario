namespace InventoryApp.Models.Dtos.Item
{
    public class CreateItemDto
    {
        public Guid ProductId { get; set; }
        public string? Color { get; set; }
        public double? Price { get; set; }
        public IFormFile? Photo { get; set; }

    }
}
