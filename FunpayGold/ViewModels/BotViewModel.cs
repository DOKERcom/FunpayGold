using FunpayGold.Application.Models;

namespace FunpayGold.MVC.ViewModels
{
    public class BotViewModel
    {

        public string Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public bool IsActive { get; set; } = false;

        public string ProxyIp { get; set; } = String.Empty;

        public string ProxyLogin { get; set; } = String.Empty;

        public string ProxyPassword { get; set; } = String.Empty;

        public string AccountLogin { get; set; } = String.Empty;

        public string AccountPassword { get; set; } = String.Empty;

        public string AccountMobile { get; set; } = String.Empty;

        public string? TelegramBotKey { get; set; } = String.Empty;

        public WorkerViewModel? Worker { get; set; }

        public BotActivityViewModel? BotActivity { get; set; }
    }
}
