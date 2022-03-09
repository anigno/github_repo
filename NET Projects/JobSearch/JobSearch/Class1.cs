using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JobSearch
{
    class Class1
    {
        
        void ThreadStart()
        {
            Console.WriteLine("hello");
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        public static void Test()
        {
            Hashtable h = new Hashtable
            {
                { 1, new List<int>() }
            };
            List<int> q = h[1] as List<int>;
            q.Add(3);
            q.Add(1);

            Class1 c1 = new Class1();
            Thread t = new Thread(c1.ThreadStart);
            t.Start();


        }
    }
}