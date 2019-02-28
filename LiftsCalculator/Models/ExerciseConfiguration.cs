using System.Collections.Generic;
using System.Linq;

namespace LiftsCalculator.Models
{
    public class ExerciseConfiguration
    {
        private readonly int _smallestIncrement = 250;

        public ExerciseConfiguration(Exercise exercise, ICollection<ExecutionConfiguration> executions)
        {
            Exercise = exercise;
            Executions = executions;
        }

        public Exercise Exercise { get; set; }
        public ICollection<ExecutionConfiguration> Executions { get; set; }

        public decimal GetExecutionWeight(int set)
        {
            var executionWeight = Exercise.TrainingMax * Executions.ElementAt(set).Percentage;
            var extraWeight = executionWeight % _smallestIncrement;
            if (extraWeight != 0)
            {
                executionWeight -= extraWeight;
                if (extraWeight >= _smallestIncrement - 100)
                {
                    executionWeight += _smallestIncrement;   
                }
            }
            return executionWeight / 100;
        }
    }
}
