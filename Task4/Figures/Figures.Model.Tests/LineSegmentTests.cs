using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Figures.Model.Tests
{
    public class LineSegmentTests
    {
        [Fact]
        public void Should_pass_validation_incorrectly()
        {
            var point1 = new Point(1, 1);
            var point2 = new Point(1, 1);
            Func<LineSegment> func = () => new LineSegment(point1, point2);
            Assert.Throws<ArgumentException>(() => func());
        }
    }
}
