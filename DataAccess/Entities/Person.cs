namespace DataAccess.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Email_login { get; set; }
        //public string Password { get; set; }
        public string Password_hash { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        // Навигационное свойство - все заметки пользователя
        public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
        // Название лучше "Notes" (множественное число)
    }
}
