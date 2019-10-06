using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatInc.Domain;
using ChatInc.Models;
using ChatInc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatInc.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMessagesService messagesService;


        public MessagesController(IMessagesService messagesService)
        {
            this.messagesService = messagesService;
        }



        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Message>> GetAllByCreationTime()
        {
            return messagesService.GetMessages();
        }
  
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(MessageCreationBindingModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await messagesService.CreateMessageAsync(model.Content, model.User);

            return Ok();
        }

    }
}
