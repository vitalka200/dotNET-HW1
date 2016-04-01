// Name: Vitali Karabitski, ID: 317721652
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW1_VitaliKarabitski
{
    internal class Course
    {
        internal string Name { get; set; }
        internal Student Stud { get; set; }

        public override string ToString()
        {
            return string.Format("{0, -8} {1, -12} {2}", Name, Stud.Name, string.Concat(Stud.List.Select(g => string.Format("{0, 3} ", g))));
        }

        internal string this[int index]
        {
            get
            {
                try
                {
                    return Stud[index].ToString();
                }
                catch (ArgumentOutOfRangeException)
                {
                    return "";
                }
            }
        }

        internal class Student
        {
            internal string Name { get; set; }
            internal List<int> List { get; set; }

            internal int this[int index]
            {
                get { return List[index]; }
                set { List[index] = value; }
            }

            public override string ToString()
            {
                return string.Format("{0, 3} {2}", Name, string.Join(" ", List));
            }
        }
    }

    internal static class ShowGradeExtension
    {

        internal static string ShowGrade(this Course c, int index)
        {
            return c[index];
        }
    }
}
