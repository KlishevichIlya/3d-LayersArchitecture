using AutoMapper;
using Common.Entities;
using DAL.Repositories;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace BLL.Services
{
    public class DeveloperService : IDeveloperRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeveloperService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Developer developer)
        {            
            _unitOfWork.Developers.Add(developer);
            _unitOfWork.Complete();            
        }

        public void Remove(Developer developer)
        {
            _unitOfWork.Developers.Remove(developer);
            _unitOfWork.Complete();
        }

        public void AddRange(IEnumerable<Developer> developers)
        {
            _unitOfWork.Developers.AddRange(developers);
            _unitOfWork.Complete();
        }

        public void RemoveRange(IEnumerable<Developer> developers)
        {
            _unitOfWork.Developers.RemoveRange(developers);
            _unitOfWork.Complete();
        }

        public Developer GetById(int id) => _unitOfWork.Developers.GetById(id);

        public IEnumerable<Developer> GetAll() => _unitOfWork.Developers.GetAll();

        public IEnumerable<Developer> Find(Expression<Func<Developer, bool>> expression) => _unitOfWork.Developers.Find(expression);

        public IEnumerable<Developer> GerPopularDevelopers(int count) => _unitOfWork.Developers.GerPopularDevelopers(count);

       
    }
}
