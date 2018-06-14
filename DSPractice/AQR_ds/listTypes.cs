using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ds
{
    class listTypes
    {
        public void returnLists()
        {
            ArrayList al = new ArrayList();
            al.Add("sid");
            al.Add(1);
            al.Add(new Emp());

            List<Emp> l = new List<Emp>();
            l.Add(new Emp { Id = 1, Name = "sidd" });
            l.Add(new Emp { Id = 2, Name = "sidd" });
            
            l = l.Distinct().ToList();

            var d = new Dictionary<int, Emp>();
            d.Add(1, new Emp { Id = 1, Name = "sid" });
            d.Add(2, new Emp { Id = 2, Name = "gupta" });

            var h = new HashSet<Emp>();
            h.Add(new Emp { Id = 2 });
            h.Add(new Emp { Id = 2 });
            h.Remove(new Emp { Id = 2 });

            foreach (var item in h)
                Console.WriteLine(item.Id);

        }
    }
}
