using System;
using System.Collections.Generic;
using CQRS;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_api_cqrs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todo2Controller : ControllerBase
    {
        private readonly IProcessor _processor;
        public Todo2Controller(IProcessor processor)
        {
            _processor = processor;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<string> Get(Guid id)
        {
            return _processor.Process(new GetTodoListForUser(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] SaveTodoCommand saveTodoCommand)
        {
            _processor.Process(saveTodoCommand);
        }
    }
}
