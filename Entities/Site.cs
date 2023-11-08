namespace mediatr_consoleapp1.Entities;

public class Site
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Domain { get; set; }
    public string? Url { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedbyUser { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedbyUser { get; set; }
}
