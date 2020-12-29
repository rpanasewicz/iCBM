using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iCBM.Application.Commands.ConstructionStages;
using Microsoft.AspNetCore.Mvc;
using Misio.Common.Auth.Attributes;
using Misio.Common.CQRS.Commands.Abstractions;
using Misio.Common.CQRS.Queries.Abstractions;

namespace iCBM.WebApi.Controllers
{
    [JwtAuth]
    [ApiController]
    [Route("[controller]")]
    public class ConstructionStagesController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public ConstructionStagesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew(AddNewConstructionStageCommand cmd)
        {
            var constructionStagesId = await _commandDispatcher.SendAsync(cmd);
            return Created($"constructionStages/{constructionStagesId}", constructionStagesId);
        }
        
        [HttpPut("{constructionStageId}")]
        public async Task<IActionResult> Update(UpdateConstructionStageCommand cmd)
        {
             await _commandDispatcher.SendAsync(cmd);
             return Ok();
        }
    }
}
