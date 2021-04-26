using DiabloII_Cookbook.Api.DataTransferObjects;
using DiabloII_Cookbook.Api.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Netension.Request.Abstraction.Senders;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DiabloII_Cookbook.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "battle-tag")]
    public class RuneController : ControllerBase
    {
        private readonly IQuerySender _querySender;

        public RuneController(IQuerySender querySender)
        {
            _querySender = querySender;
        }

        [HttpGet]
        public async Task<IEnumerable<Rune>> GetAsync(CancellationToken cancellationToken)
        {
            return await _querySender.QueryAsync(new GetRunesQuery(), cancellationToken);
        }
    }
}
