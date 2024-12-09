using Kitchen.Consumer;
using MassTransit;
using Microsoft.AspNetCore.Hosting;

namespace Kitchen;

public class Program
{
    public static async Task Main(string[] args)
    {

        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                // ����������� MassTransit
                services.AddMassTransit(x =>
                {
                    // ����������� consumer
                    x.AddConsumer<KitchenConsumer>();

                    // ��������� RabbitMQ
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host("rabbitmq://localhost", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });

                        cfg.ReceiveEndpoint("kitchen_queue", e =>
                        {
                            e.ConfigureConsumer<KitchenConsumer>(context);
                        });
                    });
                });
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .Build();

        await host.RunAsync();

    }
}