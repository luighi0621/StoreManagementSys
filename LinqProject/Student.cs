using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int GrdPnt { get; set; }

        public List<Student> GetStudents()
        {
            List<Student> res = new List<Student>();
            res.Add(new Student { ID = 1, Name = " Joseph ", GrdPnt = 800 });
            res.Add(new Student { ID = 2, Name = "Alex", GrdPnt = 458 });
            res.Add(new Student { ID = 3, Name = "Harris", GrdPnt = 900 });
            res.Add(new Student { ID = 4, Name = "Taylor", GrdPnt = 900 });
            res.Add(new Student { ID = 5, Name = "Smith", GrdPnt = 458 });
            res.Add(new Student { ID = 6, Name = "Natasa", GrdPnt = 700 });
            res.Add(new Student { ID = 7, Name = "David", GrdPnt = 750 });
            res.Add(new Student { ID = 8, Name = "Harry", GrdPnt = 700 });
            res.Add(new Student { ID = 9, Name = "Nicolash", GrdPnt = 597 });
            res.Add(new Student { ID = 10, Name = "Jenny", GrdPnt = 750 });
            return res;
        }
    }
}
