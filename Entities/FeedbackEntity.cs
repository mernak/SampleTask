using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Entities
{
    public class FeedbackEntity
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public int TrainerId { get; set; }
        public virtual List<TrainerEntity> Trainers { get; set; }
        public int MemberId { get; set; }
        public virtual List<MemberEntity> Members { get; set; }

        public DateTime Date { get; set; }
    }
}
