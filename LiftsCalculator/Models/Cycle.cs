using System.Collections.Generic;

namespace LiftsCalculator.Models
{
    public class Cycle
    {
        private readonly int _numberOfWeeksPerCycle = 3;
        private readonly int _percentageIncreasePerWeek = 5;
        private readonly int _firstSetBasePercentage = 65;
        private readonly int _secondSetBasePercentage = 75;
        private readonly int _thirdSetBasePercentage = 85;

        public Cycle(
            int cycleNumber,
            ICollection<Exercise> mainExercises,
            ICollection<Exercise> assisstanceExercises)
        {
            CycleNumber = cycleNumber;
            Weeks = CreateWeeks(cycleNumber, mainExercises, assisstanceExercises);
        }

        private ICollection<Week> CreateWeeks(int cycleNumber, ICollection<Exercise> mainExercises, ICollection<Exercise> assisstanceExercises)
        {
            return new List<Week>
            {
                CreateFirstWeek(cycleNumber, mainExercises, assisstanceExercises),
                CreateSecondWeek(cycleNumber, mainExercises, assisstanceExercises),
                CreateThirdWeek(cycleNumber, mainExercises, assisstanceExercises)
            };
        }

        private Week CreateFirstWeek(int cycleNumber, ICollection<Exercise> mainExercises, ICollection<Exercise> assisstanceExercises)
        {
            var mec = new List<ExecutionConfiguration>
                {
                    new ExecutionConfiguration(1, 5, _firstSetBasePercentage, false),
                    new ExecutionConfiguration(1, 5, _secondSetBasePercentage, false),
                    new ExecutionConfiguration(1, 5, _thirdSetBasePercentage, true)
                };
            var aec = new List<ExecutionConfiguration>
                {
                    new ExecutionConfiguration(5, 10, 50, false)
                };
            return CreateWeekFromExecConfigs(cycleNumber, 1, mec, aec, mainExercises, assisstanceExercises);
        }

        private Week CreateSecondWeek(int cycleNumber, ICollection<Exercise> mainExercises, ICollection<Exercise> assisstanceExercises)
        {
            var mec = new List<ExecutionConfiguration>
                {
                    new ExecutionConfiguration(1, 3, _firstSetBasePercentage + 5, false),
                    new ExecutionConfiguration(1, 3, _secondSetBasePercentage + 5, false),
                    new ExecutionConfiguration(1, 3, _thirdSetBasePercentage + 5, true)
                };
            var aec = new List<ExecutionConfiguration>
                {
                    new ExecutionConfiguration(5, 10, 50, false)
                };
            return CreateWeekFromExecConfigs(cycleNumber, 2, mec, aec, mainExercises, assisstanceExercises);
        }

        private Week CreateThirdWeek(int cycleNumber, ICollection<Exercise> mainExercises, ICollection<Exercise> assisstanceExercises)
        {
            var mec = new List<ExecutionConfiguration>
                {
                    new ExecutionConfiguration(1, 5, _firstSetBasePercentage + 10, false),
                    new ExecutionConfiguration(1, 3, _secondSetBasePercentage + 10, false),
                    new ExecutionConfiguration(1, 1, _thirdSetBasePercentage + 10, true)
                };
            var aec = new List<ExecutionConfiguration>
                {
                    new ExecutionConfiguration(5, 10, 50, false)
                };
            return CreateWeekFromExecConfigs(cycleNumber, 3, mec, aec, mainExercises, assisstanceExercises);
        }

        private Week CreateWeekFromExecConfigs(
            int cycleNumber,
            int weekNumber,
            List<ExecutionConfiguration> mec, 
            List<ExecutionConfiguration> aec, 
            ICollection<Exercise> mainExercises,
            ICollection<Exercise> assisstanceExercises)
        {
            var meec = new List<ExerciseConfiguration>();
            foreach (Exercise ex in mainExercises)
            {
                var newEx = ex.GetCurrentExerciseByCycleNumber(cycleNumber);
                meec.Add(new ExerciseConfiguration(newEx, mec));
            }
            var aeec = new List<ExerciseConfiguration>();
            foreach (Exercise ex in assisstanceExercises)
            {
                var newEx = ex.GetCurrentExerciseByCycleNumber(cycleNumber);
                aeec.Add(new ExerciseConfiguration(newEx, aec));
            }

            return new Week(weekNumber, meec, aeec);
        }

        public int CycleNumber { get; set; }
        public ICollection<Week> Weeks { get; set; }
    }
}
