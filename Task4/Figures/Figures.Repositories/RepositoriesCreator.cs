using Figures.Common.Interfaces;
using Figures.Model;
using Figures.Repositories.Readers;
using Figures.Repositories.Writers;
using System.Collections.Generic;

namespace Figures.Repositories
{
    public static class RepositoriesCreator
    {
        public static IGeometricEntitiesRepository CreateEntitiesRepository(string entitiesFilename)
        {
            var sourceIO = new SourceIO("Entities.txt");

            var pointWriter = new PointWriter();
            var writersMap = new Dictionary<string, IEntityWriter<GeometricEntity>>
            {
                { nameof(Point), new EntityWriter<Point>(pointWriter) },
                { nameof(LineSegment), new EntityWriter<LineSegment>(new LineSegmentWriter(pointWriter)) },
                { nameof(Circle), new EntityWriter<Circle>(new CircleWriter()) },
                { nameof(Rectangle), new EntityWriter<Rectangle>(new RectangleWriter(pointWriter)) },
                { nameof(Ring), new EntityWriter<Ring>(new RingWriter(pointWriter)) },
                { nameof(Triangle), new EntityWriter<Triangle>(new TriangleWriter(pointWriter)) },
            };

            var writer = new GeometricEntitiesWriter(sourceIO, writersMap);

            var readersMap = new Dictionary<string, IEntityReader<GeometricEntity>>            
            {
                { nameof(Point), new EntityReader<Point>(new PointReader()) },
                { nameof(LineSegment), new EntityReader<LineSegment>(new LineSegmentReader()) },
                { nameof(Circle), new EntityReader<Circle>(new CircleReader()) },
                { nameof(Rectangle), new EntityReader<Rectangle>(new RectangleReader()) },
                { nameof(Ring), new EntityReader<Ring>(new RingReader()) },
                { nameof(Triangle), new EntityReader<Triangle>(new TriangleReader()) },
            };

            var reader = new GeometricEntitiesReader(sourceIO, readersMap);
            return new GeometricEntitiesRepository(writer, reader);
        }
    }
}