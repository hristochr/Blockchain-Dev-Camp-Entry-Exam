namespace _02.TheWall
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
                
            List<int> dailyCost = new List<int>();

            int dayCost = -1;
            while (dayCost != 0)
            {
                dayCost = 0;
                for (int i = 0; i < input.Count; i++)
                {
                    int currentHeight = input[i];
                    if (currentHeight < 30)
                    {
                        dayCost += 195;
                        input[i]++;
                    }
                }
                dailyCost.Add(dayCost);
            }
            Console.WriteLine(string.Join(", ", dailyCost.TakeWhile(x => x != 0)));
            Console.WriteLine($"{dailyCost.Sum() * 1900} coins");
        }
    }
}
