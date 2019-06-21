using System;

namespace CQRS
{
    public class SaveTodoCommand : ICommand
    {
        public Guid UserId { get; set; }
        public string Todo { get; set; }
        public DateTime DateLog { get; set; }
    }   
}