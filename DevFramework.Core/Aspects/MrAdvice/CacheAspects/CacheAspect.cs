using DevFramework.Core.CrossCuttingConcerns.Caching;
using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
namespace DevFramework.Core.Aspects.MrAdvice.CacheAspects
{
    [Serializable]
    public class CacheAspect : MethodInterceptionAspect
    {
        private Type _cachetype;
        private int _cacheByMinute;
        private ICacheManager _cacheManager;

        public CacheAspect(Type type, int cacheByMinute = 60)
        {
            _cachetype = type;
            _cacheByMinute = cacheByMinute;
        } 
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cachetype) == false)
            {
                throw new Exception("Worn Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cachetype);

            var methodName = string.Format("{0}.{1}.{2}", args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name, args.Method.Name);
            var arguments = args.Arguments.ToList();
            var key = string.Format("{0}({1})", methodName, string.Join(",",arguments.Select(x=> x!=null ? x.ToString() : "<Null>")));

            if(_cacheManager.IsAdd(key))
            {
                args.SetReturnValue(_cacheManager.Get<object>(key));
            }

            base.OnInvoke(args);
            _cacheManager.Add(key, args.ReturnValue, _cacheByMinute);
        }
        
        //public override void RuntimeInitialize(MethodBase method)
        //{
        //    if (typeof(ICacheManager).IsAssignableFrom(_cachetype) == false)
        //    {
        //        throw new Exception("Worn Cache Manager");
        //    }
        //    _cacheManager = (ICacheManager)Activator.CreateInstance(_cachetype);

        //    base.RuntimeInitialize(method)
        //}
    }
}
