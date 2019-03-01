using LiftsCalculator.Models;
using System;
using System.Linq;

namespace LiftsCalculator
{
    public class CycleRenderer
    {
        public CycleRenderer(Cycle cycle)
        {
            Cycle = cycle;
        }

        public Cycle Cycle { get; set; }

        internal void RenderAllAsTable()
        {
            foreach (Week week in Cycle.Weeks)
            {
                RenderWeek(week);
            }
        }

        internal void RenderAsTableByWeek(int weekNumber)
        {
            var week = Cycle.Weeks.Where(w => w.WeekNumber == weekNumber).SingleOrDefault();
            if (week != null)
            {
                RenderWeek(week);
            }
        }

        private void RenderWeek(Week week)
        {
            Console.WriteLine(new string(' ', 20) + $"---------");
            Console.WriteLine(new string(' ', 20) + $"|Week: {week.WeekNumber}|");
            Console.WriteLine(new string(' ', 20) + $"---------");
            Console.WriteLine(new string(' ', 34) + "MAIN");

            foreach (ExerciseConfiguration ec in week.MainExerciseConfigurations)
            {
                var exerciseName = ec.Exercise.Name;
                var emptySpaceWidth = (16 - exerciseName.Length) / 2;
                var str = $"{{0, {emptySpaceWidth + exerciseName.Length}}}";
                Console.Write("|" + str + new string(' ', emptySpaceWidth) + "|", exerciseName);
            }
            Console.WriteLine("\n" + new string('-', 48));
            Console.WriteLine(new string(' ', 30) + "TRAINING MAX");

            foreach (ExerciseConfiguration ec in week.MainExerciseConfigurations)
            {
                Console.Write("|{0, 16}|", ec.Exercise.TrainingMax);
            }
            Console.WriteLine("\n" + new string('-', 48));

            var set = 0;
            while (set < week.MainSets)
            {
                foreach (ExerciseConfiguration ec in week.MainExerciseConfigurations)
                {
                    var execution = ec.Executions.ElementAt(set);
                    Console.Write("|{0}% x {1}{2} - {3, 5}|", 
                        execution.Percentage, 
                        execution.Reps, 
                        execution.Amrap ? "+" : " ", 
                        ec.GetExecutionWeight(set));
                }
                Console.WriteLine();
                set++;
            }
            Console.WriteLine("\n" + new string('-', 48));
            Console.WriteLine(new string(' ', 37) + "ASSISSTANCE");

            foreach (ExerciseConfiguration ec in week.AssistanceExerciseConfigurations)
            {
                Console.Write("|{0, 20}|", ec.Exercise.Name);
            }
            Console.WriteLine("\n" + new string('-', 48));

            foreach (ExerciseConfiguration ec in week.AssistanceExerciseConfigurations)
            {
                var execution = ec.Executions.First();
                Console.Write("|{0}% x {1} x {2} - {3, 5}|", 
                    execution.Percentage, 
                    execution.Sets,
                    execution.Reps, 
                    ec.GetExecutionWeight(0));
            }
            Console.WriteLine("\n" + new string('-', 48));

            // TODO write out assisstance exercises

            Console.WriteLine("\n" + new string('=', 48) + "\n\n");
        }
    }
}
