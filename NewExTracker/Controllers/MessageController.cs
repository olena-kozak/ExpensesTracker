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
    public class MessageController : ControllerBase
    {
        private IMessageParserService _messageParserService; 

        public MessageController(IMessageParserService messageParserService)
        {
            _messageParserService = messageParserService;
           
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] ParseMessageRequest requestMessage)
        {
            if (requestMessage == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MessageResponse responseMessage = _messageParserService.ParseMessageInObject(requestMessage);

            return Ok(responseMessage);
        }


    }
}
