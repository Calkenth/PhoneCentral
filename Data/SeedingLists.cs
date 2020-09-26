using PhoneCentral.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneCentral.Data
{
    public static class SeedingLists
    {
        private const string agentOne = "Adam";

        private const string agentTwo = "Eve";

        private const string agentThree = "Caroline";

        public static List<Agent> GetAgents()
        {
            return new List<Agent>
            {
                new Agent(agentOne),
                new Agent(agentTwo),
                new Agent(agentThree)
            };
        }

        public static List<Call> GetCalls()
        {
            return new List<Call>
            {
                new Call(0),
                new Call(1),
                new Call(2),
                new Call(3),
                new Call(4)
            };
        }
    }
}
