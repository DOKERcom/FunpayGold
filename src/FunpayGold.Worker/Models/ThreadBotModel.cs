namespace FunpayGold.Worker.Models;

public class ThreadBotModel
{
    public BotSettingsModel BotSettingsModel { get; set; }

    public Thread BotThread { get; set; }
}