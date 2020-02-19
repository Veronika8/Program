using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        protected static bool Order(string s1, string s2)
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            string text = "the quick brown fox jumps over the lazy dog";
            string spl = " ";
            Regex regSpl = new Regex(spl);
            string[] words = regSpl.Split(text);
            Console.WriteLine("Уровень 1");
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }

            Console.WriteLine(" \n");

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length - 1; j++)
                {
                    if (Order(words[j], words[j + 1]))
                    {
                        string s = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = s;
                    }
                }
            }
            Console.WriteLine("Уровень 2");
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
            Console.WriteLine(" \n");

            Console.WriteLine("Уровень 3");
            Console.WriteLine(words[0]);
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i] != words[i - 1])
                {
                    Console.WriteLine(words[i]);
                }
            }
            Console.WriteLine(" \n");

            Console.WriteLine("Уровень 4");
            int[] count = new int[words.Length];
            for (int i = 0; i < words.Length; i++)
            {
                count[i] = 0;
                foreach (string word in words)
                {
                    if (word.Equals(words[i], StringComparison.CurrentCultureIgnoreCase))
                    {
                        count[i]++;
                    }
                }
            }
            Console.WriteLine(words[0] + " " + count[0]);
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i] != words[i - 1])
                {
                    Console.WriteLine(words[i] + " " + count[i]);
                }
            }

            Console.ReadKey();
        }
    }
}
