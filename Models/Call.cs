using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneCentral.Models
{
    public class Call
    {

        public int Id { get; private set; }

        public int DurationInSec { get; private set; }

        private readonly Random random = new Random();

        public Call(int listCounter)
        {
            Id = listCounter;
            DurationInSec = random.Next(5, 10);
        }
    }
}
