namespace DataAccess.Entities;

public class Note
{
    public int Id { get; set; }
    public int Id_person { get; set; }
    public string Text { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    // Навигационное свойство - владелец заметки
    public virtual Person Person { get; set; }
}