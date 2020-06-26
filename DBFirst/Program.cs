using DBFirst.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new PlutoDBContext();

            dbContext.GetAuthorCourses(1);

            var courses = dbContext.GetCourses();

            foreach (var course in courses)
            {
                Console.WriteLine(course.Title);
            }
        }
    }
}
