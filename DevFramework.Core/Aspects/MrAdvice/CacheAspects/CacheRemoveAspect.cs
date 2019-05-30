using DevFramework.Core.CrossCuttingConcerns.Caching;
using MrAdvice.Sharp.Aspects;
using MrAdvice.Sharp.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DevFramework.Core.Aspects.MrAdvice.CacheAspects
{
    [Serializable]
    public class CacheRemoveAspect : OnMethodBoundaryAspect
    {
        private string _pattern;
        Type _cacheType;
        ICacheManager _cacheManager;
        public CacheRemoveAspect(Type cacheType)
        {
            _cacheType = cacheType;
        }
        public CacheRemoveAspect(string pattern,Type cacheType)
        {
            _pattern = pattern;
            _cacheType = cacheType;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("Worn Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.OnEntry(args);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheManager.RemoveByPatternt(string.IsNullOrEmpty(_pattern) ? string.Format("{0}.{1}.*",args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name):_pattern);

            base.OnSuccess(args);
        }
    }
}
