using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{//AOP
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)//bellekte default 60 dk. süre verilmezse kndiliğinden 60 dk tutacak
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            //invocation.Method.ReflectedType.FullName >> namespace + classın ismini verir. Method.Name>< metodun ismini verir. key oluşturmaya çalışıyoruz. örn:(Northwind.Business.ICarService.GetAll)
            var arguments = invocation.Arguments.ToList();//methodun parametresi varsa listeye çevirir
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //parametre değeri varsa GetAll() içine ekle >> Northwind.Business.ICarService.GetAll(x) .. ?? >> yoksa "<Null>" ekle demek.
            if (_cacheManager.IsAdd(key))//cache anahtarı bellekte var mı
            {
                invocation.ReturnValue = _cacheManager.Get(key); //varsa cache managerden getir
                return;
            }
            invocation.Proceed(); // ama yoksa metodu devam ettir. metot çalışınca veritabanına gider. veri tabanından datayı getirir
            _cacheManager.Add(key, invocation.ReturnValue, _duration); // demekki önceden cache eklenmemiş şuan eklenmesi gerekiyor ve ekler.
        }
    }
}
