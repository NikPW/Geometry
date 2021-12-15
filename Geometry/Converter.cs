using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    public class Converter
    {
        public static Point2D[] Points2D(double[] array)
        {
            int length = array.Length;
            if (length < 2)
            {
                throw new Exception("Слишком короткий массив");
            }

            if (length % 2 != 0)
            {
                length--;
            }

            Point2D[] points = new Point2D[length / 2];

            for (int i = 0; i < length; i += 2)
            {
                points[(i / 2)] = new Point2D(array[i], array[i + 1]);
            }

            return points;
        }
    }
}
