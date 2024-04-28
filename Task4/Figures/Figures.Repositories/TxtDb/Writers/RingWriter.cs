using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Figures.Repositories.TxtDb.Writers
{
    public class RingWriter : IEntityWriter<Ring>
    {
        private readonly IEntityWriter<Point> _writer;

        public RingWriter(IEntityWriter<Point> writer)
        {
            _writer = writer;
        }

        public void Save(TextWriter writer, Ring ring, IdGenerator idGenerator)
        {
            ring.Center.Id = idGenerator.Generate();
            _writer.Save(writer, ring.Center, idGenerator);
            writer.WriteLine($" Id: {ring.Id}");
            writer.WriteLine($" Center: {ring.Center.Id}");
            writer.WriteLine($" Long radius: {ring.BigCircleRadius}");
            writer.WriteLine($" Short radius: {ring.SmallCircleRadius}");
            writer.WriteLine("Ring");
            writer.WriteLine();
        }
    }
}
