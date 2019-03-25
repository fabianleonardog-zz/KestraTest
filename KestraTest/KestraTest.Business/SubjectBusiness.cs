using KestraTest.Contracts;
using KestraTest.Contracts.Business;
using KestraTest.Contracts.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KestraTest.Business
{
    public class SubjectBusiness : ISubjectBusiness
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectBusiness(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public void Create(Subject entity)
        {
            _subjectRepository.Create(entity);
        }

        public void Delete(Subject entity)
        {
            _subjectRepository.Delete(entity);
        }

        public List<Subject> GetAll()
        {
            return _subjectRepository.GetAll();
        }

        public Subject GetByIntId(int id)
        {
            return _subjectRepository.Single(x => x.Id == id);
        }

        public Subject Single(Expression<Func<Subject, bool>> predicate)
        {
            return _subjectRepository.Single(predicate);
        }

        public void Update(Subject entity)
        {
            _subjectRepository.Update(entity);
        }
    }
}
