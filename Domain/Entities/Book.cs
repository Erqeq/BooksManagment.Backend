namespace Domain.Entities;

public class Book : Entity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
}