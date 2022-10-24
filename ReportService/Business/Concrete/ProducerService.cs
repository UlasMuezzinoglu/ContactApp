using Business.Abstract;
using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProducerService : IProducerService
    {


        ProducerConfig config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092",
        };

        public void PushReportApplyToQueue(String location)
        {

            if (!CheckTopicExists()) {
                _ = createTopicAsync();
            }

            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    p.Produce("reportApplies", new Message<Null, string> { Value = location });
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }


        private async Task createTopicAsync()
        {
            using (var adminClient = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = "localhost:9092" }).Build())
            {
                try
                {
                    await adminClient.CreateTopicsAsync(new TopicSpecification[] {
                    new TopicSpecification { Name = "reportApplies", ReplicationFactor = 1, NumPartitions = 1 } });
                }
                catch (CreateTopicsException e)
                {
                    Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
                }
            }
        }



        public bool CheckTopicExists()
        {
            using (var adminClient = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = "localhost:9092" }).Build())
            {
                try
                {
                    var metadata = adminClient.GetMetadata(TimeSpan.FromSeconds(10));
                    var topicsMetadata = metadata.Topics;
                    var topicNames = metadata.Topics.Select(a => a.Topic).ToList();

                    return topicNames.Contains("reportApplies");
                }
                catch (CreateTopicsException e)
                {
                    return false;
                }
            }
        }
    }
}
