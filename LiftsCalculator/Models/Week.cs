using System.Collections.Generic;

namespace LiftsCalculator.Models
{
    public class Week
    {
        public Week(int weekNumber, ICollection<Exercise> mainExercises, ICollection<Exercise> assistanceExercises)
        {
            WeekNumber = weekNumber;
            MainExercises = mainExercises;
            AssistanceExercises = assistanceExercises;
        }

        public int WeekNumber { get; set; }
        public ICollection<Exercise> MainExercises { get; set; }
        public ICollection<Exercise> AssistanceExercises { get; set; }
    }
}
