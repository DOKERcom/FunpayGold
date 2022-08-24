using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Common.ResultModels
{
    public class ResultActionModel
    {

        public int ResultCode { get; set; }

        public string ResultMessage { get; set; }

        public object ResultObject { get; set; }

        public ResultActionModel(int resultCode = 200, string resultMessage = "", object resultobject = null)
        {
            ResultCode = resultCode;

            ResultMessage = resultMessage;

            ResultObject = resultobject;
        }
    }
}
