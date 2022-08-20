namespace FunpayGold.MVC.ViewModels
{
    public class UserViewModel
    {

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public List<BotViewModel> Bots { get; set; }

        public UserViewModel()
        {
            Bots = new List<BotViewModel>();
        }

    }
}
