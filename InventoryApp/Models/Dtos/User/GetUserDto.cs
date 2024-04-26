namespace InventoryApp.Models.Dtos.User
{
    public class GetUserDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Cedula { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
