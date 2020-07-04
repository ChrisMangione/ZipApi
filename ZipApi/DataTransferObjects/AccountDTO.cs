using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZipApi.DataTransferObjects
{
    public class AccountDTO
    {
        public long AccountId { get; set; }
        public decimal AccountLimit { get; set; }
        public long UserId { get; set; }
    }
}
