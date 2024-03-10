using Figures.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Figures.Common.Interfaces
{
    public interface IIdGenerator
    {
        void Reload(Dictionary<int, GeometricEntity> entity);
        int Generate();
    }
}
