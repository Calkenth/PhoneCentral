using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhoneCentral.Models
{
    public class Agent
    {
        public string Name { get; private set; }

        public bool Occupied { get; private set; }

        public Agent(string name)
        {
            Name = name;
        }

        public void StartCall(Call call)
        {
            CallAnswered();
            Console.WriteLine($"~!!! {Name}: Call started.");
            Thread thread = new Thread(() => Call(call));
            thread.Start();
        }

        private void Call(Call call)
        {
            Console.WriteLine("Duration: " + call.DurationInSec);
            Thread.Sleep(call.DurationInSec * 1000);
            CallEnded();
            Console.WriteLine($"~!!! {Name}: Call ended.");
        }

        private void CallAnswered()
        {
            Occupied = true;
        }

        private void CallEnded()
        {
            Occupied = false;
        }
    }
}
