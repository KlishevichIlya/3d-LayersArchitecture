using AutoMapper;
using BLL.Interfaces;
using Common.DTO;
using Common.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(ProjectDTO entityDTO)
        {
            var entity = _mapper.Map<ProjectDTO, Project>(entityDTO);
            _unitOfWork.Projects.Add(entity);
            _unitOfWork.Complete();
        }

        public void AddRange(IEnumerable<ProjectDTO> entitiesDTO)
        {
            var entities = _mapper.Map<IEnumerable<ProjectDTO>, IEnumerable<Project>>(entitiesDTO);
            _unitOfWork.Projects.AddRange(entities);
            _unitOfWork.Complete();
        }

        public IEnumerable<ProjectDTO> Find(Expression<Func<ProjectDTO, bool>> expressionDTO)
        {
            var expression = _mapper.Map<Expression<Func<ProjectDTO, bool>>, Expression<Func<Project, bool>>>(expressionDTO);
            var projects =  _unitOfWork.Projects.Find(expression);
            return _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(projects);
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            var projects = _unitOfWork.Projects.GetAll();
            return _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectDTO>>(projects);
        }

        public ProjectDTO GetById(int id)
        {
            var project = _unitOfWork.Projects.GetById(id);
            return _mapper.Map<Project, ProjectDTO>(project);
        }

        public void Remove(ProjectDTO entityDTO)
        {
            var entity = _mapper.Map<ProjectDTO, Project>(entityDTO);
            _unitOfWork.Projects.Remove(entity);
            _unitOfWork.Complete();
        }

        public void RemoveRange(IEnumerable<ProjectDTO> entitiesDTO)
        {
            var entities = _mapper.Map<IEnumerable<ProjectDTO>, IEnumerable<Project>>(entitiesDTO);
            _unitOfWork.Projects.RemoveRange(entities);
            _unitOfWork.Complete();
        }
    }
}
