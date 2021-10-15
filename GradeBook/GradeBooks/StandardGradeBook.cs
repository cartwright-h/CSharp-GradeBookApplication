using System;
using System.Collections.Generic;
using System.Text;

using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    class StandardGradeBook : BaseGradeBook
    {
        private StandardGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Standard;
        }

    }
}
