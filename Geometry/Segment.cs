using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    public sealed class Segment
    {

        Point2D[] points = new Point2D[2];

        #region Constructors

        public Segment() : this(new Point2D(0, 0), new Point2D(0, 0)) { }

        public Segment(Point2D[] pointArray) : this(pointArray[0], pointArray[1]) 
        {
            if(pointArray.Length < 2)
            {
                throw new DificiencyArgumentException("Недостаточно аргументов");
            }
        }


        public Segment(Point2D a, Point2D b)
        {
            points[0] = a;
            points[1] = b;
        }

        #endregion

        #region Methods
        public static double SegmentLength(Point2D a, Point2D b)
        {
            return Math.Abs(Math.Sqrt(Math.Pow((b.X - a.X), 2) + Math.Pow((b.Y - a.Y), 2)));
        }
        public double Length => SegmentLength(points[0], points[1]);
        #endregion
    }



    


    public class DificiencyArgumentException : Exception
    {
        public DificiencyArgumentException()
        {
        }

        public DificiencyArgumentException(string message)
            : base(message)
        {
        }

        public DificiencyArgumentException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }

}
