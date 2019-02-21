namespace LiftsCalculator.Models
{
    public class Exercise
    {
        public Exercise(string name, int trainingMax)
        {
            Name = name;
            TrainingMax = trainingMax;
        }

        public string Name { get; set; }
        public int TrainingMax { get; set; }
    }
}
