namespace Domain.Entities;

public class Book : Entity
{
    public int Title { get; set; }

    public string Genre { get; set; }
    public string AuthorName { get; set; }
    public int Year { get; set; }
}