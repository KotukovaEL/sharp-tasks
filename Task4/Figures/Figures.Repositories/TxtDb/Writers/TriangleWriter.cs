using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Figures.Repositories.TxtDb.Writers
{
    public class TriangleWriter : IEntityWriter<Triangle>
    {
        private readonly IEntityWriter<Point> _writer;

        public TriangleWriter(IEntityWriter<Point> writer)
        {
            _writer = writer;
        }

        public void Save(TextWriter writer, Triangle triangle, IdGenerator idGenerator)
        {
            triangle.A.Id = idGenerator.Generate();
            _writer.Save(writer, triangle.A, idGenerator);
            triangle.B.Id = idGenerator.Generate();
            _writer.Save(writer, triangle.B, idGenerator);
            triangle.C.Id = idGenerator.Generate();
            _writer.Save(writer, triangle.C, idGenerator);
            writer.WriteLine($" Id: {triangle.Id}");
            writer.WriteLine($" A: {triangle.A.Id}");
            writer.WriteLine($" B: {triangle.B.Id}");
            writer.WriteLine($" C: {triangle.C.Id}");
            writer.WriteLine("Triangle");
            writer.WriteLine();
        }
    }
}
