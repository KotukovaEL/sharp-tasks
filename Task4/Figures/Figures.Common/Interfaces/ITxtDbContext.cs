using Figures.Model;
using System.Collections.Generic;

namespace Figures.Common.Interfaces
{
    public interface ITxtDbContext<TKey, TValue>
    {
        Dictionary<TKey, TValue> EntitiesMap { get; }
        TValue GetByKey(TKey key);
        void Add(TValue value);
        void SaveChanges();
        void ReadFile();
    }
}
