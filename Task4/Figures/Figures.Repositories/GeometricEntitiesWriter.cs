using Figures.Model;
using Figures.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using System.Text;

namespace Figures.Repositories
{
    public class GeometricEntitiesWriter : IGeometricEntitiesWriter
    {
        private readonly ISourceIO _sourceIO;

        public GeometricEntitiesWriter(ISourceIO sourceIO)
        {
            _sourceIO = sourceIO;
        }

        public void SaveChanges(GeometricEntitiesContext context)
        {
            using var stream = _sourceIO.CreateWriter();

            foreach (var entity in context.EntitiesMap)
            {
                switch (entity.Value)
                {
                    case Point point:
                        SavePoint(stream, point);
                        break;
                    case LineSegment line:
                        SaveLineSegment(stream, line, context);
                        break;
                    case Circle circle:
                        SaveCircle(stream, circle, context);
                        break;
                    case Rectangle rectangle:
                        SaveRectangle(stream, rectangle, context);
                        break;
                    case Triangle triangle:
                        SaveTriangle(stream, triangle, context);
                        break;
                    case Ring ring:
                        SaveRing(stream, ring, context);
                        break;
                    default:
                        throw new ArgumentException($"Unknown entity type {entity.GetType().Name}.");
                }
            }
        }
        private void SavePoint(TextWriter stream, Point point)
        {
            stream.WriteLine($" Id: {point.Id}");
            stream.WriteLine($" X: {point.X}");
            stream.WriteLine($" Y: {point.Y}");
            stream.WriteLine("- Point");
            stream.WriteLine();
        }

        private void SaveLineSegment(TextWriter stream, LineSegment line, GeometricEntitiesContext context)
        {
            line.A.Id = context.IdGenerator.Generate();
            SavePoint(stream, line.A);
            line.B.Id = context.IdGenerator.Generate();
            SavePoint(stream, line.B);
            stream.WriteLine($" Id: {line.Id}");
            stream.WriteLine($" A: {line.A.Id}");
            stream.WriteLine($" B: {line.B.Id}");
            stream.WriteLine("- LineSegment");
            stream.WriteLine();
        }

        private void SaveCircle(TextWriter stream, Circle circle, GeometricEntitiesContext context)
        {
            circle.Center.Id = context.IdGenerator.Generate();
            SavePoint(stream, circle.Center);
            stream.WriteLine($" Id: {circle.Id}");
            stream.WriteLine($" Center: {circle.Center.Id}");
            stream.WriteLine($" Radius: {circle.Radius}");
            stream.WriteLine("- Circle");
            stream.WriteLine();
        }

        private void SaveRectangle(TextWriter stream, Rectangle rectangle, GeometricEntitiesContext context)
        {
            rectangle.A.Id = context.IdGenerator.Generate();
            SavePoint(stream, rectangle.A);
            rectangle.B.Id = context.IdGenerator.Generate();
            SavePoint(stream, rectangle.B);
            rectangle.C.Id = context.IdGenerator.Generate();
            SavePoint(stream, rectangle.C);
            rectangle.D.Id = context.IdGenerator.Generate();
            SavePoint(stream, rectangle.D);
            stream.WriteLine($" Id: {rectangle.Id}");
            stream.WriteLine($" A: {rectangle.A.Id}");
            stream.WriteLine($" B: {rectangle.B.Id}");
            stream.WriteLine($" C: {rectangle.C.Id}");
            stream.WriteLine($" D: {rectangle.D.Id}");
            stream.WriteLine("- Rectangle");
            stream.WriteLine();
        }


        private void SaveTriangle(TextWriter stream, Triangle triangle, GeometricEntitiesContext context)
        {
            triangle.A.Id = context.IdGenerator.Generate();
            SavePoint(stream, triangle.A);
            triangle.B.Id = context.IdGenerator.Generate();
            SavePoint(stream, triangle.B);
            triangle.C.Id = context.IdGenerator.Generate();
            SavePoint(stream, triangle.C);
            stream.WriteLine($" Id: {triangle.Id}");
            stream.WriteLine($" A: {triangle.A.Id}");
            stream.WriteLine($" B: {triangle.B.Id}");
            stream.WriteLine($" C: {triangle.C.Id}");
            stream.WriteLine("- Triangle");
            stream.WriteLine();
        }

        private void SaveRing(TextWriter stream, Ring ring, GeometricEntitiesContext context)
        {
            ring.Center.Id = context.IdGenerator.Generate();
            SavePoint(stream, ring.Center);
            stream.WriteLine($" Id: {ring.Id}");
            stream.WriteLine($" Center: {ring.Center.Id}");
            stream.WriteLine($" Long radius: {ring.BigCircle.Radius}");
            stream.WriteLine($" Short radius: {ring.SmallCircle.Radius}");
            stream.WriteLine("- Ring");
            stream.WriteLine();
        }
    }
}
