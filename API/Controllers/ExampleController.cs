using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Service.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ExampleController : Controller
    { 
        private readonly ExampleDbContext _context;
        private readonly IExampleRepository _repository;

        public ExampleController(ExampleDbContext context, IExampleRepository repository)
        {
            _context = context;
            _repository = repository;
        }    

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtainById(int id)
        {
            try
            {
                ExampleEntity entity = _repository.GetById(id);
                if(entity == null)
                    return NoContent();
                
                return Ok(entity);
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception);
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult ObtainExampleEntities()
        {
            try
            {
                var result = _repository.GetAll();
                if(!result.Any())
                    return NoContent();

                return Ok(result.ToList());
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception);
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult InsertExampleEntity([FromBody]ExampleEntity entity)
        {
            try
            {
                var result = _repository.Insert(entity);
                return CreatedAtRoute("", new {id = entity.ID },result);
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception);
            }
        }
    }
}