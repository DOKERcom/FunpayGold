using AutoMapper;
using FunpayGold.Application.Queries.BotSettingsController;
using FunpayGold.Application.Commands.BotSettingsController;
using FunpayGold.Common.ResultModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FunpayGold.Common.QueryModels;

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

        [HttpPost]
        [Route("RegisterWorker")]
        public async Task<JsonResult> RegisterWorker(string workerId)
        {

            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new RegisterWorkerCommand(workerId));

                return Json(result);
            }

            return Json(new ResultActionModel(400));

        }

        [HttpGet]
        [Route("GetNewBot")]
        public async Task<JsonResult> GetNewBot(string workerId)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new GetNewBotCommand(workerId));

                return Json(result);  
            }

            return Json(new ResultActionModel(400));
        }

        [HttpGet]
        [Route("GetAllMyBots")]
        public async Task<JsonResult> GetAllMyBots(string workerId)
        {

            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new GetAllMyBotsQuery(workerId));

                return Json(result);
            }

            return Json(new ResultActionModel(400));

        }

        [HttpPost]
        [Route("AddActivityToBot")]
        public async Task<JsonResult> AddActivityToBot(BotActivityQueryModel activityQuery)
        {

            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new AddActivityToBotCommand(activityQuery));

                return Json(result);
            }

            return Json(new ResultActionModel(400));

        }

    }
}
