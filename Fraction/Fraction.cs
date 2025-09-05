using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    internal class Fraction
    {
        public int Integer { get; set; }
        public int Numerator { get; set; }
        int denominator;

        //Properties:

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (denominator == 0) denominator = 1;
                this.denominator = value;
            }
        }

        //Constructors:
        public Fraction(int integer)
        {
            this.Integer = integer;
            this.Numerator = 0;
            this.denominator = 1;
            Console.WriteLine("Constructor:\t" + this);
        }
        public Fraction(int numerator, int denominator)
        {
            this.Integer = 0;
            this.Numerator = numerator;
            this.denominator = denominator;
            Console.WriteLine("Constructor:\t" + this);
        }
        public Fraction(int integer = 0, int numerator = 0, int denominator = 1) : this(numerator, denominator)
        {
            this.Integer = integer;
            Console.WriteLine("Constructor:\t" + this);
        }
        public Fraction(Fraction other)
        {
            this.Integer = other.Integer;
            this.Numerator = other.Numerator;
            this.denominator = other.denominator;
            Console.WriteLine("CopyConstructor:\t" + this);
        }

        //Operators:
        public static Fraction operator -(Fraction other)
        {
            other.ToImproper();
            return new Fraction(-other.Numerator, other.denominator).Reduce().ToProper();
        }
        public static Fraction operator +(Fraction leftOperand, Fraction rightOperand)
        {
            Fraction left = new Fraction(leftOperand);
            Fraction right = new Fraction(rightOperand);
            left.ToImproper();
            right.ToImproper();
            return new Fraction(left.Numerator * right.denominator + right.Numerator * left.denominator, left.denominator * right.denominator).Reduce().ToProper();
        }
        public static Fraction operator -(Fraction left, Fraction right)
        {
            return left + (-right);
        }
        public static Fraction operator *(Fraction leftOperand, Fraction rightOperand)
        {
            Fraction left = new Fraction(leftOperand);
            Fraction right = new Fraction(rightOperand);
            left.ToImproper();
            right.ToImproper();
            return new Fraction(left.Numerator * right.Numerator, left.denominator * right.denominator).Reduce().ToProper();
        }
        public static Fraction operator /(Fraction left, Fraction right)
        {
            return left * right.Inverted();
        }
        public static Fraction operator ++(Fraction other)
        {
            return new Fraction(++other.Integer, other.Numerator, other.denominator);
        }

        public static Fraction operator --(Fraction other)
        {
            return new Fraction(--other.Integer, other.Numerator, other.denominator);
        }

        //Comparison operators:
        public static bool operator ==(Fraction leftOperand, Fraction rightOperand)
        {
            Fraction left = new Fraction(leftOperand);
            Fraction right = new Fraction(rightOperand);
            left.ToImproper();
            right.ToImproper();
            return left.Numerator * right.denominator == right.Numerator * left.denominator;            
        }
        public static bool operator !=(Fraction left, Fraction right)
        {
            return !(left == right);
        }
        public static bool operator <(Fraction leftOperand, Fraction rightOperand)
        {
            Fraction left = new Fraction(leftOperand);
            Fraction right = new Fraction(rightOperand);
            left.ToImproper();
            right.ToImproper();
            return left.Numerator * right.denominator < right.Numerator * left.denominator;
        }
        public static bool operator >(Fraction leftOperand, Fraction rightOperand)
        {
            Fraction left = new Fraction(leftOperand);
            Fraction right = new Fraction(rightOperand);
            left.ToImproper();
            right.ToImproper();
            return left.Numerator * right.denominator > right.Numerator * left.denominator;
        }
        public static bool operator <=(Fraction left, Fraction right)
        {
            return !(left > right);
        }
        public static bool operator >=(Fraction left, Fraction right)
        {
            return !(left < right);
        }

        //Methods:
        public Fraction ToImproper()
        {
            Numerator += Math.Abs(Integer * denominator);
            if (Integer < 0) Numerator *= -1;
            Integer = 0;
            return this;
        }
        public Fraction ToProper()
        { 
            Integer += Numerator / denominator;
            Numerator = Math.Abs(Numerator) % denominator;
            return this;
        }
        public Fraction Inverted()
        {
            Fraction inverted = new Fraction(this);
            inverted.ToImproper();
            inverted.Numerator = denominator;
            inverted.denominator = Numerator;
            return inverted;
        }
        public Fraction Reduce()
        {
            int more = 1, less = 1, rest = 1;
            if (Numerator < denominator)
            {
                less = Numerator;
                more = denominator;
            }
            else
            {
                more = Numerator;
                less = denominator;
            }
            do
            {
                rest = more % less;
                more = less;
                less = rest;
            } while (rest != 0);
            int GCD = more;
            Numerator /= GCD;
            denominator /= GCD;
            return this;
        }
        public void Print()
        {
            this.ToProper();
            if (Integer != 0) Console.Write(Integer);
            if (Numerator != 0)
            {
                if (Integer != 0) Console.Write("(");
                Console.Write($"{Numerator}/{denominator}");
                if (Integer != 0) Console.Write(")");
            }
            else if (Integer == 0) Console.Write(0);
            Console.WriteLine();
        }
        public void ToFraction(string expression)
        {
            Fraction fromString = new Fraction();
            char[] delimiters = { '(', '/', ')' };
            if (expression.Contains('(') && expression.Contains('/') && expression.Contains(')'))
            {
                string[] operand = expression.Split(delimiters);
                this.Integer = Convert.ToInt32(operand[0]);
                this.Numerator = Convert.ToInt32(operand[1]);
                this.denominator = Convert.ToInt32(operand[2]);
            }
            else if (expression.Contains('/'))
            {
                string[] operand = expression.Split(delimiters);
                this.Numerator = Convert.ToInt32(operand[0]);
                this.denominator = Convert.ToInt32(operand[1]);
            }
            else this.Integer = Convert.ToInt32(expression);
        }
        public string ToString()
        {
            string fraction = "";
            if (Integer != 0) fraction+=Integer;
            if (Numerator != 0)
            {
                if (Integer != 0) fraction += "(";
                fraction+=$"{Numerator}/{denominator}";
                if (Integer != 0) fraction += ")";
            }
            else if (Integer == 0) fraction += "0";
            return fraction;
        }
    }
}
