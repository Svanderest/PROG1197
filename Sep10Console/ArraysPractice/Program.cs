using System;

namespace ArraysPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grades = new int[5][];
            grades[0] = new int[2];
            grades[1] = new int[4];
            grades[2] = new int[1];
            grades[3] = new int[3];
            grades[4] = new int[5];

            for(int i = 0; i < grades.Length; i++)
            {
                for(int j = 0; j < grades[i].Length; j++)
                {
                    do
                    {
                        Console.WriteLine(string.Format("Please enter your grade for test {0} in Course {1}", new object[] { j, i }));
                    } while (!int.TryParse(Console.ReadLine(), out grades[i][j]) || grades[i][j] < 0 || grades[i][j] > 100);
                }
            }
        }
    }
}
