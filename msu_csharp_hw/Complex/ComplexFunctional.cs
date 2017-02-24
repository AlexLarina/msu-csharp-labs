using System;

namespace Complex
{
    public class ComplexFunctional
    {
        // @Serge
        // 1) Use empty lines to separate class parts
        // 2) Don't forget about space after comma
        // 3) Prefer using this.* when refer to private field
        // 4) Lazy initialization is quite suitable for Abs and Arg
        // 5) Name private fields and parameters with camelCase
        //    @see https://msdn.microsoft.com/en-us/library/ms229002(v=vs.110).aspx
        //    @see http://10rem.net/articles/net-naming-conventions-and-programming-standards---best-practices
        
        private double re, im;
        private double abs, arg;

        private void clearAbsArg()
        {
            this.abs = this.arg = double.NaN;
        }

        // конструктор, создающий комплексное число по вещественной и мнимой части
        public ComplexFunctional(double re, double im)
        {
            this.re = re;
            this.im = im;
            clearAbsArg();
            //Console.WriteLine("Complex number = " + Re + " + " + Im + "i.");
        }

        // метод, создающий комплексное число по модулю и аргументу
        // @Serge Place verb at first in method name
        public static ComplexFunctional CreateByAbsArg(double abs, double arg)
        {
            ComplexFunctional c = new ComplexFunctional(0, 0);
            c.re = abs/(Math.Sqrt(1 + Math.Pow(Math.Tan(arg), 2.0)));
            c.im = abs*Math.Tan(arg)/(Math.Sqrt(1 + Math.Pow(Math.Tan(arg), 2.0)));
            return c;
        }

        // свойства для получения реальной и мнимой частей
        public double Re
        {
            get { return this.re; }
            set
            {
                this.re = value;
                clearAbsArg();
                Console.WriteLine("Real part of complex numbr is set.");
            }
        }

        public double Im
        {
            get { return this.im; }
            set
            {
                this.im = value;
                clearAbsArg();
                Console.WriteLine("Imaginary part of complex numbr is set.");
            }
        }

        //свойство, возвращающее значение модуля и аргумента
        // @Serge No need to duplicate class name part (use Abs instead of ComplexAbs)
        public double Abs
        {
            get
            {
                if (!double.IsNaN(this.abs))
                {
                    return this.abs;
                }
                return this.abs = Math.Sqrt(Math.Pow(this.re, 2.0) + Math.Pow(this.im, 2.0));
            }
        }

        public double Arg
        {
            get
            {
                if (!double.IsNaN(this.arg))
                {
                    return this.arg;
                }
                return this.arg = Math.Atan(this.re / this.im);
            }
        }

        // переопределение операторов
        public static ComplexFunctional operator +(ComplexFunctional num1, ComplexFunctional num2)
        {
            return new ComplexFunctional(num1.re + num2.re, num1.im + num2.im);
        }

        public static ComplexFunctional operator -(ComplexFunctional num1, ComplexFunctional num2)
        {
            return new ComplexFunctional(num1.re - num2.re, num1.im - num2.im);
        }

        public static ComplexFunctional operator *(ComplexFunctional num1, ComplexFunctional num2)
        {
            return new ComplexFunctional((num1.re*num2.re - num1.im*num2.im), (num1.re*num2.im + num1.im*num2.re));
        }

        public static ComplexFunctional operator /(ComplexFunctional num1, ComplexFunctional num2)
        {
            // @Serge You can place the first parameter at new line
            // @Serge Avoid copy-paste math expressions
            double divisor = Math.Pow(num2.re, 2.0) + Math.Pow(num2.im, 2.0);
            return new ComplexFunctional(
                (num1.re*num2.re + num1.im*num2.im)/divisor,
                (num1.im*num2.re - num1.re*num2.im)/divisor);
        }

        public static bool operator ==(ComplexFunctional num1, ComplexFunctional num2)
        {
            if (object.ReferenceEquals(num1, null))
            {
                return object.ReferenceEquals(num2, null);
            }
            return num1.Equals(num2);
        }

        public static bool operator !=(ComplexFunctional num1, ComplexFunctional num2)
        {
            return !(num1 == num2);
        }

        public override bool Equals(object obj)
        {
            if (obj is ComplexFunctional)
            {
                ComplexFunctional number = (ComplexFunctional)obj;
                return this.re == number.re && this.im == number.im;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.re.GetHashCode() ^ this.im.GetHashCode();
        }

        // преобразование типов
        public static explicit operator double(ComplexFunctional c)
        {
            return c.Abs;
        }

        public static implicit operator ComplexFunctional(double x)
        {
            return new ComplexFunctional(x, 0);
        }

        // перегрузка метода ToString
        public override string ToString()
        {
            if (this.re == 0)
            {
                return String.Format("{0}i", this.im);
            }
            if (this.im == 0)
            {
                return String.Format("{0}", this.re);
            }
            if (this.im > 0)
            {
                return String.Format("{0} + {1}i", this.re, this.im);
            }
            return String.Format("{0} - {1}i", this.re, -this.im);
        }
    }
}
