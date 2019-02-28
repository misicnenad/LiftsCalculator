using System.Collections.Generic;
using System.Linq;

namespace LiftsCalculator.Models
{
    public class Week
    {
        public Week(
            int weekNumber,
            ICollection<ExerciseConfiguration> mainExerciseConfigurations,
            ICollection<ExerciseConfiguration> assistanceExerciseConfigurations)
        {
            WeekNumber = weekNumber;
            MainExerciseConfigurations = mainExerciseConfigurations;
            AssistanceExerciseConfigurations = assistanceExerciseConfigurations;
        }

        public int WeekNumber { get; set; }
        public ICollection<ExerciseConfiguration> MainExerciseConfigurations { get; set; }
        public ICollection<ExerciseConfiguration> AssistanceExerciseConfigurations { get; set; }
        public int MainSets
        {
            get
            {
                var sets = 0;
                foreach(ExecutionConfiguration ec in MainExerciseConfigurations.First().Executions)
                {
                    sets += ec.Sets;
                }
                return sets;
            }
        }
        public int AssistanceSets
        {
            get
            {
                var sets = 0;
                foreach (ExecutionConfiguration ec in AssistanceExerciseConfigurations.First().Executions)
                {
                    sets += ec.Sets;
                }
                return sets;
            }
        }
    }
}
