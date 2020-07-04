using System;
using System.Text.Json.Serialization;

namespace EFRepository.Model
{
    public class Account
    {
        public long AccountId { get; set; }
        public decimal AccountLimit { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreationDate { get; set; }
        public long UserId { get; set; }
        [JsonIgnore]
        public User User {get;set;}
    }
}
