namespace DataAccess;

public class Note
{
    public int Id { get; set; }
    public int Id_person { get; set; }
    public string Text { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}