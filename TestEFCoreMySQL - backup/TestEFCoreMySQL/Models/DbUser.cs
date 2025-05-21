namespace TestEFCoreMySQL.Models
{
    public class DbUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
