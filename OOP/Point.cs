using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        //double x;
        //double y;

        ////Properties^
        //public double X
        //{
        //    get { return x; }
        //    set { x = value; }
        //}
        //public double Y
        //{
        //    get { return y; }
        //    set { y = value; }
        //}

        ////Get/Set:
        //public double GetX()
        //{
        //    return x;
        //}
        //public double GetY()
        //{
        //    return y;
        //}
        //public void SetX(double x)
        //{
        //    this.x = x;
        //}
        //public void SetY(double y)
        //{
        //    this.y = y;
        //}

        //      Methods
        public void Print()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
            //Console.WriteLine($"X = {GetX()}, Y = {GetY()}");
        }

        public double Distance(Point other)
        {
            return Math.Sqrt(Math.Pow(this.X - other.X, 2)+ Math.Pow(this.Y - other.Y, 2));
        }
    }
}
