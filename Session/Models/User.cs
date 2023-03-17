namespace Session.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }


    public class UserInit
    {
        public static List<User> Init()
        {
            return new List<User>()
            {
                new User(){Id = 0, Username = "Ali", Password = "123456"},
                new User(){Id = 1, Username = "Can", Password = "123456"}
            };
        }
    }
}
