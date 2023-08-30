namespace Jkulds.Micro.Options.Mailer;

public class MailerOptions
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public string Security { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}