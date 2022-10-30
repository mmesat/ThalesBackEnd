using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThalesBack.DTOs;
using ThalesBack.Services;

namespace ThalesBack.Controllers
{
    [Route("/employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;
        private readonly IMapper mapper;
        private readonly ILogger<EmployeeController> logger;

        public EmployeeController (IEmployeeService service, IMapper mapper, ILogger<EmployeeController> logger)
        {
            _service = service;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeDTO>>> Getalll()
        {
            try
            {
                var result = await _service.GetAll();
                var dto = mapper.Map<List<EmployeeDTO>>(result);
                return dto;
            }
            catch(Exception ex)
            {
                logger.LogError("Error",ex);
                return NoContent();
            }
        }

        [HttpGet("/{id:int}")]
        public async Task<ActionResult<List<EmployeeDTO>>> GetEmployee(int id)
        {
            try
            {
                var result = await _service.GetEmployee(id);
                var dto = mapper.Map<List<EmployeeDTO>>(result);
                return dto;
            }
            catch (Exception ex)
            {
                logger.LogError("Error", ex);
                return NoContent();
            }
        }
    }
}
