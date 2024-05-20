
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly MessagesContext _context;
    private readonly KafkaProducer _producer;

    public MessagesController(MessagesContext context)
    {
        _context = context;
        _producer = new KafkaProducer();
    }

    [HttpPost]
    public async Task<IActionResult> PostMessage([FromBody] Message message)
    {
        message.Timestamp = DateTime.UtcNow;
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        _producer.Produce("message_topic", message.Content);

        return Ok(message);
    }
}
