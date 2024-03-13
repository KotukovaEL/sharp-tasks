using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Figures.Repositories
{
    public class SourceIO : ISourceIO
    {
        private readonly string _filePath;

        public SourceIO(string filePath)
        {
            _filePath = filePath;
        }

        public TextWriter CreateWriter()
        {
            using var fs = new FileStream(_filePath, FileMode.Create);
            return new StreamWriter(fs);
        }

        public string[] ReadAllLines()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
