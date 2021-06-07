using BLL.Interfaces;
using Common.DTO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerServices;

        public DeveloperController(IDeveloperService developerServices)
        {
            _developerServices = developerServices;
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
            var popularDevelopers = _developerServices.GerPopularDevelopers(count);
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
                _developerServices.Add(developerDTO);
                return Ok(developerDTO);
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
            var developer = _developerServices.GetById(id);
            if (developer == null)
                throw new ArgumentException($"User with Id = {id} not found");
            _developerServices.Remove(developer);
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
            var developer = _developerServices.GetById(id);
            if (developer == null)
                throw new ArgumentException($"User with Id = {id} not found");
            return Ok(developer);
        }
    }
}
