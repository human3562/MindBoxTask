namespace MindBoxTask_1;

public struct Point(double x, double y) {
    public double X = x;
    public double Y = y;

    public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);

    public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);    

    public double Magnitude() {
        return (double)Math.Sqrt(X * X + Y * Y);
    }

    public static double Dot(Point p1, Point p2) {
        return p1.X * p2.X + p1.Y * p2.Y;
    }

    public static double Distance(Point p1, Point p2) {
        return (p2 - p1).Magnitude();
    }
}

public abstract class Shape {
    public Point Origin;
    public abstract double Area();
}

public class Circle : Shape {
    public double Radius;
    public Circle(Point origin, double r) {
        Origin = origin;
        Radius = r;
    }

    public override double Area() => Math.PI * Radius * Radius;
}

public class Triangle : Shape {
    public Point[] Sides = new Point[3];
    public Triangle(Point origin, Point a, Point b, Point c)
    {
        Origin = origin;
        Sides[0] = a; Sides[1] = b; Sides[2] = c;
    }

    public override double Area() {
        double a = Point.Distance(Sides[0], Sides[1]);
        double b = Point.Distance(Sides[1], Sides[2]);
        double c = Point.Distance(Sides[2], Sides[0]);
        double sp = (a + b + c) * 0.5;
        return (double)Math.Sqrt(sp * (sp-a) * (sp-b) * (sp-c));
    }

    public bool IsRightAngle() {
        return Point.Dot(Sides[0], Sides[1]) <= Double.Epsilon ||
               Point.Dot(Sides[1], Sides[2]) <= Double.Epsilon ||
               Point.Dot(Sides[2], Sides[0]) <= Double.Epsilon;
    }
}