using Figures.Model;

namespace Figures.ConsoleApp
{
    public interface IEntitiesCreator
    {
        GeometricEntity CreateEntityByType(GeometricEntityTypes geometricFigure);
    }
}