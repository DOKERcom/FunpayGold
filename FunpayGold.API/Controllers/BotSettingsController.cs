using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FunpayGold.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotSettingsController : Controller
    {

        private readonly IMediator _mediator;

        private IMapper _mapper;

        public BotSettingsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;

            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetNewBot")]
        public async Task<JsonResult> GetNewBot()
        {

            return null;

        }

        [HttpGet]
        [Route("GetAllMyBots")]
        public async Task<JsonResult> GetAllMyBots()
        {

            return null;

        }

        [HttpPost]
        [Route("AddActivityToBot")]
        public async Task<JsonResult> AddActivityToBot()
        {

            return null;

        }

    }
}
