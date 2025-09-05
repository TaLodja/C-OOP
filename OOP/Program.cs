using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Point point = new Point();
            //point.SetX(2);
            //point.SetY(3);
            //point.Print();

            //point.X = 7;
            //point.Y = 8;
            //Console.WriteLine($"Properties: X = {point.X}, Y = {point.Y}");

            Point A = new Point();
            Console.WriteLine("Введите координаты точки A, расстояние до которой требуется определить:");
            Console.Write("X = ");
            A.X = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y = ");
            A.Y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"X = {A.X}, Y = {A.Y}");
            Point B = new Point();
            B.X = 5;
            B.Y = 6;
            Console.WriteLine($"Координаты исходной точки B: X = {B.X}, Y = {B.Y}");
            Console.WriteLine($"Расстояние от исходной точки B до точки А: {B.Distance(A)}");
        }
    }
}
