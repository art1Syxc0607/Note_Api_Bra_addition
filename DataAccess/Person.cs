

namespace DataAccess
{
    public class Person
    {
        public int Id { get; set; }
        public string Email_login { get; set; }
        //public string Password { get; set; }
        public string Password_hash { get; set; }

        public Note[] Person_notes = { };
    }
}
