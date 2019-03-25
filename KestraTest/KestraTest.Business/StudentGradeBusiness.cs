using KestraTest.Contracts;
using KestraTest.Contracts.Business;
using KestraTest.Contracts.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KestraTest.Business
{
    public class StudentGradeBusiness : IStudentGradeBusiness
    {
        private readonly IStudentGradeRepository _studentGradeRepository;
        public StudentGradeBusiness(IStudentGradeRepository studentGradeRepository)
        {
            _studentGradeRepository = studentGradeRepository;
        }
        public void Create(StudentGrade entity)
        {
            _studentGradeRepository.Create(entity);
        }

        public void Delete(StudentGrade entity)
        {
            _studentGradeRepository.Delete(entity);
        }

        public List<StudentGrade> GetAll()
        {
            return _studentGradeRepository.GetAll();
        }

        public StudentGrade GetByIntId(int id)
        {
            return _studentGradeRepository.Single(x => x.Id == id);
        }

        public List<StudentGrade> GetStudentReportData()
        {
            return _studentGradeRepository.GetStudentReportData();
        }

        public StudentGrade Single(Expression<Func<StudentGrade, bool>> predicate)
        {
            return _studentGradeRepository.Single(predicate);
        }

        public void Update(StudentGrade entity)
        {
            _studentGradeRepository.Update(entity);
        }
    }
}
