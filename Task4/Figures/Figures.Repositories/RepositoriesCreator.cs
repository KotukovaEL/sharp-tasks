using Figures.Common.Interfaces;
using Figures.Model;
using Figures.Repositories.Writers;
using System;
using System.Collections.Generic;
using System.Text;

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
                { nameof(Rectangle), new EntityWriter<Rectangle>(new RectangleWriter()) },
                { nameof(Ring), new EntityWriter<Ring>(new RingWriter()) },
                { nameof(Triangle), new EntityWriter<Triangle>(new TriangleWriter()) },
            };

            var writer = new GeometricEntitiesWriter(sourceIO, writersMap);

            var reader = new GeometricEntitiesReader(sourceIO);

            return new GeometricEntitiesRepository(writer, reader);
        }
    }
}