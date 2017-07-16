﻿using HelloWorld.Interfaces;
using Orleans;
using Orleans.Runtime;
using Orleans.Runtime.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrleansClient
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeWithRetries();

            DoClientWork().Wait();

            Console.WriteLine("Press any key to stop.");
            Console.ReadLine();
        }

        private static void InitializeWithRetries()
        {
            try
            {
                GrainClient.Initialize("ClientConfiguration.xml");
                Console.WriteLine("Client successfully connect to silo host.");
            }
            catch (SiloUnavailableException ex)
            {
                Console.WriteLine($"Failed to initialize the Orleans client.\n\n{ex}");
                Console.ReadLine();
            }
        }

        private static async Task DoClientWork()
        {
            var friend = GrainClient.GrainFactory.GetGrain<IHello>(0);

            Console.WriteLine("{0}\n", await friend.SayHello("First"));
            Console.WriteLine("{0}\n", await friend.SayHello("Second"));
            Console.WriteLine("{0}\n", await friend.SayHello("Third"));
            Console.WriteLine("{0}\n", await friend.SayHello("Fourth"));
        }
    }
}
