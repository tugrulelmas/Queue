using Abioka.Queue.Common.Entities;
using Abioka.Queue.Sender.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Abioka.Queue.Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventQueuesController : ControllerBase
    {
        private readonly IEnumerable<IEventSender> eventSenders;

        public EventQueuesController(IEnumerable<IEventSender> eventSenders) {
            this.eventSenders = eventSenders;
        }

        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<User> users) {
            foreach (var senderItem in eventSenders) {
                senderItem.Send(users);
            }

            return Ok();
        }
    }
}