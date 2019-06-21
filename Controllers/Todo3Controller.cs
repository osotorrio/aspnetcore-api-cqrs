using System;
using System.Collections.Generic;
using CQRS;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_api_cqrs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todo3Controller : ControllerBase
    {
        private readonly IHandlerFactory _handlerFactory;
        public Todo3Controller(IHandlerFactory handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<string> Get(Guid id)
        {
            var handler = _handlerFactory.GetQueryHandler<IEnumerable<string>>(typeof(GetTodoListForUser));
            return handler.Execute(new GetTodoListForUser(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] SaveTodoCommand saveTodoCommand)
        {
            var handler = _handlerFactory.GetCommandHandler<SaveTodoCommand>(typeof(SaveTodoCommand));
            handler.Execute(saveTodoCommand);
        }
    }
}
