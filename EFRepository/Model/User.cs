using System;
using System.Text.Json.Serialization;

namespace EFRepository.Model
{
    public class User
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal MonthlyExpenses { get; set; }
        public DateTime CreationDate { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
    }
}
