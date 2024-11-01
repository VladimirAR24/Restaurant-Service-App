using Kitchen.Consumer;
using MassTransit;

namespace Kitchen;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Метод для добавления сервисов в контейнер
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Настройка MassTransit с RabbitMQ
        services.AddMassTransit(x =>
        {
            // Регистрируем consumer для обработки сообщений
            x.AddConsumer<KitchenConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                // Определяем очередь, на которую будет подписан consumer
                cfg.ReceiveEndpoint("kitchen_queue", e =>
                {
                    e.ConfigureConsumer<KitchenConsumer>(context);
                });
            });
        });

        // Включаем MassTransit Hosted Service
        //services.AddMassTransitHostedService();
    }

    // Метод конфигурирует HTTP конвейер запросов
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
