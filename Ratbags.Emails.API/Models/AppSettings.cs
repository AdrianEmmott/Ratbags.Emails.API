using Ratbags.Core.Settings;

namespace Ratbags.Emails.API.Models;

public class AppSettings : AppSettingsBase
{
    public Mail Mail { get; set; } = new Mail();
}

public class Mail
{
    public string NoReplyEmail { get; set; } = string.Empty;
    public SMTPSettings SMTPSettings { get; set; } = new SMTPSettings();
}

public class SMTPSettings
{
    public string Host { get; set; } = string.Empty;
    public string Port { get; set; } = string.Empty;
    public bool EnableSSL { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
