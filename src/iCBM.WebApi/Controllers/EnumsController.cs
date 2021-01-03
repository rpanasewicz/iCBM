using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using iCBM.Application.Dtos;
using iCBM.Domain.Enums;
using Misio.Domain.Types;

namespace iCBM.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnumsController : ControllerBase
    {
        private readonly IMapper _mapper;

        public EnumsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("colors")]
        public IActionResult GetColors()
        {
            return Ok(_mapper.Map<ColorDto>(Enumeration.GetAll<Color>()));
        }
    }
}
