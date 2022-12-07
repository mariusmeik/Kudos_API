using AutoMapper;
using KudosAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using Core.Contracts;
using Core.Entities;

namespace KudosAPI.Controllers
{
    [ApiController]
    [Route("KudosAPI/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EmployeeEntity))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEmploye(CreateEmployeeDTO employe)
        {
            EmployeeEntity employeEntity = _mapper.Map<EmployeeEntity>(employe);
            int id = await _service.Create(employeEntity);
            employeEntity.Id= id;
            return new ObjectResult(employeEntity) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReturnEmployeDTO>))]
        public async Task<IActionResult> GetEmployes()
        {
            var employeEntities = await _service.Get();
            List<ReturnEmployeDTO> employeeDTOs =_mapper.Map<List<EmployeeEntity>, List<ReturnEmployeDTO>>(employeEntities);

            return Ok(employeeDTOs);
        }
    }
}
