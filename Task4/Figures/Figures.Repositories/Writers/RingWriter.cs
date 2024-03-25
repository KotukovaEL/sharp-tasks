using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Figures.Repositories.Writers
{
    public class RingWriter : IEntityWriter<Ring>
    {
        public void Save(TextWriter writer, Ring ring, IdGenerator idGenerator)
        {
            ring.Center.Id = idGenerator.Generate();
            SavePoint(writer, ring.Center);
            writer.WriteLine($" Id: {ring.Id}");
            writer.WriteLine($" Center: {ring.Center.Id}");
            writer.WriteLine($" Long radius: {ring.BigCircle.Radius}");
            writer.WriteLine($" Short radius: {ring.SmallCircle.Radius}");
            writer.WriteLine("- Ring");
            writer.WriteLine();
        }
    }
}
