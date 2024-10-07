namespace Fruitway_Store.Models.ViewModels
{
    public class UserVM
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string RoleName { get; set; }

        public int count { get; set; }

    }
}
