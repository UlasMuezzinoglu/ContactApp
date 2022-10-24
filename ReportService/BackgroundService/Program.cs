using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BackgroundService.Dto;
using Business.Abstract;
using Business.Concrete;
using Business.Utils;
using Confluent.Kafka;
using IronXL;
using OfficeOpenXml;
using static Confluent.Kafka.ConfigPropertyNames;

namespace BackgroundService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var conf = new ConsumerConfig
            {
                GroupId = "reportConsumer",
                BootstrapServers = "localhost:9092",
            };
            ExcelUtil util = new ExcelUtil();

            using (var consumer = new ConsumerBuilder<Null, string>(conf).Build()) {
                consumer.Subscribe("reportApplies");

                CancellationTokenSource token = new();

                try
                {
                    while (true) { 
                        var response = consumer.Consume(token.Token);
                        if (response.Message != null && !(response.Message.Value == "initalize"))
                        {
                            GetReportsResponse reportResponse = getReport(response.Message.Value).Result;
                            var path = ExcelUtil.CreateExcelFile(reportResponse.peopleCount, reportResponse.gsmCount, response.Message.Value);
                            util.uploadReportEntity(path);
                        }
                        
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

           
        }

        public async static Task<GetReportsResponse> getReport(string location) {
            using (var client = new HttpClient()) {
                var result = await client.GetAsync(new Uri("http://localhost:5000/api/ContactModels/GetAllReportTypes" + (string.IsNullOrEmpty(location) ? "" : "?location="+location)));

                var json = await result.Content.ReadAsStringAsync();

                GetReportsResponse getReportsResponse = JsonSerializer.Deserialize<GetReportsResponse>(json);
                return getReportsResponse;
            }
        }
    }
}
