using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string cardNumber { get; set; }
        public int memberId { get; set; }

    }
}
