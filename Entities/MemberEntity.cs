using SampleTaskServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Entities
{
    public class MemberEntity : User
    {
        public int? TrainerId { get; set; }
        public virtual TrainerEntity Trainer { get; set; }
        public int? PackageId { get; set; }
        public virtual PackageEntity Package { get; set; }
        public string PaymentMethod { get; set; }
    }
}
