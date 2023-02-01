namespace FunpayGold.Persistence.Entities;

public class BotItemEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string KeyItemName { get; set; }

    public List<string> Items { get; set; }
}