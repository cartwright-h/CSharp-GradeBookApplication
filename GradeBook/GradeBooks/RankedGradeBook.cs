using System;
using System.Collections.Generic;
using System.Text;

using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int studentCount = Students.Count;
            if (studentCount < 5)
                throw new InvalidOperationException();

            // find 20% of students
            int threshold = (int)Math.Ceiling(studentCount * 0.2);

            // sort the grades
            List<Student> sortedList = Students;
            sortedList.Sort();
            List<double> gradeList = new List<double>();
            foreach (Student item in sortedList)
            {
                gradeList.Add(item.AverageGrade);
            }
            gradeList.Reverse();

            // find where averageGrade sits in the list of grades
            if (averageGrade >= gradeList[threshold - 1])
                return 'A';
            else if (averageGrade >= gradeList[(threshold * 2) - 1])
                return 'B';
            else if (averageGrade >= gradeList[(threshold * 3) - 1])
                return 'C';
            else if (averageGrade >= gradeList[(threshold * 4) - 1])
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStudentStatistics(name);
        }


    }
}
