﻿using System.Collections.Generic;
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
            return Ok(_mapper.Map<IEnumerable<ColorDto>>(Enumeration.GetAll<Color>()));
        }

        [HttpGet("currencies")]
        public IActionResult GetCurrencies()
        {
            return Ok(_mapper.Map<IEnumerable<CurrencyDto>>(Enumeration.GetAll<Currency>()));
        }
    }
}
