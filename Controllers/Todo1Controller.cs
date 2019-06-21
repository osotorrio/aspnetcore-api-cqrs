using System;
using System.Collections.Generic;
using CQRS;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_api_cqrs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Todo1Controller : ControllerBase
    {
        private readonly IQueryHandler<GetTodoListForUser, IEnumerable<string>> _query;
        private readonly ICommandHandler<SaveTodoCommand> _command;

        public Todo1Controller(IQueryHandler<GetTodoListForUser, IEnumerable<string>> query, ICommandHandler<SaveTodoCommand> command)
        {
            _query = query;
            _command = command;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<string> Get(Guid id)
        {
            return _query.Execute(new GetTodoListForUser(id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] SaveTodoCommand saveTodoCommand)
        {
            _command.Execute(saveTodoCommand);
        }
    }
}
