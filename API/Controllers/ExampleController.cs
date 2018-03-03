using System;
using System.Collections.Generic;
using System.Linq;
using API.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Service.Entities;
using Service.UnitOfWork.Abstract;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ExampleController : Controller
    { 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExampleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }    
        /// <summary>
        /// Obtain Example entity by its id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Example entity found and returned</response>
        /// <response code="204">No entity was found</response>       
        [HttpGet]
        [Route("{id}")]
        public IActionResult ObtainById(int id)
        {
            try
            {
                ExampleEntity entity = _unitOfWork.ExampleRepo.GetById(id);
                if(entity == null)
                    return NoContent();
                
                ExampleEntityDTO dto = _mapper.Map<ExampleEntity, ExampleEntityDTO>(entity);
                return Ok(dto);
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
                var result = _unitOfWork.ExampleRepo.GetAll();
                if(!result.Any())
                    return NoContent();

                var dtos = result.ProjectTo<ExampleEntityDTO>();
                return Ok(dtos);
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
                var result = _unitOfWork.ExampleRepo.Insert(entity);
                return CreatedAtRoute("", new {id = entity.ID },result);
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception);
            }
        }
    }
}