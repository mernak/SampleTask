using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Entities
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public string cardNumber { get; set; }
        public int memberId { get; set; }
        [JsonIgnore]
        public virtual MemberEntity Member { get; set; }
    }
}
