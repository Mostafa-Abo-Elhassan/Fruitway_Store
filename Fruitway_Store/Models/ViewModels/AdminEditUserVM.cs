namespace Fruitway_Store.Models.ViewModels
{
    public class AdminEditUserVM
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        //[unique]

        public string Email { get; set; }


        public string Password { get; set; }

        public string? NEWUserName { get; set; }
        //[unique]

        public string? NEWEmail { get; set; }


        public string? NEWPassword { get; set; }
    }
}
