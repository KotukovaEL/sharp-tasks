using Figures.Common.Interfaces;
using Figures.Model;
using Figures.Repositories.TxtDb.Readers;
using Figures.Repositories.TxtDb.Writers;
using Figures.Repositories.Writers;
using System.Collections.Generic;

namespace Figures.Repositories
{
    public static class RepositoriesCreator
    {
        public static IGeometricEntitiesRepository CreateEntitiesTxtRepository(string entitiesFilename)
        {
            var sourceIO = new SourceIO(entitiesFilename);

            var pointWriter = new PointWriter();
            var writersMap = new Dictionary<string, IEntityWriter<GeometricEntity>>
            {
                { nameof(Point), new EntityWriter<Point>(pointWriter) },
                { nameof(LineSegment), new EntityWriter<LineSegment>(new LineSegmentWriter(pointWriter)) },
                { nameof(Circle), new EntityWriter<Circle>(new CircleWriter(pointWriter)) },
                { nameof(Rectangle), new EntityWriter<Rectangle>(new RectangleWriter(pointWriter)) },
                { nameof(Ring), new EntityWriter<Ring>(new RingWriter(pointWriter)) },
                { nameof(Triangle), new EntityWriter<Triangle>(new TriangleWriter(pointWriter)) },
            };

            var writer = new GeometricEntitiesWriter(sourceIO, writersMap);

            var readersMap = new Dictionary<string, IEntityReader<GeometricEntity>>
            {
                { nameof(Point), new PointReader() },
                { nameof(LineSegment), new LineSegmentReader() },
                { nameof(Circle), new CircleReader () },
                { nameof(Rectangle), new RectangleReader () },
                { nameof(Ring), new RingReader () },
                { nameof(Triangle), new TriangleReader () },
            };

            var reader = new GeometricEntitiesReader(sourceIO, readersMap);
            return new GeometricEntitiesRepository(writer, reader);
        }

        public static IUsersRepository CreateUsersTxtRepository(string usersFilename)
        {
            var sourceIO = new SourceIO(usersFilename);
            var writer = new UsersWriter(sourceIO);
            var reader = new UsersReader(sourceIO);

            return new UsersRepository(writer, reader);
        }
        public static IGeometricEntitiesRepository CreateEntitiesJsonRepository(string entitiesFilename)
        {
            var sourceIO = new SourceIO(entitiesFilename);
            var writer = new JsonDb.GeometricEntitiesWriter(sourceIO);
            var reader = new JsonDb.GeometricEntitiesReader(sourceIO);
            return new GeometricEntitiesRepository(writer, reader);
        }
    }
}