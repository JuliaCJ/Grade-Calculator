using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalculator
{
    public class Class
    {
        string name;
        List<Section> sections;
        double classGrade;

        public Class(string name, List<Section> sections) {
            this.name = name;
            this.sections = sections;
            findGrade();
        } 



        public void findGrade()
        {
            double totalPercent = 0;
            foreach (Section s in sections)
            {
                totalPercent += s.getPercent();
                classGrade += s.getPercent() * s.getAverage();
            }

            classGrade /= totalPercent;

        }

        public void printGrades()
        {
            Console.WriteLine(name);
            foreach (Section s in sections)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine("Final Grade: " + classGrade);
        }
    }
}
