using SampleTaskServerSide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleTaskServerSide.Models
{
    public class Trainer : User
    {
        public int Salary { get; set; }
    }
}
