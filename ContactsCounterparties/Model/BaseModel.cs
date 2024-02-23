namespace ContactsCounterparties.Model;

public record BaseModel
{
    public int Id { get; set; }
    public DateTime CreationTime { get; } = DateTime.Now;
    public DateTime UpdateTime { get; init; } = DateTime.Now;
}