using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Figures.Repositories.Writers
{
    public class PointWriter : IEntityWriter<Point>
    {
        public void Save(TextWriter writer, Point point, IdGenerator idGenerator)
        {
            writer.WriteLine($" Id: {point.Id}");
            writer.WriteLine($" X: {point.X}");
            writer.WriteLine($" Y: {point.Y}");
            writer.WriteLine("Point");
            writer.WriteLine();
        }
    }
}
