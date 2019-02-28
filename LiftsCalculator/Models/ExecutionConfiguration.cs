namespace LiftsCalculator.Models
{
    public class ExecutionConfiguration
    {
        public ExecutionConfiguration(int sets, int reps, int percentage, bool amrap)
        {
            Sets = sets;
            Reps = reps;
            Percentage = percentage;
            Amrap = amrap;
        }

        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Percentage { get; set; }
        public bool Amrap { get; set; }
    }
}
