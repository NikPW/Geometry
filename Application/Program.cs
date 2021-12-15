using System;
using Geometry;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Point2D p1 = new Point2D(3, 5);
            Point2D p2 = new Point2D(7, 3);

            Rectangle r0 = new Rectangle(new Point2D(3, 5), new Point2D(7, 3));
            Triangle t0 = new Triangle(new Point2D(3, 7), new Point2D(6, 12), new Point2D(9, 7));
            Ellipse e0 = new Ellipse(p1, 10, 15);
            Circle c0 = new Circle(new Point2D(2, 12), new Point2D(4, 12));


            Shape[] shapes = new Shape[4];
            shapes[0] = r0;
            shapes[1] = t0;
            shapes[2] = e0;
            shapes[3] = c0;


            foreach (Shape s in shapes)
            {
                Console.WriteLine(s.toString + '\n');
            }



            Console.WriteLine(Segment.SegmentLength(new Point2D(3, 7), new Point2D(6, 12)));

            Console.WriteLine(Segment.SegmentLength(new Point2D(9, 7), new Point2D(6, 12)));

            Console.WriteLine(Segment.SegmentLength(new Point2D(3, 7), new Point2D(9, 7)));



        }



    }

}
