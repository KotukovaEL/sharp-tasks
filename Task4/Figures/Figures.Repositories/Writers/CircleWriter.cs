﻿using Figures.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Figures.Repositories.Writers
{
    public class CircleWriter : IEntityWriter<Circle>
    {
        private readonly IEntityWriter<Point> _pointWriter;

        public CircleWriter(IEntityWriter<Point> writer)
        {
            _pointWriter = writer;
        }

        public void Save(TextWriter writer, Circle circle, IdGenerator idGenerator)
        {
            circle.Center.Id = idGenerator.Generate();
            _pointWriter.Save(writer, circle.Center, idGenerator);
            writer.WriteLine($" Id: {circle.Id}");
            writer.WriteLine($" Center: {circle.Center.Id}");
            writer.WriteLine($" Radius: {circle.Radius}");
            writer.WriteLine("Circle");
            writer.WriteLine();
        }
    }
}
