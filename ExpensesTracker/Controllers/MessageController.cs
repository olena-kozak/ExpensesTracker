using ExpensesTracker.BussinessLogic;
using ExpensesTracker.Models;
using ExpensesTracker.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpensesTracker.BussinessLogic.Abstract;

namespace ExpensesTracker.Controllers
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

            MessageResponse messageResponse = _messageParserService.ParseMessageInObject(requestMessage);

            if (messageResponse != null)
            {
                return Ok(messageResponse);
            }
            return Ok();
        }
    }
}
