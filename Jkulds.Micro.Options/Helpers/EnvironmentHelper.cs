namespace Jkulds.Micro.Options.Helpers;

public static class EnvironmentHelper
{
    public static bool IsDockerRunning()
    {
        var variable = Environment.GetEnvironmentVariable("INDOCKER");
        
        return !string.IsNullOrEmpty(variable) && variable == "1";
    }
}