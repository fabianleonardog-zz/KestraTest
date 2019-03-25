using KestraTest.Contracts;
using KestraTest.Contracts.DataAccess;
using KestraTest.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KestraTest.DataAccess.Repository
{
    public class StudentGradeRepository : BaseRepository<StudentGrade>, IStudentGradeRepository
    {
        public StudentGradeRepository(KestraStudentContext context)
        {
            base.context = context;
        }
        public List<StudentGrade> GetStudentReportData()
        {
            return context.StudentGrade.Include(x => x.Student).Include(x => x.Subject).DefaultIfEmpty().ToList();
        }
    }
}
