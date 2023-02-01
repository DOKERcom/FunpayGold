using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Persistence.Entities
{
    public class WorkerEntity
    {
        [Required]
        public Guid Id { get; set; }

        public List<BotEntity> Bots { get; set; }

        public WorkerEntity()
        {
            Bots = new List<BotEntity>();
        }

    }
}
