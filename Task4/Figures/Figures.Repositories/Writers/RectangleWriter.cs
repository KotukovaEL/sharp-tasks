using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Figures.Repositories.Writers
{
    public class RectangleWriter : IEntityWriter<Rectangle>
    {
        public void Save(TextWriter writer, Rectangle rectangle, IdGenerator idGenerator)
        {
            rectangle.A.Id = idGenerator.Generate();
            SavePoint(writer, rectangle.A);
            rectangle.B.Id = idGenerator.Generate();
            SavePoint(writer, rectangle.B);
            rectangle.C.Id = idGenerator.Generate();
            SavePoint(writer, rectangle.C);
            rectangle.D.Id = idGenerator.Generate();
            SavePoint(writer, rectangle.D);
            writer.WriteLine($" Id: {rectangle.Id}");
            writer.WriteLine($" A: {rectangle.A.Id}");
            writer.WriteLine($" B: {rectangle.B.Id}");
            writer.WriteLine($" C: {rectangle.C.Id}");
            writer.WriteLine($" D: {rectangle.D.Id}");
            writer.WriteLine("- Rectangle");
            writer.WriteLine();
        }
    }
}
