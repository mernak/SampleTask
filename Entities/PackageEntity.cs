using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Entities
{
    public class PackageEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubscriptionDuration { get; set; }
        public int FreePtsessions { get; set; }
        public int Cost { get; set; }
        public int Discount { get; set; }
        public int FinalPrice { get; set; }
    }
}
