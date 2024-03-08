namespace FL_Test_1;

[Serializable]
public class Message
{
    public Guid Id { get; set; }
    public string? Text { get; set; }
    public string? Title { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    public override string ToString()
    {
        return string.Format($"Id: {Id} Text: {Text} Title: {Title} CreatedAt: {CreatedAt}");
    }
}
