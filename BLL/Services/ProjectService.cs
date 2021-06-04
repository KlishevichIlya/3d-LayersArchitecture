using Common.Entities;
using DAL.Repositories;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace BLL.Services
{
    public class ProjectService : IProjectRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Project entity)
        {
            _unitOfWork.Projects.Add(entity);
            _unitOfWork.Complete();
        }

        public void AddRange(IEnumerable<Project> entities)
        {
            _unitOfWork.Projects.AddRange(entities);
            _unitOfWork.Complete();
        }

        public IEnumerable<Project> Find(Expression<Func<Project, bool>> expression) =>
            _unitOfWork.Projects.Find(expression);

        public IEnumerable<Project> GetAll() => _unitOfWork.Projects.GetAll();

        public Project GetById(int id) => _unitOfWork.Projects.GetById(id);

        public void Remove(Project entity)
        {
            _unitOfWork.Projects.Remove(entity);
            _unitOfWork.Complete();
        }

        public void RemoveRange(IEnumerable<Project> entities)
        {
            _unitOfWork.Projects.RemoveRange(entities);
            _unitOfWork.Complete();
        }
    }
}
