using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Figures.Repositories.Writers
{
    public class LineSegmentWriter : IEntityWriter<LineSegment>
    {
        private readonly IEntityWriter<Point> _writer;

        public LineSegmentWriter(IEntityWriter<Point> writer)
        {
            _writer = writer;
        }

        public void Save(TextWriter writer, LineSegment line, IdGenerator idGenerator)
        {
            line.A.Id = idGenerator.Generate();
            _writer.Save(writer, line.A, idGenerator);
            line.B.Id = idGenerator.Generate();
            _writer.Save(writer, line.B, idGenerator);
            writer.WriteLine($" Id: {line.Id}");
            writer.WriteLine($" A: {line.A.Id}");
            writer.WriteLine($" B: {line.B.Id}");
            writer.WriteLine("LineSegment");
            writer.WriteLine();
        }
    }
}
