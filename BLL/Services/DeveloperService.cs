using AutoMapper;
using BLL.Interfaces;
using Common.DTO;
using Common.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

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
            var developers = _mapper.Map<DeveloperDTO, Developer>(developersDTO);
            _unitOfWork.Developers.AddRange(developers);
            _unitOfWork.Complete();
        }

        public void RemoveRange(IEnumerable<DeveloperDTO> developers)
        {
            _unitOfWork.Developers.RemoveRange(developers);
            _unitOfWork.Complete();
        }

        public DeveloperDTO GetById(int id)
        {
            var developer =  _unitOfWork.Developers.GetById(id);
            return _mapper.Map<Developer, DeveloperDTO>(developer);            
        }

        public IEnumerable<DeveloperDTO> GetAll()
        {
            var developers = _unitOfWork.Developers.GetAll();
            return _mapper.Map<Developer, DeveloperDTO>(developers);
        }

        public IEnumerable<DeveloperDTO> Find(Expression<Func<DeveloperDTO, bool>> expression)
        {
            return _unitOfWork.Developers.Find(expression);
        }

        public IEnumerable<DeveloperDTO> GerPopularDevelopers(int count)
        {
            return _unitOfWork.Developers.GerPopularDevelopers(count);
        }
    }
}
