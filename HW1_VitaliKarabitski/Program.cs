// Name: Vitali Karabitski, ID: 317721652
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW1_VitaliKarabitski
{
    class HW1
    {
        static void Main(string[] args)
        {
            List<Course> list = new List<Course>
            {
                new Course {Name = "C#", Stud = new Course.Student { Name = "Jojo" , List = new List<int> { 10, 20, 100 }}},
                new Course {Name = "C", Stud = new Course.Student { Name = "Bambi" , List = new List<int> { 99 }}},
                new Course {Name = "Java", Stud = new Course.Student { Name = "Bambi" , List = new List<int> { }}},
                new Course {Name = "C#", Stud = new Course.Student { Name = "Jojo" , List = new List<int> { 10, 20, 30, 40 }}},
                new Course {Name = "Java", Stud = new Course.Student { Name = "Lady Gaga" , List = new List<int> { 100, 99, 1, 100, 100 }}},
                new Course {Name = "Java", Stud = new Course.Student { Name = "Tami" , List = new List<int> { 60, 70, 80, 1 }}},
                new Course {Name = "SQL", Stud = new Course.Student { Name = "Lady Gaga" , List = new List<int> { 50 }}}
            };

            Console.WriteLine("List of courses:\n");
            Console.WriteLine(string.Join("\n", list));
            Console.WriteLine("\n\nPress P / p : Those who passed in acerage and those who did not:");
            Console.WriteLine("Press # : C# courses, and other courses:");
            Console.WriteLine("Any other key: Courses with student who have at least one grade of 100, and all the other courses:");
            
            string answer = Console.ReadLine();

            Console.WriteLine("\n\nQ1 Results:\n");
            switch (answer)
            {
                case "P" : case "p" :
                    PrintQ1(Q1(list, c => c.Stud.List.DefaultIfEmpty(0).Average() >= 60));
                    break;
                case "#":
                    PrintQ1(Q1(list, c => c.Name.Equals("C#")).Reverse());
                    break;
                default:
                    PrintQ1(Q1(list, c => c.Stud.List.Contains(100)).Reverse());
                    break;
            }

            Console.WriteLine("list[1].ShowGrade(0):");
            Console.WriteLine(list[1].ShowGrade(0));
            Console.WriteLine("\nlist[2].ShowGrade(3):");
            Console.WriteLine(list[2].ShowGrade(3));

            var q2 = Q2(list);
            PrintEnumerable(q2);
        }

        public static IEnumerable<IGrouping<TKey, T>> Q1<TKey, T>(List<T> list, Func<T, TKey> groupClause)
            where T : Course
        {
            return (IEnumerable<IGrouping<TKey, T>>)list.GroupBy(groupClause);
        }

        public static void PrintQ1<TKey,T>(IEnumerable<IGrouping<TKey,T>> list)
            where T : Course
        {
            foreach (var g in list)
            {
                Console.WriteLine(g.Key);
                Console.WriteLine("------------");
                PrintEnumerable(g.AsEnumerable());
                Console.WriteLine();
            }
        }

        public static void PrintEnumerable<T>(IEnumerable<T> list)
        {
            Console.WriteLine(string.Join("\n", list));
        }

        public static IEnumerable<dynamic> Q2<T>(IEnumerable<T> list) where T : Course
        {
            var x =
                from c in list
                where c.Stud.List.Where(i => i >= 60).DefaultIfEmpty(0).Average() > 90
                select new { Name = c.Stud.Name, List = string.Join(" ", c.Stud.List)};
            return (IEnumerable<dynamic>)x;
        }
    }
}
