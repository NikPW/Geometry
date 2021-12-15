using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    public class Vector2D
    {
        double x, y;

        #region Construstors
        public Vector2D()
        {

        }

        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2D(double[] array)
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

        public Vector2D(Point2D point)
        {
            x = point.X;
            y = point.Y;
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

        #endregion

        #region Methods
        public void Display()
        {
            Console.WriteLine($"Vector2D: X:{X} Y:{Y}");
        }

        public void Display(string name)
        {
            Console.WriteLine($"{name}: X:{X} Y:{Y}");
        }

        public bool IsEmpty
        {
            get { return x == 0 && y == 0; }
        }

        public double[] ToArray()
        {
            return new double[] { x, y };
        }

        public bool Equals(Vector2D vector)
        {
            return x == vector.X && y == vector.Y;
        }
        public Vector2D Add(Vector2D vector)
        {

            return new Vector2D(x += vector.X, y += vector.Y);
        }


        public Vector2D Add(double[] array)
        {
            if (array.Length < 2)
            {
                throw new Exception("Слишком короткий массив");
            }
            return new Vector2D(x += array[0], y += array[1]);
        }

        public Vector2D Add(Point2D point)
        {
            return new Vector2D(x += point.X, y += point.Y);
        }

        #endregion

        #region Static Methods
        public static Vector2D Add(Vector2D vector, double[] array)
        {
            if (array.Length < 2)
            {
                throw new Exception("Слишком короткий массив");
            }
            return new Vector2D(vector.X += array[0], vector.Y += array[1]);
        }


        public static Vector2D Add(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        public static Vector2D Add(Point2D point1, Vector2D vector)
        {
            return new Vector2D(point1.Y + vector.Y, point1.X + vector.X);
        }


        public static explicit operator Vector2D(double[] array)
        {
            if (array.Length < 2)
            {
                throw new Exception("Слишком короткий массив");
            }
            return new Vector2D(array);
        }

        public static implicit operator double[](Vector2D vector)
        {
            return vector.ToArray();
        }

        #endregion

        #region Operators
        public static Vector2D operator +(Vector2D vector, double[] array)
        {
            return Add(vector, array);
        }

        public static Vector2D operator +(Vector2D vector1, Vector2D vector2)
        {
            return Add(vector1, vector2);
        }

        public static Vector2D operator +(Vector2D vector, Point2D point1)
        {
            return Add(point1, vector);
        }

        public static bool operator ==(Vector2D vector1, Vector2D vector2)
        {
            return vector1.Equals(vector2);
        }

        public static bool operator !=(Vector2D vector1, Vector2D vector2)
        {
            return vector1.Equals(vector2);
        }


        #endregion

    }
}

