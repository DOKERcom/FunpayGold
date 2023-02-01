using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Persistence.Entities
{
    public class BotActivityEntity
    {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Message { get; set; }

    }
}
