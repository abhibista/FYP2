namespace Book.Models
{
    public static class HasHeleper
    {
        public static string CreateHash(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }
    }
}