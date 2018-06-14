using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds
{
    public class RefOut
    {
        void changeEmp(Emp e)
        {
            e.Name = "changeName";
        }

        public void PrintEmp()
        {
            Emp e = new Emp { Name = "sidd" };
            changeEmp(e);
            Console.WriteLine(e.Name);
        }
    }

    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
