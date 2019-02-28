using LiftsCalculator.Models;
using System;
using System.Collections.Generic;

namespace LiftsCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var shouldCreate = true;
            while (shouldCreate)
            {
                CreateCycle();
                Console.WriteLine("Create a new one? (y/n)");
                var line = Console.ReadLine();
                while (line != "n" && line != "y" && line != "N" && line != "Y")
                {
                    Console.WriteLine("Create a new one? (y/n)");
                    line = Console.ReadLine();
                }
                if (line == "n")
                {
                    shouldCreate = false;
                }
            }
        }

        private static void CreateCycle()
        {
            Console.Write("Cycle number (type 'n' to exit): ");
            var line = Console.ReadLine();
            Console.WriteLine();

            if (line == "n")
            {
                return;
            }

            if (Int32.TryParse(line, out int cycleNumber))
            {
                var exercises = new List<Exercise>
                    {
                        new Exercise("Overhead", 45, 2.5m),
                        new Exercise("Deadlift", 130, 5),
                        new Exercise("Bench", 80, 2.5m),
                        new Exercise("Squat", 100, 5)
                    };
                var cycle = new Cycle(cycleNumber, exercises, exercises);

                var cycleRenderer = new CycleRenderer(cycle);
                RenderDependingOfWeek(cycleRenderer);
            }
            else
            {
                Console.WriteLine("Error! Can't parse to integer, try again.");
                CreateCycle();
            }
        }

        private static void RenderDependingOfWeek(CycleRenderer cycleRenderer)
        {
            Console.Write("Week number (type 'n' for no specific week): ");
            var line = Console.ReadLine();
            Console.WriteLine();
            if (line != "n")
            {
                if (Int32.TryParse(line, out int weekNumber))
                {
                    if (weekNumber > 0 && weekNumber < 8)
                    {
                        cycleRenderer.RenderAsTableByWeek(weekNumber);
                    }
                    else
                    {
                        Console.WriteLine("Week out of range, rendering everything");
                        cycleRenderer.RenderAllAsTable();
                    }
                }
                else
                {
                    Console.WriteLine("Error! Can't parse to integer, try again.");
                    RenderDependingOfWeek(cycleRenderer);
                }
            }
            else
            {
                cycleRenderer.RenderAllAsTable();
            }
        }
    }
}
