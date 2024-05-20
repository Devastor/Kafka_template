
using Microsoft.EntityFrameworkCore;

public class Message
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
}

public class MessagesContext : DbContext
{
    public DbSet<Message> Messages { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=messages;Username=admin;Password=password");
    }
}
