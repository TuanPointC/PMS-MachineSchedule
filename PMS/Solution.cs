﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS
{
    internal class Solution
    {
        public List<HashSet<int>> Machines { get; set; } = new List<HashSet<int>>();
        public double MaxTime { get; set; }
        public List<double> TotalTime { get; set; } = new List<double>();
        public List<int> Address { get; set; } = new List<int>();

        public Solution(int numberOfMachines, int numberOfJobs)
        {
            for (int i = 0; i < numberOfMachines; i++)
            {
                Machines.Add(new HashSet<int>());
            }

            MaxTime = 0;

            for (int i = 0; i < numberOfMachines; i++)
            {
                TotalTime.Add(0);
            }
            for (int i = 0; i < numberOfJobs; i++)
            {
                Address.Add(-1);
            }
        }

        public int GetShortestMachine()
        {
            int shortest = 0;
            for (int i = 1; i < Machines.Count; i++)
            {
                if (TotalTime[i] < TotalTime[shortest])
                {
                    shortest = i;
                }
            }
            return shortest;
        }

        public void Display()
        {
            Console.WriteLine($"Number of machines: {Machines.Count}");
            for(int i = 0; i < Machines.Count; i++)
            {
                Console.Write($"Machine {i+1} Total time: {TotalTime[i]} List works: ");
                foreach(var machine in Machines[i])
                {
                    Console.Write($"{machine} ");
                }
                Console.WriteLine();
            }
        }
    }
}
