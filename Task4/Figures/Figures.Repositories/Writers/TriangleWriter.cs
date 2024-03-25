using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Figures.Repositories.Writers
{
    public class TriangleWriter : IEntityWriter<Triangle>
    {
        public void Save(TextWriter writer, Triangle triangle, IdGenerator idGenerator)
        {
            triangle.A.Id = idGenerator.Generate();
            SavePoint(writer, triangle.A);
            triangle.B.Id = idGenerator.Generate();
            SavePoint(writer, triangle.B);
            triangle.C.Id = idGenerator.Generate();
            SavePoint(writer, triangle.C);
            writer.WriteLine($" Id: {triangle.Id}");
            writer.WriteLine($" A: {triangle.A.Id}");
            writer.WriteLine($" B: {triangle.B.Id}");
            writer.WriteLine($" C: {triangle.C.Id}");
            writer.WriteLine("- Triangle");
            writer.WriteLine();
        }
    }
]
