
using Confluent.Kafka;
using System;
using System.Threading;

public class KafkaConsumer
{
    private readonly IConsumer<Null, string> _consumer;

    public KafkaConsumer()
    {
        var config = new ConsumerConfig
        {
            GroupId = "message_group",
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        _consumer = new ConsumerBuilder<Null, string>(config).Build();
    }

    public void Consume(string topic)
    {
        _consumer.Subscribe(topic);

        while (true)
        {
            var cr = _consumer.Consume(CancellationToken.None);
            Console.WriteLine($"Consumed message '{cr.Value}' at: '{cr.TopicPartitionOffset}'.");
        }
    }
}
