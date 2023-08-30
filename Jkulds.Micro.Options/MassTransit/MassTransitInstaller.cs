using Jkulds.Micro.Options.Helpers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Jkulds.Micro.Options.MassTransit;

public static class MassTransitInstaller
{
    public static void AddMassTransitWithRabbitMq(this IServiceCollection services, List<Type>? consumersTypeList = null)
    {
        services.AddMassTransit(x =>
        {
            if (consumersTypeList?.Any() == true)
            {
                foreach (var consumerType in consumersTypeList)
                {
                    x.AddConsumer(consumerType);
                }
            }

            x.UsingRabbitMq((context, cfg) =>
            {
                if (EnvironmentHelper.IsDockerRunning())
                {
                    cfg.Host("rabbit", 5672, "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                }
                else
                {
                    cfg.ConfigureEndpoints(context);
                }
            });
        });
    }
}