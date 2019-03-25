using System;
using System.Collections.Generic;
using System.Text;

namespace KestraTest.Contracts.Business
{
    public interface IStudentGradeBusiness : IBaseBusiness<StudentGrade>
    {
        List<StudentGrade> GetStudentReportData();
    }
}
