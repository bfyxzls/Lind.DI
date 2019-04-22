using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lind.DI.Api.Filters
{
	public class DIFilter : ActionFilterAttribute
	{
        public override void OnActionExecuting(ActionExecutingContext context)
		{
			Lind.DI.DIFactory.InjectFromObject(context.Controller);
		}
	}
}
