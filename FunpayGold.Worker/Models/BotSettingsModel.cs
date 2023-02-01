namespace FunpayGold.Worker.Models;

public class BotSettingsModel
{
    public Guid Id { get; set; }

    public bool IsActive { get; set; }

    public string ProxyIp { get; set; }

    public string ProxyLogin { get; set; }

    public string ProxyPassword { get; set; }

    public string AccountLogin { get; set; }

    public string AccountPassword { get; set; }

    public string AccountMobile { get; set; }

    public string? TelegramBotKey { get; set; }
}