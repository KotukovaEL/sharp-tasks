using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Figures.Repositories.TxtDb.Writers
{
    public class RectangleWriter : IEntityWriter<Rectangle>
    {
        private readonly IEntityWriter<Point> _writer;

        public RectangleWriter(IEntityWriter<Point> writer)
        {
            _writer = writer;
        }

        public void Save(TextWriter writer, Rectangle rectangle, IdGenerator idGenerator)
        {
            rectangle.A.Id = idGenerator.Generate();
            _writer.Save(writer, rectangle.A, idGenerator);
            rectangle.B.Id = idGenerator.Generate();
            _writer.Save(writer, rectangle.B, idGenerator);
            rectangle.C.Id = idGenerator.Generate();
            _writer.Save(writer, rectangle.C, idGenerator);
            rectangle.D.Id = idGenerator.Generate();
            _writer.Save(writer, rectangle.D, idGenerator);
            writer.WriteLine($" Id: {rectangle.Id}");
            writer.WriteLine($" A: {rectangle.A.Id}");
            writer.WriteLine($" B: {rectangle.B.Id}");
            writer.WriteLine($" C: {rectangle.C.Id}");
            writer.WriteLine($" D: {rectangle.D.Id}");
            writer.WriteLine("Rectangle");
            writer.WriteLine();
        }
    }
}
