using System.ComponentModel.DataAnnotations;

namespace FunpayGold.MVC.ViewModels
{
    public class WorkerViewModel
    {
        [Required]
        public Guid Id { get; set; }

        public List<BotViewModel> Bots { get; set; }

        public WorkerViewModel()
        {
            Bots = new List<BotViewModel>();
        }
    }
}
