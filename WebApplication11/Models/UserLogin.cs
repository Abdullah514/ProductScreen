namespace WebApplication11.Models
{
    public class UserLogin
    {
        [key]
        public int Userid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
