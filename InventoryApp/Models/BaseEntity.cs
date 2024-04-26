namespace InventoryApp.Models
{
    public interface IBase
    {
        public Guid Id { get; set; }
    }

    public class BaseEntity : IBase
    {
        public Guid Id { get; set; }
    }
}
