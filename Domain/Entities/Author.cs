namespace Domain.Entities;

public class Author : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime Birthday { get; set; }

}