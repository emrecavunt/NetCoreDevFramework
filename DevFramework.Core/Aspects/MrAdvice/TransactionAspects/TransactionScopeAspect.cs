using ArxOne.MrAdvice.Advice;
using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
namespace DevFramework.Core.Aspects.MrAdvice.TransactionAspects
{
    [Serializable]
    //public class TransactionScopeAspect : OnMethodBoundaryAspect
    public class TransactionScopeAspect : Attribute, IMethodAdvice 
    {
        private TransactionScopeOption _option;

        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionScopeAspect()
        {

        }
        //public override void OnEntry(MethodExecutionArgs args)
        //{
        //    //args.MethodExceutionTag = new TransactionScope(_option);
        //}
        //public override void OnSuccess(MethodExecutionArgs args)
        //{
        //    //((TransactionScope)args.MethodExceutionTag).TransactionCompleted();

        //}
        //public override void OnExit(MethodExecutionArgs args)
        //{
        //    //((TransactionScope)args.MethodExceutionTag).Dispose();

        //}

        public void Advise(MethodAdviceContext context)
        {
             
            context.Proceed();
        }
    }
}
