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
            Console.WriteLine(new String(' ', 20) + $"---------" + new String(' ', 20));
            Console.WriteLine(new String(' ', 20) + $"|Week: {week.WeekNumber}|" + new String(' ', 20));
            Console.WriteLine(new String(' ', 20) + $"---------" + new String(' ', 20));

            foreach (Exercise ex in week.MainExercises)
            {
                Console.Write("|{0, -10}|", ex.Name);
            }
            Console.WriteLine("\n" + new String('-', 48));

            // TODO write out main exercises

            foreach (Exercise ex in week.AssistanceExercises)
            {
                Console.Write("|{0, -10}|", ex.Name);
            }
            Console.WriteLine("\n" + new String('-', 48));

            // TODO write out assisstance exercises

            Console.WriteLine("\n" + new String('=', 48) + "\n\n");
        }
    }
}
