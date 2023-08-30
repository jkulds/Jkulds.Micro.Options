using System.Reflection;
using Jkulds.Micro.Options.Helpers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jkulds.Micro.Options.Installers;

public static class OptionsInstaller
{
    private static readonly MethodInfo ConfigureMethodInfo;
    
    static OptionsInstaller() => ConfigureMethodInfo = GetConfigureMethodInfo();
    
    public static void AddExternalServiceOptions(this IServiceCollection services, ConfigurationManager configuration, List<Type> optionsTypeList) 
    {
        foreach (var optionType in optionsTypeList)
        {
            var optionName = optionType.Name.Replace("Options", "");
            
            var genericConfigureMethodInfo = ConfigureMethodInfo.MakeGenericMethod(optionType);
            genericConfigureMethodInfo.Invoke(null,
                new object[] { services, configuration.GetSection(optionName) });
        }
    }
    
    private static MethodInfo GetConfigureMethodInfo()
        => typeof(OptionsConfigurationServiceCollectionExtensions)
            .GetMethod(
                nameof(OptionsConfigurationServiceCollectionExtensions.Configure),
                BindingFlags.Static | BindingFlags.Public,
                null,
                new[] { typeof(IServiceCollection), typeof(IConfiguration) },
                null)!;
}