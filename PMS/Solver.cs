using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS
{
    internal class Solver
    {
        private Instance? _instance { get; set; }
        private Solution? _solution { get; set; }

        public Solver(Instance instance)
        {
            _instance = instance;
            _solution = new Solution(instance.NumberOfMachines, instance.NumberOfJobs);
        }

        public void InsertJob(int indexJob, int indexMachine)
        {
            if (_solution != null && _instance != null)
            {
                _solution.Machines[indexMachine].Add(indexJob);
                _solution.TotalTime[indexMachine] += _instance.GetTime(indexMachine);
                _solution.MaxTime = Math.Max(_solution.MaxTime, _solution.TotalTime[indexMachine]);
                _solution.Address[indexJob] = indexMachine;
            }
        }

        public void Construction()
        {
            List<Tuple<double, int>> jobWithTime = new();
            for (int i = 0; i < _instance?.NumberOfJobs; i++)
            {
                jobWithTime.Add(new Tuple<double, int>(_instance.GetTime(i), i));
            }

            jobWithTime.Sort();

            foreach (var job in jobWithTime)
            {
                if (_solution != null)
                {
                    var indexMachine = _solution.GetShortestMachine();
                    InsertJob(job.Item2, indexMachine);
                }
            }
        }

        public void Display()
        {
            _solution?.Display();
        }
    }
}
