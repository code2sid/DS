using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ds
{
    public class syncAwait
    {
        public static async void callMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = Method1().Result;
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    count += 1;
                }
            });//.ConfigureAwait(false);
            return count;
        }


        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" Method 2");
            }
        }


        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }  
    }
}
