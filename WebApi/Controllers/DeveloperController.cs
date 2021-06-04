using AutoMapper;
using Common.DTO;
using Common.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {       
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;

        public DeveloperController(IDeveloperRepository developerRepository, IMapper mapper)
        {            
            _developerRepository = developerRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get most popular developer by followers
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("popular")]
        public IActionResult GetPopularDevelopers([FromQuery] int count)
        {
            var popularDevelopers = _developerRepository.GerPopularDevelopers(count);
            return Ok(popularDevelopers);
        }
        
        /// <summary>
        /// Add new developer
        /// </summary>
        /// <param name="developerDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add/developer")]
        public IActionResult AddNewDeveloper(DeveloperDTO developerDTO)
        {
            if (ModelState.IsValid)
            {              
                var developer = _mapper.Map<DeveloperDTO, Developer>(developerDTO);
                _developerRepository.Add(developer);
                return Ok(developer);
            }
            return BadRequest();
        }
        
        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="developerDTO"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/developer")]
        public IActionResult RemoveCurrentDeveloper(int id)
        {           
            var developer = _developerRepository.GetById(id);
            if (developer == null)
                throw new ArgumentException($"User with Id = {id} not found");
            _developerRepository.Remove(developer);
            return Ok();            
        }

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/user/id")]
        public IActionResult GetUserById(int id)
        {
            var developer = _developerRepository.GetById(id);
            if (developer == null)
                throw new ArgumentException($"User with Id = {id} not found");
            return Ok(developer);
        }

    }
}
