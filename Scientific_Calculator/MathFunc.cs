using System;
using System.Data;
using MathNet.Numerics;

namespace Scientific_Calculator
{
    public class MathFunc
    {
        public MathFunc(){}

        //π 
        public double PI()
        {
            return Math.PI;
        }

        //자연상수 e
        public double e()
        {
            return Math.E;
        }

        //제곱값
        public double sqr(double x)
        {
            double returnV = x * x;

            return returnV;
        }

        //1/x
        public double DivideOne(double x)
        {
            double returnV;

            if (x != 0)
            {
                returnV = 1.0 / x;
                return returnV;
            }
            else
            {
                Console.WriteLine("0으로 나눌수 없습니다.");
                return 0;
            }
        }

        //절대값
        public double abs(double x)
        {
            double returnV = Math.Abs(x);

            return returnV;
        }

        //exp 보류
        public double exp(double x, double y)
        {
            double returnV =x;

            for (int i = 0; i<y;i++)
            {
                returnV *= 10;
            }

            return returnV;
        }

        //mod
        public double mod(double x, double y)
        {
            double returnV = x % y;

            return returnV;
        }

        //제곱근값
        public double sqrt(double x)
        {
            double returnV = Math.Sqrt(x);

            return returnV;
        }

        //펙토리얼
        public double fact(double x)
        {
            double returnV=1;

            if(x == 0)    
                return 0;

            //정수라면
            else if(x%1==0)
            {
                for (int i=1;i<=x;i++)
                {
                    returnV *= i;
                }
                return returnV;
            }
            //실수라면
            else
            {
                returnV = SpecialFunctions.Gamma(x+1);

                return returnV;
            }
        }

        //제곱 ^
        public double Pow(double x,double y)
        {
            double returnV = Math.Pow(x,y);

            return returnV;
        }

        //제곱 10^
        public double Pow(double x)
        {
            double returnV = Math.Pow(10, x);

            return returnV;
        }

        //로그
        public double log(double x)
        {
            double returnV = Math.Log10(x);

            return returnV;
        }

        //자연로그
        public double ln(double x)
        {
            double returnV = Math.Log(x);

            return returnV;
        }

        //세제곱
        public double cube(double x)
        {
            double returnV = x * x * x;

            return returnV;
        }

        //세제곱근
        public double cuberoot(double x)
        {
            double returnV = Math.Cbrt(x);

            return returnV;
        }

        //y루트x
        public double yroot(double x,double y)
        {
            double returnV = Math.Pow(x, 1.0 / y);

            return returnV;
        }

        //2제곱x
        public double square(double x)
        {
            double returnV = Math.Pow(2,x);

            return returnV;
        }

        //logxY
        public double logBase(double x,double y)
        {
            double returnV = Math.Log(x, y);

            return returnV;
        }

        //자연상수e 제곱
        public double eSquare(double x)
        {
            return Math.Pow(Math.E, x);
        }
    }
}

