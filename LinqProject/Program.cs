using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // exercise 1
            Console.WriteLine("Exercise 1");
            int[] values = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var query = values.Where(v => v % 2 == 0)
                        .OrderBy(v => v)
                        .Select(v => v);
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            // exercise 2
            Console.WriteLine("Exercise 2");
            int[] values2 = { 0, 1, 22, 3, 34, -5, 6, 17, -8, 9, 10 };
            var query2 = values2.Where(v => v > 0)
                        .Where(v => v < 12)
                        .OrderBy(v => v)
                        .Select(v => v);
            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }

            // exercise 3
            Console.WriteLine("Exercise 3");
            int[] values3 = { 5, 6, 8, 9};
            var query3 = from nr in values3
                         orderby nr descending
                         select new { Number = nr, SqrNo = nr * nr };

            foreach (var item in query3)
            {
                Console.WriteLine("Number={0}, SqrNo={1}", item.Number, item.SqrNo);
            }

            // exercise 4
            Console.WriteLine("Exercise 4");
            int[] values4 = { 5, 1, 9, 5, 9, 5 };
            var query4 = from nr in values4
                         group nr by nr into occ
                         select occ;

            foreach (var item in query4)
            {
                Console.WriteLine("Number {0}  appears {1} times.", item.Key, item.Count());
            }

            // exercise 5
            Console.WriteLine("Exercise 5");
            string test = "apple";
            var query5 = from c in test
                         group c by c into d
                         select d;

            foreach (var item in query5)
            {
                Console.WriteLine("Character {0}: {1} times.", item.Key, item.Count());
            }

            // exercise 6
            Console.WriteLine("Exercise 6");
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
            List<string> asdasd = new List<string>();
            //TODO: delete this
            var testPag = asdasd.OrderBy(w => w).LastOrDefault(w => w.Contains("e"));
            var query6 = from day in days
                         select day;

            foreach (var item in query6)
            {
                Console.WriteLine(item);
            }

            // exercise 7
            Console.WriteLine("Exercise 7");
            int[] nros = { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };
            var query7 = from nro in nros
                         group nro by nro into occ
                         select occ;

            foreach (var item in query7)
            {
                Console.WriteLine("{0} {1} {2}", item.Key, item.Sum(), item.Count());
            }

            // exercise 8
            //Console.WriteLine("Exercise 8");
            //string[] cities = { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };
            //Console.Write("\nInput starting character for the string : ");
            //string starts = Console.ReadLine();
            //Console.Write("\nInput ending character for the string : ");
            //string ends = Console.ReadLine();
            //var query8 = cities.Where(c => c.StartsWith(starts.ToString()))
            //                    .Where(c => c.EndsWith(ends.ToString()))
            //                    .Select(c => c);
            //foreach (var item in query8)
            //{
            //    Console.WriteLine("The city starting with {0} and ending with {1} is: {2}", starts, ends, item);
            //}

            // exercise 9
            Console.WriteLine("Exercise 9");
            List<int> nros9 = new List<int>(){ 55, 200, 740, 76, 230, 482, 95 };
            //var query9 = nros9.Where(nr => nr > 80).Select(nr => nr);
            var query9 = nros9.FindAll(nro => nro>80 ? true: false);
            foreach (var item in query9)
            {
                Console.WriteLine(item);
            }

            // exercise 10
            //Console.WriteLine("Exercise 10");
            //Console.WriteLine("Input the number of members on the list: ");
            //int arrayCap = int.Parse(Console.ReadLine());
            //int[] nros10 = new int[arrayCap];
            //for (int i = 0; i < arrayCap; i++)
            //{
            //    Console.WriteLine("Member {0}: ", i);
            //    nros10[i] = int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine("Input the value above you want to display the members of the List : ");
            //int valueGreater = int.Parse(Console.ReadLine());
            //var query10 = from v in nros10
            //              where v > valueGreater
            //              select v;
            //Console.WriteLine("The numbers greater than {0} are : ",valueGreater );
            //foreach (var item in query10)
            //{
            //    Console.WriteLine(item);
            //}

            // exercise 11
            //Console.WriteLine("Exercise 11");
            //List<int> nros11 = new List<int>() { 5, 7, 13, 24, 6, 9, 8, 7 };
            //Console.Write("How many records you want to display ?");
            //int limitNrs = int.Parse(Console.ReadLine());
            //var query11 = nros11.OrderByDescending(v => v);
            //Console.WriteLine("The top {0} records from the list are : ", limitNrs);
            //foreach (var item in query11.Take(limitNrs))
            //{
            //    Console.WriteLine(item);
            //}

            // exercise 12
            //Console.WriteLine("Exercise 9");
            //Console.Write("Input the string: ");
            //string line = Console.ReadLine();

            //var query12 = line.Split(' ').Where(li => string.Compare(li, li.ToUpper(), false)==0).Select(li=>li);
            //Console.WriteLine("The UPPER CASE words are:");
            //foreach (var item in query12)
            //{
            //    Console.WriteLine(item);
            //}

            // exercise 13
            //Console.WriteLine("Exercise 13");
            //Console.Write("Input number of strings to store in the array: ");
            //int arrayCap = int.Parse(Console.ReadLine());
            //string[] array13 = new string[arrayCap];
            //for (int i = 0; i < arrayCap; i++)
            //{
            //    Console.WriteLine("Element[{0}]: ", i);
            //    array13[i] = Console.ReadLine();
            //}
            //Console.WriteLine("Here is the string below created with elements of the above array: ");
            //string joinString = string.Join(", ", array13.Select(s => s));
            //Console.WriteLine(joinString);

            // exercise 14
            //Console.WriteLine("Exercise 14");
            //Console.Write("Which maximum grade point(1st, 2nd, 3rd, ...) you want to find: ");
            //int maxGrade = int.Parse(Console.ReadLine());
            //Student s = new Student();
            //var listStudents = s.GetStudents();
            //var best = (from st in listStudents
            //          group st by st.GrdPnt into grades
            //          orderby grades.Key descending
            //          select new { Students = grades.ToList() }).ToList();
            //var accordingClient = best[maxGrade - 1];
            //foreach (Student stdnt in accordingClient.Students)
            //{
            //    Console.WriteLine("Id: {0}, Name: {1}, achieved Grade Point: {2}", stdnt.ID, stdnt.Name, stdnt.GrdPnt);
            //}

            Console.WriteLine("\nExercise 15");
            string[] extensionesArchivos = { "aaa.frx", "bbb.TXT", "xyz.dbf","abc.pdf", "aaaa.PDF", "xyz.frt", "abc.xml", "ccc.txt", "zzz.txt" };
            var query15 = extensionesArchivos
                            .Select(file => Path.GetExtension(file).ToLower())
                            .GroupBy(ext => ext, (extension, total) => new { Extension = extension, Count = total.Count() });
            Console.WriteLine("Here is the group of extension of the files: ");
            foreach (var item in query15)
            {
                Console.WriteLine("{0} File(s) with {1} Extension", item.Count, item.Extension);
            }

            Console.WriteLine("\nExercise 16");
            string[] files = Directory.GetFiles(@"c:\Users\luis.choque\Documents\FilesTest\");
            var query16 = files.Select(file => new FileInfo(file).Length).Average();
            var InMB = Math.Round(query16 / 1000, 1);
            Console.WriteLine("The Average file size is: {0} MB", InMB);

            Console.WriteLine("\nExercise 17");
            List<char> chars = new List<char>(){ 'm', 'n', 'o', 'p', 'q' };
            chars.Remove(chars.FirstOrDefault(ch => ch =='o'));
            foreach (var item in chars)
            {
                Console.WriteLine("Char: {0}", item.ToString());
            }

            List<string> asd = new List<string>(){ "This", "start", "is", "the", "end", "first", "test"};
            foreach (var item in asd.SkipWhile(val => val != "start").TakeWhile(val => val != "end"))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
