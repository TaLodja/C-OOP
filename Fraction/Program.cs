using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fraction A = new Fraction();
            Fraction B = new Fraction();
            A.ToFraction(Console.ReadLine());
            B.ToFraction(Console.ReadLine());
            ////(A*B).Print();
            //if (A > B) Console.WriteLine("1");
            //else Console.WriteLine("0");
            //if (A < B) Console.WriteLine("1");
            //else Console.WriteLine("0");
            //if (A == B) Console.WriteLine("1");
            //else Console.WriteLine("0");
            //if (A != B) Console.WriteLine("1");
            //else Console.WriteLine("0");
            Console.WriteLine($"{A.ToString()} * {B.ToString()} = {(A*B).ToString()}");
        }
    }
}
