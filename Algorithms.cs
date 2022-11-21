using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public static class Algorithms
    {

        /// <summary>
        /// Тасование Фишера–Йетса 
        /// https://en.wikipedia.org/wiki/Fisher–Yates_shuffle
        /// </summary>
        private static Random rng = new Random();
            
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        public static int[,] Combine(params int[][] arrays)
        {
            int[][] combined = CombineRecursive(arrays).Select(x => x.ToArray()).ToArray();
            return JaggedToRectangular(combined);
        }

        public static IEnumerable<IEnumerable<int>> CombineRecursive(IEnumerable<IEnumerable<int>> arrays)
        {
            if (arrays.Count() > 1)
                return from a in arrays.First()
                       from b in CombineRecursive(arrays.Skip(1))
                       select Enumerable.Repeat(a, 1).Union(b);
            else
                return from a in arrays.First()
                       select Enumerable.Repeat(a, 1);
        }

        public static int[,] JaggedToRectangular(int[][] combined)
        {
            int length = combined.Length;
            int width = combined.Min(x => x.Length);
            int[,] result = new int[length, width];

            for (int y = 0; y < length; y++)
                for (int x = 0; x < width; x++)
                    result[y, x] = combined[y][x];

            return result;
        }
}

