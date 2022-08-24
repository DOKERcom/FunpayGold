using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Models
{
    public class WorkerModel
    {

        [Required]
        public Guid Id { get; set; }

        public List<BotModel> Bots { get; set; }

        public WorkerModel(Guid id)
        {
            Id = id;

            Bots = new List<BotModel>();
        }

    }
}
