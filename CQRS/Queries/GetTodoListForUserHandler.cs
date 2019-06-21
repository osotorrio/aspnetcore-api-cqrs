using System.Collections.Generic;

namespace CQRS
{
    public class GetTodoListForUserHandler : IQueryHandler<GetTodoListForUser, IEnumerable<string>>
    {
        public IEnumerable<string> Execute(GetTodoListForUser query)
        {
            return new []{"Leave my current job", "Find new plan of life"};
        }
    }
}