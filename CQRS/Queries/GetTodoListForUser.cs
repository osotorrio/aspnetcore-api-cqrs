using System;
using System.Collections.Generic;

namespace CQRS
{
    public class GetTodoListForUser : IQuery<IEnumerable<string>>
    {
        public GetTodoListForUser(Guid id) => UserId = id;

        public Guid UserId { get; private set; }
    }
}