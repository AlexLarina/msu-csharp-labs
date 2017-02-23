using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    public class ComplexFunctional
    {
        private double Re, Im;        
        // конструктор, создающий комплексное число по вещественной и мнимой части
        public ComplexFunctional(double Re, double Im)
            {
            this.Re = Re;
            this.Im = Im;
            //Console.WriteLine("Complex number = " + Re + " + " + Im + "i.");
            }
        // метод, создающий комплексное число по модулю и аргументу 
        public static ComplexFunctional AbsandArgCreate(float Abs, float Arg)
        {
            ComplexFunctional c = new ComplexFunctional(0,0);
            c.Re = Abs/(Math.Sqrt(1 + Math.Pow(2.0, Math.Tan(Arg))));
            c.Im = (Abs*Math.Tan(Arg))/ (Math.Sqrt(1 + Math.Pow(2.0, Math.Tan(Arg))));
            return c;
        }
        // свойства для получения реальной и мнимой частей
        public double Real
        {
            get { return Re;  }
            set
            {
                Re = value;
                Console.WriteLine("Real part of complex numbr is set.");
            }
        }
        public double Imaginary
        {
            get { return Im; }
            set
            {
                Im = value;
                Console.WriteLine("Imaginary part of complex numbr is set.");
            }
        }
        //свойство, возвращающее значение модуля и аргумента
        public double ComplexAbs
        {
            get
            {
                return Math.Sqrt(Math.Pow(2.0, Re) + Math.Pow(2.0, Im));
            }
        }

        public double ComplexArg
        {
            get
            {
                return Math.Atan(Re/Im);
            }
        }
        // переопределение операторов
        public static ComplexFunctional operator +(ComplexFunctional num1, ComplexFunctional num2)
        {
            return new ComplexFunctional(num1.Re + num2.Re, num1.Im + num2.Im);
        }

        public static ComplexFunctional operator -(ComplexFunctional num1, ComplexFunctional num2)
        {
            return new ComplexFunctional(num1.Re - num2.Re, num1.Im - num2.Im);
        }

        public static ComplexFunctional operator *(ComplexFunctional num1, ComplexFunctional num2)
        {
            return new ComplexFunctional((num1.Re*num2.Re - num1.Im*num2.Im), (num1.Re*num2.Im + num1.Im*num2.Re));
        }

        public static ComplexFunctional operator /(ComplexFunctional num1, ComplexFunctional num2)
        {
            return new ComplexFunctional(((num1.Re*num2.Re + num1.Im*num2.Im)/(Math.Pow(2.0, num2.Re) + Math.Pow(2.0, num2.Im))),
                ((num1.Im * num2.Re - num1.Re * num2.Im) / (Math.Pow(2.0, num2.Re) + Math.Pow(2.0, num2.Im))));
        }

        public static bool operator ==(ComplexFunctional num1, ComplexFunctional num2)
        {
            if (object.ReferenceEquals(num1, null))
            {
                return object.ReferenceEquals(num2, null);
            }
            else return num1.Equals(num2);
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
                return Re == number.Re && Im == number.Im;
            }
            else
            {
                return false;                
            }
        }

        public override int GetHashCode()
        {
            return Re.GetHashCode() ^ Im.GetHashCode();
        }
        // преобразование типов
        public static explicit operator double(ComplexFunctional c)
        {
            return c.ComplexAbs;
        }

        public static implicit operator ComplexFunctional(int x)
        {
            return new ComplexFunctional(x, 0);
        }
        // перегрузка метода ToString
        public override string ToString()
        {
            if (Re == 0)
            {
                return String.Format("{0}i", Im);
            }
            else if (Im == 0)
            {
                return String.Format("{0}", Re);
            }
            else if (Im > 0)
            {
                return String.Format("{0} + {1}i", Re, Im);
            }
            else
            {
                return String.Format("{0} - {1}i", Re, Im);
            }
        }
    }
}
