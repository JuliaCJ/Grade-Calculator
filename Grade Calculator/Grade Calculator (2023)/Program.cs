using System;
using System.IO;
using IronXL;
using System.Linq;

namespace GradeCalculator
{
    using System;
    using System.IO;
    using static System.Collections.Specialized.BitVector32;

    public class GradeCalculator
    {
        public static void Main (String[] args)
        {
            Console.WriteLine("Enter your Workbook's Location:");
            string fileName = Console.ReadLine();
            WorkBook gradeSheet = WorkBook.Load(fileName);
            WorkSheet grades = gradeSheet.WorkSheets.First();

            List<Class> allClasses = new List<Class>();

            char Row = 'A';
            int Col = 2;
            int secCount = 0;
            string[] split;
            string secName = "";
            double percent = 0;
            int dropped = 0;

            foreach (var rows in grades) //for every row
            {
                if (rows.Text == "") //Check if Empty
                {
                    break;
                }
                secCount = 0;
                string name = rows.Text;
                Col = 2;
                List<Section> allSections = new List<Section>();
                List<string> gradeFractions = new List<string>();
                string IndexRange = Row.ToString() + Col.ToString() + ":" + Row.ToString() + 50;
                foreach (var cell in grades[IndexRange]) //For every column
                {
                    if (cell.Text == "") //Check if Empty
                    {
                        Row++;
                        break;
                    }

                    else if (cell.Text[0] > 64) 
                    {
                        if (secCount > 0)
                        {
                            Section thisSection = new Section(secName, percent, dropped, gradeFractions);
                            allSections.Add(thisSection);
                            gradeFractions.Clear();
                        }
                       
                        split = cell.Text.Split('/');
                        
                        secName = split[0];
                        percent = Double.Parse(split[1]) / 100;
                        dropped = Convert.ToInt32((split[2]));


                        secCount++;

                    } else
                    {
                        gradeFractions.Add(cell.Text);
                    }

                }

                Section lastSection = new Section(secName, percent, dropped, gradeFractions);
                allSections.Add(lastSection);
                gradeFractions.Clear();

                allClasses.Add(new Class(name, allSections));

            }

            foreach (Class c in allClasses)
            {
                c.printGrades();
                Console.WriteLine();
            }


          
            
        }
    }
}
