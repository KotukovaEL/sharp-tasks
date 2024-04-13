using Figures.Model;
using System;

namespace Figures.Repositories.JsonDb
{
    public class EntityMapper
    {
        public Point ConvertFromDto(PointDto pointDto)
        {
            return new Point(pointDto.X, pointDto.Y) { Id = pointDto.Id };
        }

        public PointDto ConvertToDto(Point point)
        {
            return new PointDto
            {
                X = point.X,
                Y = point.Y,    
                Id = point.Id
            };
        }

        public Circle ConvertFromDto(CircleDto circleDto)
        {
            var center = ConvertFromDto(circleDto.Center);
            return new Circle(center, circleDto.Radius) { Id = circleDto.Id };
        }

        public CircleDto ConvertToDto(Circle circle)
        {
            return new CircleDto
            {
                Center = ConvertToDto(circle.Center),
                Radius = circle.Radius,
                Id = circle.Id
            };
        }

        public LineSegment ConvertFromDto(LineSegmentDto lineSegmentDto)
        {
            var pointA = ConvertFromDto(lineSegmentDto.A);
            var pointB = ConvertFromDto(lineSegmentDto.B);
            return new LineSegment(pointA, pointB) { Id = lineSegmentDto.Id };
        }

        public LineSegmentDto ConvertToDto(LineSegment lineSegment)
        {
            return new LineSegmentDto
            {
                A = ConvertToDto(lineSegment.A),
                B = ConvertToDto(lineSegment.B),
                Id = lineSegment.Id
            };
        }

        public Rectangle ConvertFromDto(RectangleDto rectangleDto)
        {
            var pointA = ConvertFromDto(rectangleDto.A);
            var pointB = ConvertFromDto(rectangleDto.B);
            var pointC = ConvertFromDto(rectangleDto.C);
            var pointD = ConvertFromDto(rectangleDto.D);
            return new Rectangle(pointA, pointB, pointC, pointD) { Id = rectangleDto.Id };
        }

        public RectangleDto ConvertToDto(Rectangle rectangle)
        {
            return new RectangleDto
            {
                A = ConvertToDto(rectangle.A),
                B = ConvertToDto(rectangle.B),
                C = ConvertToDto(rectangle.C),
                D = ConvertToDto(rectangle.D),
                Id = rectangle.Id
            };
        }

        public Triangle ConvertFromDto(TriangleDto triangleDto)
        {
            var pointA = ConvertFromDto(triangleDto.A);
            var pointB = ConvertFromDto(triangleDto.B);
            var pointC = ConvertFromDto(triangleDto.C);
            return new Triangle(pointA, pointB, pointC) { Id = triangleDto.Id };
        }

        public TriangleDto ConvertToDto(Triangle triangle)
        {
            return new TriangleDto
            {
                A = ConvertToDto(triangle.A),
                B = ConvertToDto(triangle.B),
                C = ConvertToDto(triangle.C),
                Id = triangle.Id
            };
        }

        public Ring ConvertFromDto(RingDto ringDto)
        {
            var center = ConvertFromDto(ringDto.Center);
            return new Ring(center, ringDto.LongRadius, ringDto.ShortRadius) { Id = ringDto.Id };
        }

        public RingDto ConvertToDto(Ring ring)
        {
            return new RingDto
            {
                Center = ConvertToDto(ring.Center),
                LongRadius = ring.BigCircle.Radius,
                ShortRadius = ring.SmallCircle.Radius,
                Id = ring.Id
            };
        }
    }
}
