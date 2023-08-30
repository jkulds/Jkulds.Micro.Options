using Jkulds.Micro.Options.Base;

namespace Jkulds.Micro.Options.Redis;

public class RedisOptions : BaseOption
{
    public string ConnectionString { get; set; } = "localhost:6379,allowAdmin=yes";
    public TimeSpan DefaultExpire { get; set; } = new(12, 0, 0);
}