using SampleTaskServerSide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public int TrainerId { get; set; }
        public virtual List<User> Trainer { get; set; }
        public int MemberId { get; set; }
        public virtual List<Member> Member { get; set; }

        public DateTime Date { get; set; }

    }
}
