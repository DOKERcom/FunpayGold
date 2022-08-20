using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Common.Models
{
    public class ResultActionModel
    {

        public int ResultCode { get; set; }

        public string ResultMessage { get; set; }

        public ResultActionModel(int resultCode = 200, string resultMessage = "")
        {
            ResultCode = resultCode;
            ResultMessage = resultMessage;
        }
    }
}
