
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]

    //attribute enumsa ait class ve method denetimi
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor//castle dynamic proxy
    {
        public int Priority { get; set; }
        //MethodInterceptionBaseAttribute sınıfları içerisinde öncelik belirtme aspect sıra control

        public virtual void Intercept(IInvocation invocation)
        {

        }

    }



}
