using SampleTaskServerSide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Models
{
    public class Member : User
    {
        public int TrainerId { get; set; }
        public virtual User Trainer { get; set; }
        public int PackageId { get; set; }
        public virtual Package Package {get; set;}
        public string PaymentMethod { get; set; }

    }
}
