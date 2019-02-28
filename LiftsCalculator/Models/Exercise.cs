namespace LiftsCalculator.Models
{
    public class Exercise
    {
        private readonly decimal _defaultIncrement = 2.5m;
        public Exercise(string name, decimal trainingMax, decimal exerciseIncrement)
        {
            Name = name;
            TrainingMax = trainingMax;
            ExerciseIncrement = exerciseIncrement;
        }
        public Exercise(string name, int trainingMax)
        {
            Name = name;
            TrainingMax = trainingMax;
            ExerciseIncrement = _defaultIncrement;
        }

        public string Name { get; set; }
        public decimal TrainingMax { get; set; }
        public decimal ExerciseIncrement { get; set; }

        public Exercise GetCurrentExerciseByCycleNumber(int cycleNumber)
        {
            var newTrainingMax = TrainingMax + (cycleNumber - 1) * ExerciseIncrement;
            return new Exercise(Name, newTrainingMax, ExerciseIncrement);
        }
    }
}
