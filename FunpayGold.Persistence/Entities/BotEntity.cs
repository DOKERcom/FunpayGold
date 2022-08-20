namespace FunpayGold.Persistence.Entities;

public class BotEntity
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public string? Name { get; set; }

    public string? Proxy { get; set; }

    public string? ProxyLogin { get; set; }

    public string? ProxyPassword { get; set; }

    public string? AccountLogin { get; set; }

    public string? AccountPassword { get; set; }

    public string? AccountPhoneNumber { get; set; }

    public string? TelegramBotKey { get; set; }

}