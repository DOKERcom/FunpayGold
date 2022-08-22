namespace FunpayGold.Application.Models;

public class BotModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = String.Empty;

    public bool IsActive { get; set; } = false;

    public string ProxyIp { get; set; } = String.Empty;

    public string ProxyLogin { get; set; } = String.Empty;

    public string ProxyPassword { get; set; } = String.Empty;

    public string AccountLogin { get; set; } = String.Empty;

    public string AccountPassword { get; set; } = String.Empty;

    public string AccountMobile { get; set; } = String.Empty;

    public string? TelegramBotKey { get; set; } = String.Empty;
}