using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Models
{
    public class BotActivityModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Message { get; set; }

        public BotModel? Bot { get; set; }
    }
}
