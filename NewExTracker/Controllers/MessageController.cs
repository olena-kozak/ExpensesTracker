using NewExTracker.BussinessLogic;
using NewExTracker.Models;
using NewExTracker.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewExTracker.BussinessLogic.Abstract;

namespace NewExTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase                                 // TODO: create controller for every type of information
    {                                                                                               //перенос замінити на space
        private IMessageParserService _messageParserService;

        public MessageController(IMessageParserService messageParserService)
        {
            _messageParserService = messageParserService;

        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] MessageRequest requestMessage)
        {
            if (requestMessage == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            object responseMessage = _messageParserService.ParseMessageInObject(requestMessage);

            if (responseMessage != null)
            {
                return Ok(responseMessage);
            }
            return Ok();
        }
    }
}
