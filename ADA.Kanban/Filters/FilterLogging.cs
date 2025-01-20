using Microsoft.AspNetCore.Mvc.Filters;

namespace ADA.Kanban.Filters
{
    public class FilterLogging : Attribute, IActionFilter
    {
        private readonly string _action;

        public FilterLogging(string action)
        {
            _action = action;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var parameter in context.ActionArguments)
            {
                if (parameter.Key == "id")
                    Console.WriteLine($"{DateTime.Now} - Card {parameter.Value} - {_action}");
            }
        }
    }
}
