using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysOfTheWeek =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            DisplayDays(daysOfTheWeek);

            SpecificDayOfTheWeek(daysOfTheWeek);
        }

        static void DisplayDays(string[] daysOfTheWeek)
        {
            foreach (var day in daysOfTheWeek)
            {
                Console.WriteLine(day);
            }
        }

        private static void SpecificDayOfTheWeek(string[] daysOfTheWeek)
        {
            Console.WriteLine("From 1 to 7 which day u want to display? ");
            int dayNum = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine($"That day is {daysOfTheWeek[dayNum - 1]}");
        }
    }
}
