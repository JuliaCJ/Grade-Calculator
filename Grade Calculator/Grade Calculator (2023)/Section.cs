using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalculator
{
    public class Section 
    {
        private string secName;
        private double percent;
        private int dropped;
        private List<string> grades;

      private double average;
       private  List<Double> percentGrades;

        public double getPercent()
        {
            return this.percent;
        }

        public double getAverage()
        {
            return this.average;
        }
        public Section(string secName, double percent, int dropped, List<string> grades) 
        {
            this.secName = secName; //Name of the section
            this.percent = percent; //Percent of worth, taken as decimal
            this.dropped = dropped; //How many grades are dropped
            this.grades = grades; //initial read-in grades
            percentGrades = new List<Double>(); //Converted grades to percent
            calculateEarnedGrades(); //Calculates the earned grades
            calculateAverage(); //Finds the section average
        }

        public void calculateEarnedGrades()
        {
            foreach (string grade in grades)
            {
                string[] split = grade.Split('/');
                double earned = Double.Parse(split[0]);
                double total = Double.Parse(split[1]);

                double percentEarned = (earned / total) * 100;
                percentGrades.Add(percentEarned);

            }

            percentGrades.Sort();

            for (int i = 0; i < dropped; i++)
            {
                percentGrades.Remove(i);
            }

        }

        public void calculateAverage()
        {
            foreach (Double grade in percentGrades)
            {
                average += grade;
            }

            average /= percentGrades.Count;
        }

        public override string ToString()
        {
            return secName + "(" + percent*100 + "): " + average; 
        }
    }
}
