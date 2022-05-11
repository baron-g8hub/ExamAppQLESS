using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<int> anArray = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int ctr = 0; ctr < anArray.Count - 1; ctr++)
            {
                var entity = anArray[ctr];
                if (entity % 2 == 1)
                {
                    anArray.Remove(ctr);    

                }

            }

        }
    }
}
