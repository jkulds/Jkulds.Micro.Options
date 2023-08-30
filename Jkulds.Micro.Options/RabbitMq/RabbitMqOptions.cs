﻿using Jkulds.Micro.Options.Base;

namespace Jkulds.Micro.Options.RabbitMq;

public class RabbitMqOptions : BaseOption
{
    public string UserName { get; set; } = "guest";
    public string Password { get; set; } = "guest";
    public int Port { get; set; } = 5672;
    public string Protocol { get; set; } = "amqp";
    public string Host { get; set; } = "localhost";
}