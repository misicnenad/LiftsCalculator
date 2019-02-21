using System.Collections.Generic;

namespace LiftsCalculator.Models
{
  public class ExerciseConfiguration
    {
        public ExerciseConfiguration(Exercise exercise, ICollection<ExecutionConfiguration> executions)
        {
            Exercise = exercise;
            Executions = executions;
        }

        public Exercise Exercise { get; set; }
        public ICollection<ExecutionConfiguration> Executions { get; set; }
    }
}
