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
            var controllerTypeName = typeof(TController).Name;
            Controller = controllerTypeName.Replace(Constants.Controller, String.Empty);

            var actionBody = action.Body as MethodCallExpression;
            Action = actionBody.Method.Name;

            var paramNames = actionBody.Method.GetParameters();
            var paramValues = actionBody.Arguments;
            Values = new RouteValueDictionary();

            for (int i = 0; i < paramNames.Length; i++)
            {
                var name = paramNames[i].Name;
                var lambda = Expression.Lambda(paramValues[i]);
                var compiledExpr = lambda.Compile();
                var value = compiledExpr.DynamicInvoke();
                Values.Add(name, value);
            }
        }

        public string Controller { get; private set; }

        public string Action { get; private set; }

        public RouteValueDictionary Values { get; private set; }
    }
}
