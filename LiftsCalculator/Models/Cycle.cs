using System.Collections.Generic;

namespace LiftsCalculator.Models
{
    public class Cycle
    {
        public Cycle(
            int cycleNumber,
            int numberOfWeeks,
            ICollection<Exercise> mainExercises,
            ICollection<Exercise> assisstanceExercises)
        {
            CycleNumber = cycleNumber;
            Weeks = new List<Week>();
            for(var weekNumber = 1; weekNumber <= numberOfWeeks; weekNumber++)
            {
                Weeks.Add(new Week(weekNumber, mainExercises, assisstanceExercises));
            }
        }

        public int CycleNumber { get; set; }
        public ICollection<Week> Weeks { get; set; }
    }
}
