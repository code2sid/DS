using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DSPractice
{
    public class parentClass
    {
        public parentClass()
        {
            Console.WriteLine("parentclass");
        }

        public virtual void m1()
        {
            Console.WriteLine("parent class M1");
        }

        public void m3()
        {
            Console.WriteLine("parent class M1");
        }
    }

    public class childClass : parentClass
    {
        public childClass()
        {
            Console.Write("childclass");
        }

        public void m1()
        {
            Console.WriteLine("child class m1");
        }

        public void m2()
        {

        }
    }

    public class handleClass
    {
        parentClass p = new childClass();
        public void main()
        {
            p.m1();
        }

    }

}
