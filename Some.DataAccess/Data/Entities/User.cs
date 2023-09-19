namespace Some.DataAccess.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Patronimyc { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
