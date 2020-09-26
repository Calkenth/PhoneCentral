using PhoneCentral.Data;
using PhoneCentral.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Timers;

namespace PhoneCentral
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        private static List<Call> calls = new List<Call>();
        private static List<Agent> agents;

        static void Main(string[] args)
        {
            agents = SeedingLists.GetAgents();
            calls = SeedingLists.GetCalls();

            Console.WriteLine("----------------");
            Console.WriteLine("Press N to add new custom call.");
            Console.WriteLine("Press Esc to close.");
            Console.WriteLine("----------------");

            SetCallTimer();
            SetAgentTimer();

            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.N)
                {
                    calls.Add(new Call(calls.Count));
                    Console.WriteLine($"New CUSTOM call added to list at index {calls.Count} with time of call equal {calls.Last().DurationInSec}");
                }
                else if(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }

        private static void SetAgentTimer()
        {
            aTimer = new System.Timers.Timer(500);
            aTimer.Elapsed += OnAgentTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnAgentTimedEvent(object sender, ElapsedEventArgs e)
        {
            Thread thread = new Thread(() => TakeCall());
            thread.Start();
        }

        private static void TakeCall()
        {
            var agent = agents.FirstOrDefault(a => a.Occupied == false);
            if (agent != null)
            {
                var call = calls.FirstOrDefault();
                if (call != null)
                {
                    agent.StartCall(call);
                    calls.Remove(call);
                }
                else
                {
                    Console.WriteLine("No awaiting calls at the moment.");
                }
            }
            else
            {
                Console.WriteLine("No free agents at the moment.");
            }
        }

        private static void SetCallTimer()
        {
            aTimer = new System.Timers.Timer(5000);
            aTimer.Elapsed += OnCallTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnCallTimedEvent(Object source, ElapsedEventArgs e)
        {
            calls.Add(new Call(calls.Count));
            Console.WriteLine($"New call added to list at index {calls.Count} with time of call equal {calls.Last().DurationInSec}");
        }
    }
}
