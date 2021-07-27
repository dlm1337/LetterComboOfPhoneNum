using System;
using System.Collections.Generic; 

namespace LetterComboPhoneNum
{
    class Program
    {

        public static void Main(String[] args)
        {   var r = new Program();
            var list = r.LetterCombinations(number);

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.ReadLine();
        }

        public IList<string> LetterCombinations(string digits)
        {
            int x = 0;
            int[] number = new int[digits.Length];
            if (digits.Length == 0)
            {
                return new List<string>();
            } 
            foreach (var c in digits)
            {
                number[x] = int.Parse(c.ToString());
                x++;
            }
            int n = digits.Length;
            string[] possibleLetterPool  = { "0",   "1",   "abc",  "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            List<string> list = getCombos(number, n, possibleLetterPool); 
            return list;
        }

        static List<string> getCombos(int[] number, int n, string[] possibleLetterPool)
        { 
            List<string> list = new List<string>();
            Queue<string> q = new Queue<string>();
            q.Enqueue("");

            while (q.Count != 0)
            {
                var topOfQueue = q.Dequeue(); 
                if (topOfQueue.Length == n)
                    list.Add(topOfQueue);
                else
                {
                    var val = possibleLetterPool[number[topOfQueue.Length]];
                    for (int i = 0; i < val.Length; i++)
                    {
                        q.Enqueue(topOfQueue + val[i]);
                    }
                }
            }
            return list;
        }
    }
   
    public static class Extensions
    {
        public static T[] Append<T>(this T[] array, int[] number, T item)
        {
            if (array == null)
            {
                return new T[] { item };
            }

            if (number is null)
            {
                throw new ArgumentNullException(nameof(number));
            }

            var result = new T[array.Length + 1];
            array.CopyTo(result, 0);
            result[array.Length] = item;
            return result;
        }
    }
}
