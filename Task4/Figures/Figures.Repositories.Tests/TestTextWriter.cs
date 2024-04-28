using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures.Repositories.Tests
{
    public class TestTextWriter : TextWriter
    {
        private readonly Stream _stream;

        public TestTextWriter(Stream stream)
        {
            _stream = stream;
        }

        public override Encoding Encoding => Encoding.UTF8;

        public override void WriteLine(string value)
        {
            var bytes = Encoding.GetBytes(value + Environment.NewLine);
            _stream.Write(bytes);
        }

        public override void WriteLine()
        {
            WriteLine(string.Empty);
        }
    }
}
