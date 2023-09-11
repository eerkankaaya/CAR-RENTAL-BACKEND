using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.TransactionScopeAspects
{//AOP
    public class TransactionScopeAspect : MethodInterception
    {
        //TransactionScope içinde bir metodun çalıştırılmasını ve işlem tamamlanmasını veya bir hata durumunda geri alınmasını yönetiyor.
        public override void Intercept(IInvocation invocation) // invocation>> bizim metodumuz. Metot yerine Intercept bloğunu(aşağıdaki bloğu) çalıştır demek.
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();//metodun içindeki kodları burda çalıştırıyoruz
                    transactionScope.Complete();//işlemin başarıyla tamamlandığını işaretleme amacıyla çağrılır
                }
                //invocation.Proceed() satırında bir hata meydana gelirse, catch bloğu devreye girer. Bu blok, hata durumunda işlemin geri alınmasını ve TransactionScope nesnesinin kapatılmasını sağlar.
                catch (Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
