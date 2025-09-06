using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction_class
{
    internal class Fraction
    {
        public int Integer { get; set; }
        public int Numerator { get; set; }
        int denominator;            //smallCamel        //переменная-член класса (поле класса)
        public int Denominator      //BigCamel          //свойство (property)
        {
            get => denominator;
            /*get
            {
                return denominator;
            }*/
            set => denominator = value == 0 ? 1 : value;
            /*set
            {
                denominator = value == 0 ? 1 : value;
                //if (value != 0) denominator = value;
                //else denominator = 1;
            }*/
        }

        //Constructors:
        public Fraction()
        {
            Console.WriteLine($"DefaultConstructor:\t\t {this.GetHashCode().ToString("X")}");
        }
        public Fraction (int Integer)
        {
            this.Integer = Integer;
            this.Denominator = 1;
            Console.WriteLine($"SingleArgumentConstructor:\t {GetHashCode().ToString("X")}");
        }
        public Fraction(int Numerator, int Denominator)
        {
            this.Numerator = Numerator;
            this.Denominator = Denominator;
            Console.WriteLine($"Costructor:\t\t\t {GetHashCode().ToString("X")}");
        }
        public Fraction(int Integer, int Numerator, int Denominator)
        {
            this.Integer=Integer;
            this.Numerator = Numerator;
            this.Denominator = Denominator;
            Console.WriteLine($"Costructor:\t\t\t {GetHashCode().ToString("X")}");
        }
        public Fraction (Fraction other)
        {
            this.Integer = other.Integer;
            this.Numerator=other.Numerator;
            this.Denominator=other.Denominator;
            Console.WriteLine($"CopyCostructor:\t\t\t {GetHashCode().ToString("X")}");
        }
        ~Fraction()
        {
            Console.WriteLine($"Destructor:\t\t\t {this.GetHashCode().ToString("X")}");
        }

        //Operators:
        public static Fraction operator *(Fraction left, Fraction right) => 
            new Fraction
                (
                left.ToImproper().Numerator * right.ToImproper().Numerator,
                left.denominator * right.denominator
                ).ToProper().Reduced();
        /*{
            Fraction l_buffer = new Fraction(left);
            Fraction r_buffer = new Fraction(right);
            l_buffer.ToImproper();
            r_buffer.ToImproper();
            return new Fraction
                (
                l_buffer.Numerator* r_buffer.Numerator,
                l_buffer.Denominator* r_buffer.Denominator
                ).ToProper();
        }*/
        public static Fraction operator /(Fraction left, Fraction right) => left * right.Inverted();

        //Methods
        public Fraction ToImproper() => new Fraction(Numerator + Integer * Denominator, Denominator);
        /*{
            return new Fraction(Numerator + Integer * Denominator, Denominator);
            //Fraction improper = new Fraction(this);
            //improper.Numerator += Integer * Denominator;
            //improper.Integer = 0;
            //return improper;
        }*/
        public Fraction ToProper() => new Fraction(Numerator / Denominator, Numerator %= Denominator, Denominator);
        /*{
            return new Fraction(Numerator / Denominator, Numerator %= Denominator, Denominator);
            //proper.Integer += Numerator / Denominator;
            //proper.Numerator %= Denominator;
            //if (Numerator < 0) proper.Numerator *= -1;
            //return proper;
        }*/
        public Fraction Inverted() => new Fraction(Denominator, ToImproper().Numerator);
        /*{
            Fraction inverted = ToImproper();
            return new Fraction
                (
                inverted.Denominator, inverted.Numerator
                );
        }*/
        public Fraction Reduced() => new Fraction(Integer, Numerator / GCD(), Denominator/GCD());
        public int GCD() => Convert.ToInt32(System.Numerics.BigInteger.GreatestCommonDivisor(Numerator, Denominator).ToString());
        public void Print() => Console.WriteLine($"{Integer}({Numerator}/{Denominator})");
        /*{
            Console.WriteLine($"{Integer}({Numerator}/{Denominator})");
        }*/

                //Overrides:

        public override string ToString()
        {
            string @string = "";
            if (Integer != 0) @string += $"{Integer}";
            if (Numerator != 0)
            {
                if (Integer != 0) @string += "(";
                @string += $"{Numerator}/{Denominator}";
                if (Integer != 0) @string += ")";
            }
            else if (Integer == 0) @string = "0";
            return @string;
        }
    }
}
