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
            {
                throw InvalidOperationException;
            }

            // find 20% of students
            int gradeBoundaryNumber = Math.Ceiling(studentCount / 5);

            // sort the grades
            List<Student> sortedList = Students;
            sortedList.Sort();
            List<double> gradeList = new List<double>;
            foreach (Student item in sortedList)
            {
                gradeList.Add(item.AverageGrade);
            }

            // find where averageGrade sits in the list of grades
            if (averageGrade >= gradeList[gradeBoundaryNumber])
                return 'A';
            else if (averageGrade >= gradeList[gradeBoundaryNumber * 2])
                return 'B';
            else if (averageGrade >= gradeList[gradeBoundaryNumber * 3])
                return 'C';
            else if (averageGrade >= gradeList[gradeBoundaryNumber * 4])
                return 'D';
            else
                return 'F';
        }


    }
}
