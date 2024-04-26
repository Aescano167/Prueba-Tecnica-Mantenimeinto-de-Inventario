namespace InventoryApp.Models.Dtos.User
{
    public class CreateUserDto
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Cedula { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirPassword { get; set; }
        public RoleEnum Role { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
