using BLL.Interfaces;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
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
                _projectService.Add(projectDTO);
                return Ok(projectDTO);
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
            var project = _projectService.GetById(id);
            if (project == null)
                throw new ArgumentException($"Project with Id = {id} not found");
            _projectService.Remove(project);
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
            var project = _projectService.GetById(id);
            if (project == null)
                throw new ArgumentException($"Project with Id = {id} not found");
            return Ok(project);
        }
    }
}
