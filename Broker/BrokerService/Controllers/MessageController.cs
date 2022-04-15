using BrokerService.Controllers.Base;
using BrokerService.Domain.Interfaces.Services;
using BrokerService.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrokerService.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class MessageController : BrokerController
    {
        private readonly IMessageService _srv;
        public MessageController(IMessageService service) => _srv = service;

        //[AllowAnonymous]
        //[HttpPost()]
        //public IActionResult GetById([FromBody] MessageModel message)
        //{
        //    return ReturnPackage(() =>
        //    {
        //        return _srv.SendMessage(message);
        //    });
        //}

    }
}
