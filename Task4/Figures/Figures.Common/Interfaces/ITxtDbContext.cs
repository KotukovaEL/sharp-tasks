using System.Collections.Generic;

namespace Figures.Common.Interfaces
{
    public interface ITxtDbContext<TKey, TValue>
    {
        Dictionary<TKey, TValue> EntitiesMap { get; }
        IIdGenerator IdGenerator { get; }
        TValue GetByKey(TKey key);
        void SaveChanges();
        void ReadFile();
    }
}
