namespace LiftsCalculator.Models
{
    public class ExecutionConfiguration
    {
        public ExecutionConfiguration(int sets, int reps, int weight)
        {
            Sets = sets;
            Reps = reps;
            Weight = weight;
        }

        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }
    }
}
