using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebTools.Routing
{
    public class WebRoute<TController>
        where TController : Controller
    {
        public WebRoute(Expression<Action<TController>> action)
        {
            Route = new RouteValueDictionary();

            var controllerTypeName = typeof(TController).Name;
            Controller = controllerTypeName.Replace(Constants.Conventions.Controller, String.Empty);
            Route.Add(Constants.Conventions.Controller, Controller);

            var actionBody = action.Body as MethodCallExpression;
            Action = actionBody.Method.Name;
            Route.Add(Constants.Conventions.Action, Action);

            var paramNames = actionBody.Method.GetParameters();
            var paramValues = actionBody.Arguments;
            Params = new RouteValueDictionary();

            for (int i = 0; i < paramNames.Length; i++)
            {
                var name = paramNames[i].Name;
                var lambda = Expression.Lambda(paramValues[i]);
                var compiledExpr = lambda.Compile();
                var value = compiledExpr.DynamicInvoke();
                Params.Add(name, value);
                Route.Add(name, value);
            }
        }

        public string Controller { get; private set; }

        public string Action { get; private set; }

        public RouteValueDictionary Params { get; private set; }

        public RouteValueDictionary Route { get; private set; }
    }
}
