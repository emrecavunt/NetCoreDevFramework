using System;
using System.Collections.Generic;
using System.Text;

namespace DevFramework.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        void Add(string key,object data,int cacheTime);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPatternt(string pattern);
        void Clear();
    }
}
