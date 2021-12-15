using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    public abstract class Shape
    {
        public abstract double Area { get; }
        public abstract double Perimetr { get; }

        public abstract ShapeType Type { get; }

        public abstract string toString { get; }

    }

    public abstract class Angles : Shape
    {
        public override double Area { get; }
        public override double Perimetr { get; }

        public abstract int AngleCount { get; }

        public int AngleSum { get { return (AngleCount - 2) * 180; } }
        public override ShapeType Type { get; }
    }
    public class Triangle : Angles
    {
        #region Vars

        Point2D[] points = new Point2D[3];

        #endregion

        #region Constructors

        public Triangle(Point2D a, Point2D b, Point2D c)
        {
            if (((Segment.SegmentLength(a, b) + Segment.SegmentLength(b, c)) < (Segment.SegmentLength(a, c))) || ((Segment.SegmentLength(a, b) + Segment.SegmentLength(a, c)) < (Segment.SegmentLength(b, c))) || ((Segment.SegmentLength(b, c) + Segment.SegmentLength(a, c)) < (Segment.SegmentLength(a, b)))) 
            {
                throw new WrongLengthException("Такой треугольник не может существовать");
            }
            
            points[0] = a;
            points[1] = b;
            points[2] = c;
        }

        public Triangle(Point2D[] Points) : this(Points[0], Points[1], Points[2])
        {
            if(Points.Length < 3)
            {
                throw new DificiencyArgumentException("Недостаточно аргументов");
            }
        }



        #endregion

        #region Properties

        public override double Perimetr => Segment.SegmentLength(points[0], points[1]) + Segment.SegmentLength(points[1], points[2]) + Segment.SegmentLength(points[2], points[0]);

        public override int AngleCount => 3;

        public override ShapeType Type => ShapeType.Triangle;
        public override double Area => 0.5*((points[0].X * points[1].Y)+ (points[1].X * points[2].Y) + (points[2].X * points[0].Y) + (points[1].X * points[0].Y) + (points[2].X * points[1].Y) + (points[0].X * points[2].Y));

        public override string toString => Type + "\nCount of angle: " + AngleCount + "\nArea: " + Area + " cm^2\nPerimetr: " + Perimetr + " cm\nSum of angle: " + AngleSum ;

        #endregion
    }    
    
    public class Rectangle : Angles
    {
        #region Vars
        Point2D[] points = new Point2D[4];
        #endregion

        #region Properties
        public override double Area => A * B;
        public override double Perimetr => 2 * (A + B);

        public override int AngleCount => 4;

        public double A => Segment.SegmentLength(points[0], points[2]);

        public double B => Segment.SegmentLength(points[0], points[3]);



        public override ShapeType Type => ShapeType.Rectangle;


        public double Diagonal => Segment.SegmentLength(points[0], points[2]);

        public override string toString => Type + "\nCount of angle: " + AngleCount + "\nArea: " + Area + " cm^2\nDiagonal: " + Diagonal + "cm\nPerimetr: " + Perimetr + " cm\nSum of angle: " + AngleSum;
        
        #endregion

        #region Constructors

        public Rectangle(Point2D a, Point2D b)
        {
            

            points[0] = a;
            points[1] = b;
            points[2] = new Point2D(a.X, b.Y);
            points[3] = new Point2D(b.X, a.Y);

        }

        public Rectangle(Point2D[] Points) : this(Points[0], Points[1])
        {
            if (Points.Length < 2)
            {
                throw new DificiencyArgumentException("Недостаточно аргументов");
            }
        }

        #endregion

    }
    public class Ellipse : Shape
    {
        #region Properties
        public override double Area => RadMax * RadMin * Math.PI;
        public override double Perimetr => 4 * (Area + RadMin - RadMax) / (RadMin + RadMax);

        public override ShapeType Type => ShapeType.Ellipse;

        public Point2D Center { get; set; }

        public double RadMin { get; set; }

        public double RadMax { get; set; }

        public override string toString => Type + "\nArea: " + Math.Round(Area) + " cm^2\nPerimetr: " + Math.Round(Perimetr) + " cm\n";


        #endregion

        #region Constructors 

        public Ellipse(Point2D center, double radMax, double radMin) 
        {
            Center = center;
            RadMax = radMax;
            RadMin = radMin;
        }

        public Ellipse(Point2D center, Point2D radMax, Point2D radMin) : this(center, Segment.SegmentLength(radMax, center), Segment.SegmentLength(radMin, center)) { }
        
        #endregion
    }
    public class Circle : Shape
    {
        #region Properties
        public override double Area => Math.Pow(Rad, 2)  * Math.PI;
        public override double Perimetr => 2 * Rad * Math.PI ;

        public override ShapeType Type => ShapeType.Circle;

        public Point2D Center { get; set; }

        public double Rad { get; set; }

        public override string toString => Type + "\nArea: " + Math.Round(Area) + " cm^2\nPerimetr: " + Math.Round(Perimetr) + " cm\n";


        #endregion

        #region Constructors 

        public Circle(Point2D center, double rad)
        {
            Center = center;
            Rad = rad;
        }

        public Circle(Point2D center, Point2D rad) : this(center, Segment.SegmentLength(center, rad)) { }

        #endregion
    }




    public enum ShapeType
    {
        Circle, Rectangle, Ellipse, Triangle, Square, Parallelogram, Rhombus, Trapezoid, Pentagon, Hexagon, Polygon
    }

    public class WrongLengthException : Exception
    {
        public WrongLengthException()
        {
        }

        public WrongLengthException(string message)
            : base(message)
        {
        }

        public WrongLengthException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}


