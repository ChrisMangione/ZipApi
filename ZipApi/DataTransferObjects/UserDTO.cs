using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZipApi.DataTransferObjects
{
    public class UserDTO
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal MonthlyExpenses { get; set; }
    }
}
