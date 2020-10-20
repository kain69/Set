using System;

namespace Set
{
    class Program
    {
        static void Main(string[] args)
        {
            Set<int> set0 = new Set<int>();
            // Проверка на максимально число (по заданию 2000)
            // Если поставить границу i <= 2000, работает
            // Если поставить границу i <= 2001, выбросит кастомную ошибку
            for (int i = 1; i <= 2000; i++)
            {
                set0.Add(i);
            }

            Set<int> set1 = new Set<int>(new int[] { 1, 2, 3, 4, 5 });
            Set<int> set2 = new Set<int>(new int[] { 4, 5, 6, 7, 8 });
            Set<int> set3 = new Set<int>(new int[] { 3, 4, 5 });

            Console.Write("A: ");
            foreach (int item in set1)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("B: ");
            foreach (int item in set2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("C: ");
            foreach (int item in set3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            Console.Write("Union: ");
            foreach (int item in set1.Union(set2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Intersection: ");
            foreach (int item in set1.Intersection(set2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Difference A\\B: ");
            foreach (int item in set1.Difference(set2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("Difference B\\A: ");
            foreach (int item in set2.Difference(set1))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("A Subset C: ");
            Console.Write(set3.SubSet(set1));
            Console.WriteLine();

            Console.Write("C Subset A: ");
            Console.Write(set1.SubSet(set3));
            Console.WriteLine();

            Console.Write("C Subset B: ");
            Console.Write(set2.SubSet(set3));
            Console.WriteLine();

            Console.Write("Symmetric Difference: ");
            foreach (int item in set1.SymmetricDifference(set2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
