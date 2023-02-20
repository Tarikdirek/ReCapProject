using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
           var classAttributes = type.GetCustomAttributes<MethodInterceptoinBaseAttribute>(true).ToList();
           var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptoinBaseAttribute>(true);
           classAttributes.AddRange(methodAttributes);
            return classAttributes.OrderBy(x => x.Priority).ToArray();
           
        }
    }
}
