using AutoMapper;
using Core.Contracts;
using Core.Entities;
using KudosAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace KudosAPI.Controllers
{
    [ApiController]
    [Route("KudosAPI/[controller]")]
    public class KudosController : ControllerBase
    {
        private readonly IKudosService _service;
        private readonly IMapper _mapper;

        public KudosController(IKudosService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(KudosEntity))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateKudosDTO kudos)
        {
            KudosEntity kudosEntity = _mapper.Map<KudosEntity>(kudos);
            int id = await _service.Create(kudosEntity);
            kudosEntity.Id = id;
            return new ObjectResult(kudosEntity) { StatusCode = StatusCodes.Status201Created };

        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<KudosEntity>))]
        public async Task<IActionResult> Get([FromQuery] KudosQueryParameters parameters)
        {
            var KudosEntities = await _service.Get(parameters);
            List<ReturnKudosDTO> kudosDTOs = _mapper.Map<List<KudosEntity>, List<ReturnKudosDTO>>(KudosEntities);

            return Ok(kudosDTOs);

        }

        [HttpPut]
        [Route("{Id}/Exchange_operation")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(KudosEntity))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Exchange(int Id)
        {
            var KudosEntities = await _service.Exchange(Id);
            ReturnKudosDTO kudosDTOs = _mapper.Map<KudosEntity, ReturnKudosDTO>(KudosEntities);

            return Ok(kudosDTOs);

        }
    }
}