using AutoMapper;
using Common.DTO;
using Common.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectController(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Add new project
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/add/project")]
        public IActionResult AddNewProject(ProjectDTO projectDTO)
        {
            if (ModelState.IsValid)
            {
                var project = _mapper.Map<ProjectDTO, Project>(projectDTO);
                _projectRepository.Add(project);
                return Ok(project);
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("/delete/project")]
        public IActionResult DeleteProject(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project == null)
                throw new ArgumentException($"Project with Id = {id} not found");
            _projectRepository.Remove(project);
            return Ok();
        }

        /// <summary>
        /// Get project by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/get/project/{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project == null)
                throw new ArgumentException($"Project with Id = {id} not found");
            return Ok(project);
        }
    }
}
