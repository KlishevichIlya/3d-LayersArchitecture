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
    public class DeveloperService : IDeveloperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeveloperService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DeveloperDTO developerDTO)
        {
            var developer = _mapper.Map<DeveloperDTO, Developer>(developerDTO);
            _unitOfWork.Developers.Add(developer);
            _unitOfWork.Complete();
        }

        public void Remove(DeveloperDTO developerDTO)
        {
            var developer = _mapper.Map<DeveloperDTO, Developer>(developerDTO);
            _unitOfWork.Developers.Remove(developer);
            _unitOfWork.Complete();
        }

        public void AddRange(IEnumerable<DeveloperDTO> developersDTO)
        {
            var developers = _mapper.Map<IEnumerable<DeveloperDTO>, IEnumerable<Developer>>(developersDTO);
            _unitOfWork.Developers.AddRange(developers);
            _unitOfWork.Complete();
        }

        public void RemoveRange(IEnumerable<DeveloperDTO> developersDTO)
        {
            var developers = _mapper.Map<IEnumerable<DeveloperDTO>, IEnumerable<Developer>>(developersDTO);
            _unitOfWork.Developers.RemoveRange(developers);
            _unitOfWork.Complete();
        }

        public DeveloperDTO GetById(int id)
        {
            var developer = _unitOfWork.Developers.GetById(id);
            return _mapper.Map<Developer, DeveloperDTO>(developer);
        }

        public IEnumerable<DeveloperDTO> GetAll()
        {
            var developers = _unitOfWork.Developers.GetAll();
            return _mapper.Map<IEnumerable<Developer>, IEnumerable<DeveloperDTO>>(developers);
        }

        public IEnumerable<DeveloperDTO> Find(Expression<Func<DeveloperDTO, bool>> expressionDTO)
        {
            var expression = _mapper.Map<Expression<Func<DeveloperDTO, bool>>, Expression<Func<Developer, bool>>>(expressionDTO);
            var developers = _unitOfWork.Developers.Find(expression);
            return _mapper.Map<IEnumerable<Developer>, IEnumerable<DeveloperDTO>>(developers);
        }

        public IEnumerable<DeveloperDTO> GerPopularDevelopers(int count)
        {
            var developers = _unitOfWork.Developers.GerPopularDevelopers(count);
            return _mapper.Map<IEnumerable<Developer>, IEnumerable<DeveloperDTO>>(developers);
        }
    }
}
