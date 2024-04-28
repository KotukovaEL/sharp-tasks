using Figures.Model;
using System.Collections.Generic;

namespace Figures.Common.Interfaces
{
    public interface IUsersService
    {
        void AddFigure(string name, GeometricEntity geometricEntity);
        List<GeometricEntity> ListFigures(string name);
        void DeleteFigures(string name);
        void Authorize(string name);
    }
}
