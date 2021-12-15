using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Geometry
{
    public class Point2D
    {
        double x, y;

        #region Constructor
        public Point2D()
        {

        }

        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Point2D(double[] array)
        {
            if (array.Length > 1)
            {
                x = array[0];
                y = array[1];
            }
            else
            {
                throw new Exception("Слишком короткий массив");
            }

        }
        #endregion

        #region Properties
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public bool IsEmpty => x == 0 && y == 0;
        #endregion

        #region Methods
        public void Display()
        {
            Console.WriteLine($"Point2D: X:{X} Y:{Y}");
        }

        public void Display(string name)
        {
            Console.WriteLine($"{name}: X:{X} Y:{Y}");
        }

        public double[] ToArray()
        {
            return new double[] { x, y };
        }

        public double this[int i]
        {
            get
            {
                if (i > ToArray().Length || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return ToArray()[i];
            }

        }

        public double? this[string name]
        {
            get
            {
                switch (name.ToLower())
                {
                    case "x": return x;
                    case "y": return y;
                    default: return null;
                }
            }

        }


        public bool Equals(Point2D point)
        {
            return x == point.X && y == point.Y;
        }
        public Point2D Add(Point2D point)
        {
            return new Point2D(x += point.X, y += point.Y);
        }


        public Point2D Add(double[] array)
        {
            if (array.Length < 2)
            {
                throw new Exception("Слишком короткий массив");
            }
            return new Point2D(x += array[0], y += array[1]);
        }

        public Point2D Add(Vector2D vector)
        {
            return new Point2D(x += vector.X, y += vector.Y);
        }

        #endregion

        #region Static Methods
        public static Point2D Add(Point2D point, double[] array)
        {
            if (array.Length < 2)
            {
                throw new Exception("Слишком короткий массив");
            }
            return new Point2D(point.x += array[0], point.y += array[1]);
        }


        public static Point2D Add(Point2D point1, Point2D point2)
        {
            return new Point2D(point1.x + point2.x, point1.y + point2.y);
        }

        public static Point2D Add(Point2D point1, Vector2D vector)
        {
            return new Point2D(point1.x + vector.X, point1.y + vector.Y);
        }



        public static explicit operator Point2D(double[] array)
        {
            if (array.Length < 2)
            {
                throw new Exception("Слишком короткий массив");
            }
            return new Point2D(array);
        }

        public static explicit operator double[](Point2D point)
        {
            return point.ToArray();
        }

        #endregion

        #region Operators
        public static Point2D operator +(Point2D point1, double[] array)
        {
            return Add(point1, array);
        }

        public static Point2D operator +(Point2D point1, Point2D point2)
        {
            return Add(point1, point2);
        }

        public static Point2D operator +(Point2D point1, Vector2D vector)
        {
            return Add(point1, vector);
        }

        public static bool operator ==(Point2D point, Point2D point2)
        {
            return point.Equals(point2);
        }

        public static bool operator !=(Point2D point, Point2D point2)
        {
            return point.Equals(point2);
        }

        #endregion

    }
}
