namespace _01.JessysFriend
{

using System;

    class Program
    {
        static void Main(string[] args)
        {
            short startInterval = short.Parse(Console.ReadLine());
            short endInterval = short.Parse(Console.ReadLine());
            short magicNumber = short.Parse(Console.ReadLine());

            int combCounter = 0;

            for (int i = startInterval; i <= endInterval; i++)
            {

                for (int j = startInterval; j <= endInterval; j++)
                {
                    combCounter++;

                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{combCounter} ({i} + {j} = {magicNumber})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{combCounter} combinations - neither equals {magicNumber}");
        }
    }
}
