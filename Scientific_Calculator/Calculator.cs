using System;
using System.Collections;
using System.Collections.Generic;

namespace Scientific_Calculator
{
    public class Calculator
    {
        //수학 함수 클래스
        MathFunc Math = new MathFunc();

        //후위 변환식을 위한 연산자 저장
        Stack<char> stack = new Stack<char>();

        //콘솔 계산식을 위한 저장
        List<string> calculate = new List<string>();

        //결과 값
        double Result=0;

        //실수인지 판별을 위한 TryParse 변수
        double value;
        bool isValue;

        //현재 .[34] 함수 입력중
        bool nowDot;

        //함수 입력중
        bool nowFunc;
        string temp;

        //연산자 입력중
        bool nowOper;

        //입력수
        int inputN;

        //계산기 상태
        bool isC;
        public bool isSecondMode = false;

        public Calculator(){}

        //세컨드모드 인지

        //기본 UI CE
        public void BasicUI()
        {
            //계산중인 식출력 오른쪽 정렬
            //결과값 오른쪽 정렬

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}","secondMode[10]");
            Console.Write("|");
            Console.Write("{0,15}", "π[11]");
            Console.Write("|");
            Console.Write("{0,15}", "e[12]");
            Console.Write("|");
            Console.Write("{0,15}", "CE[13]");
            Console.Write("|");
            Console.Write("{0,15}", "<<[14]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "sqr(x)[15]");
            Console.Write("|");
            Console.Write("{0,15}", "1/x[16]");
            Console.Write("|");
            Console.Write("{0,15}", "abs(x)[17]");
            Console.Write("|");
            Console.Write("{0,15}", "exp[18]");
            Console.Write("|");
            Console.Write("{0,15}", "mod[19]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "sqrt(x)[20]");
            Console.Write("|");
            Console.Write("{0,15}", "([21]");
            Console.Write("|");
            Console.Write("{0,15}", ")[22]");
            Console.Write("|");
            Console.Write("{0,15}", "n![23]");
            Console.Write("|");
            Console.Write("{0,15}", "/[24]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "^[25]");
            Console.Write("|");
            Console.Write("{0,15}", "7");
            Console.Write("|");
            Console.Write("{0,15}", "8");
            Console.Write("|");
            Console.Write("{0,15}", "9");
            Console.Write("|");
            Console.Write("{0,15}", "*[26]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "10^[27]");
            Console.Write("|");
            Console.Write("{0,15}", "4");
            Console.Write("|");
            Console.Write("{0,15}", "5");
            Console.Write("|");
            Console.Write("{0,15}", "6");
            Console.Write("|");
            Console.Write("{0,15}", "-[28]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "log[29]");
            Console.Write("|");
            Console.Write("{0,15}", "1");
            Console.Write("|");
            Console.Write("{0,15}", "2");
            Console.Write("|");
            Console.Write("{0,15}", "3");
            Console.Write("|");
            Console.Write("{0,15}", "+[30]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "ln[31]");
            Console.Write("|");
            Console.Write("{0,15}", "+/-[32]");
            Console.Write("|");
            Console.Write("{0,15}", "0");
            Console.Write("|");
            Console.Write("{0,15}", ".[34]");
            Console.Write("|");
            Console.Write("{0,15}", "=[35]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        //기본C UI C
        public void BasicCUI()
        {
            //계산중인 식출력 오른쪽 정렬
            //결과값 오른쪽 정렬

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "secondMode[10]");
            Console.Write("|");
            Console.Write("{0,15}", "π[11]");
            Console.Write("|");
            Console.Write("{0,15}", "e[12]");
            Console.Write("|");
            Console.Write("{0,15}", "C[13]");
            Console.Write("|");
            Console.Write("{0,15}", "<<[14]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "sqr(x)[15]");
            Console.Write("|");
            Console.Write("{0,15}", "1/x[16]");
            Console.Write("|");
            Console.Write("{0,15}", "abs(x)[17]");
            Console.Write("|");
            Console.Write("{0,15}", "exp[18]");
            Console.Write("|");
            Console.Write("{0,15}", "mod[19]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "sqrt(x)[20]");
            Console.Write("|");
            Console.Write("{0,15}", "([21]");
            Console.Write("|");
            Console.Write("{0,15}", ")[22]");
            Console.Write("|");
            Console.Write("{0,15}", "n![23]");
            Console.Write("|");
            Console.Write("{0,15}", "/[24]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "^[25]");
            Console.Write("|");
            Console.Write("{0,15}", "7");
            Console.Write("|");
            Console.Write("{0,15}", "8");
            Console.Write("|");
            Console.Write("{0,15}", "9");
            Console.Write("|");
            Console.Write("{0,15}", "*[26]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "10^[27]");
            Console.Write("|");
            Console.Write("{0,15}", "4");
            Console.Write("|");
            Console.Write("{0,15}", "5");
            Console.Write("|");
            Console.Write("{0,15}", "6");
            Console.Write("|");
            Console.Write("{0,15}", "-[28]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "log[29]");
            Console.Write("|");
            Console.Write("{0,15}", "1");
            Console.Write("|");
            Console.Write("{0,15}", "2");
            Console.Write("|");
            Console.Write("{0,15}", "3");
            Console.Write("|");
            Console.Write("{0,15}", "+[30]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "ln[31]");
            Console.Write("|");
            Console.Write("{0,15}", "+/-[32]");
            Console.Write("|");
            Console.Write("{0,15}", "0");
            Console.Write("|");
            Console.Write("{0,15}", ".[34]");
            Console.Write("|");
            Console.Write("{0,15}", "=[35]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        //세컨드모드 UI CE
        public void SecondModeUI()
        {
            //계산중인 식출력 오른쪽 정렬
            //결과값 오른쪽 정렬

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "secondMode[10]");
            Console.Write("|");
            Console.Write("{0,15}", "π[11]");
            Console.Write("|");
            Console.Write("{0,15}", "e[12]");
            Console.Write("|");
            Console.Write("{0,15}", "CE[13]");
            Console.Write("|");
            Console.Write("{0,15}", "<<[14]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "cube(x)[15]");
            Console.Write("|");
            Console.Write("{0,15}", "1/x[16]");
            Console.Write("|");
            Console.Write("{0,15}", "abs(x)[17]");
            Console.Write("|");
            Console.Write("{0,15}", "exp[18]");
            Console.Write("|");
            Console.Write("{0,15}", "mod[19]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "cuberoot(x)[20]");
            Console.Write("|");
            Console.Write("{0,15}", "([21]");
            Console.Write("|");
            Console.Write("{0,15}", ")[22]");
            Console.Write("|");
            Console.Write("{0,15}", "n![23]");
            Console.Write("|");
            Console.Write("{0,15}", "/[24]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "yroot[25]");
            Console.Write("|");
            Console.Write("{0,15}", "7");
            Console.Write("|");
            Console.Write("{0,15}", "8");
            Console.Write("|");
            Console.Write("{0,15}", "9");
            Console.Write("|");
            Console.Write("{0,15}", "*[26]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "2^[27]");
            Console.Write("|");
            Console.Write("{0,15}", "4");
            Console.Write("|");
            Console.Write("{0,15}", "5");
            Console.Write("|");
            Console.Write("{0,15}", "6");
            Console.Write("|");
            Console.Write("{0,15}", "-[28]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "LogyX[29]");
            Console.Write("|");
            Console.Write("{0,15}", "1");
            Console.Write("|");
            Console.Write("{0,15}", "2");
            Console.Write("|");
            Console.Write("{0,15}", "3");
            Console.Write("|");
            Console.Write("{0,15}", "+[30]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "e^[31]");
            Console.Write("|");
            Console.Write("{0,15}", "+/-[32]");
            Console.Write("|");
            Console.Write("{0,15}", "0");
            Console.Write("|");
            Console.Write("{0,15}", ".[34]");
            Console.Write("|");
            Console.Write("{0,15}", "=[35]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        //세컨드모드 UI C
        public void SecondModeCUI()
        {
            //계산중인 식출력 오른쪽 정렬
            //결과값 오른쪽 정렬

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "secondMode[10]");
            Console.Write("|");
            Console.Write("{0,15}", "π[11]");
            Console.Write("|");
            Console.Write("{0,15}", "e[12]");
            Console.Write("|");
            Console.Write("{0,15}", "C[13]");
            Console.Write("|");
            Console.Write("{0,15}", "<<[14]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "cube(x)[15]");
            Console.Write("|");
            Console.Write("{0,15}", "1/x[16]");
            Console.Write("|");
            Console.Write("{0,15}", "abs(x)[17]");
            Console.Write("|");
            Console.Write("{0,15}", "exp[18]");
            Console.Write("|");
            Console.Write("{0,15}", "mod[19]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "cuberoot(x)[20]");
            Console.Write("|");
            Console.Write("{0,15}", "([21]");
            Console.Write("|");
            Console.Write("{0,15}", ")[22]");
            Console.Write("|");
            Console.Write("{0,15}", "n![23]");
            Console.Write("|");
            Console.Write("{0,15}", "/[24]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "yroot[25]");
            Console.Write("|");
            Console.Write("{0,15}", "7");
            Console.Write("|");
            Console.Write("{0,15}", "8");
            Console.Write("|");
            Console.Write("{0,15}", "9");
            Console.Write("|");
            Console.Write("{0,15}", "*[26]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "2^[27]");
            Console.Write("|");
            Console.Write("{0,15}", "4");
            Console.Write("|");
            Console.Write("{0,15}", "5");
            Console.Write("|");
            Console.Write("{0,15}", "6");
            Console.Write("|");
            Console.Write("{0,15}", "-[28]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "LogyX[29]");
            Console.Write("|");
            Console.Write("{0,15}", "1");
            Console.Write("|");
            Console.Write("{0,15}", "2");
            Console.Write("|");
            Console.Write("{0,15}", "3");
            Console.Write("|");
            Console.Write("{0,15}", "+[30]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();

            Console.Write("|");
            Console.Write("{0,15}", "e^[31]");
            Console.Write("|");
            Console.Write("{0,15}", "+/-[32]");
            Console.Write("|");
            Console.Write("{0,15}", "0");
            Console.Write("|");
            Console.Write("{0,15}", ".[34]");
            Console.Write("|");
            Console.Write("{0,15}", "=[35]");
            Console.Write("|");

            Console.WriteLine();
            Console.Write("---------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        //[34] 함수 중 일떄
        public void NowIsDot(int num)
        {
            if (nowDot)
            {
                isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                if (isValue)
                {
                    calculate.RemoveAt(calculate.Count - 1);
                    calculate.Add(value + "." + num);
                    nowDot = false;
                }
            }
        }

        //수 모으기
        public void GatherNum(int num)
        {
            nowOper = false;

            if (!nowDot)
            {
                if (calculate.Count != 0)
                {
                    //앞 인덱스가 상수 라면
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add(value.ToString() + num);
                        nowDot = false;
                    }
                    else if(!nowFunc)
                        calculate.Add(num.ToString());

                    //함수 입력중일 때
                    else if (nowFunc)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add(value.ToString() + num);
                    }
                }
                else
                {
                    calculate.Add(num.ToString());
                }
                nowFunc = false;
            }
            nowFunc = false;
        }

        //함수 입력
        public void FuncInput(string funcName)
        {
            //전 인덱스가 함수가 아닐 때
            if (!nowFunc)
            {
                if (calculate.Count == 0 || nowOper)
                {
                    if (funcName == "ln")
                    {
                        Console.WriteLine("입력이 잘못되었습니다.");
                    }
                    else
                    {
                        calculate.Add(funcName + "(" + 0 + ")");
                        nowFunc = true;
                    }
                }
                else
                {
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add(funcName + "(" + value + ")");
                    }
                }
            }
            //함수 입력 중이라면
            else
            {
                temp = calculate[calculate.Count - 1];
                calculate.RemoveAt(calculate.Count - 1);
                calculate.Add(funcName + "(" + temp + ")");
                nowFunc = true;
            }
        }

        //입력
        public void InputNum()
        {
            Console.Write("{0,75}","입력 :");

            inputN = int.Parse(Console.ReadLine());

            switch(inputN)
            {
                case 1:   
                    nowOper = false;
                    GatherNum(1);
                    NowIsDot(1);
                    break;
                case 2:
                    nowOper = false;
                    GatherNum(2);
                    NowIsDot(2);
                    break;
                case 3:
                    nowOper = false;
                    GatherNum(3);
                    NowIsDot(3);
                    break;
                case 4:
                    nowOper = false;
                    GatherNum(4);
                    NowIsDot(4);
                    break;
                case 5:
                    nowOper = false;
                    GatherNum(5);
                    NowIsDot(5);
                    break;
                case 6:
                    nowOper = false;
                    GatherNum(6);
                    NowIsDot(6);
                    break;
                case 7:
                    nowOper = false;
                    GatherNum(7);
                    NowIsDot(7);
                    break;
                case 8:
                    nowOper = false;
                    GatherNum(8);
                    NowIsDot(8);
                    break;
                case 9:
                    nowOper = false;
                    GatherNum(9);
                    NowIsDot(9);
                    break;
                case 0:
                    nowOper = false;
                    GatherNum(0);
                    NowIsDot(0);
                    break;

                case 10:
                    isSecondMode = true;
                    nowOper = false;
                    break;

                // π
                case 11:
                    calculate.Add("π");
                    break;

                // e
                case 12:
                    calculate.Add("e");
                    break;

                // CE C
                case 13:
                    if (!isC)
                        calculate.Clear();
                    else
                        stack.Clear();

                    break;

                // <<
                case 14:
                    calculate.RemoveAt(calculate.Count - 1);
                    break;

                // sqr , cube
                case 15:
                    if (!isSecondMode)
                        FuncInput("sqr");
                    else
                    {
                        FuncInput("cube");
                        isSecondMode = false;
                    }
                    nowFunc = true;
                    break;

                // 1/x
                case 16:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add("1/(" + value + ")");
                    }
                    break;

                // abs
                case 17:
                    FuncInput("abs");
                    nowFunc = true;
                    break;

                // Exp 
                case 18:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);
            
                    if (isValue)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add(value + ".e+");
                        calculate.Add("0");
                    }
                    break;

                // mod
                case 19:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.Add("mod");
                    }
                    break;

                // sqrt , cuberoot
                case 20:
                    if (!isSecondMode)
                        FuncInput("sqrt");
                    else
                    {
                        FuncInput("cuberoot");
                        isSecondMode = false;
                    }
                    nowFunc = true;
                    break;


                // (
                case 21:
                    stack.Push('(');
                    calculate.Add("("); break;

                // )
                case 22:
                    while (!stack.Peek().Equals('('))
                    { Console.WriteLine(stack.Peek()); stack.Pop(); }
                    break;
                    // 마지막 남아있는 '(' 제거  
                    stack.Pop();
                    calculate.Add(")");
                    break;

                // factorial
                case 23:
                    FuncInput("fact");
                    nowFunc = true;
                    break;

                // 나누기 /
                case 24:
                    while (stack.Count != 0)
                    {
                        if (stack.Peek().Equals('(')) { break; }
                        else if (stack.Peek().Equals('*') || stack.Peek().Equals('/'))
                        {
                            Console.WriteLine(stack.Peek()); stack.Pop();
                        }
                        else { break; }
                    }
                    stack.Push('/');
                    calculate.Add("/");
                    nowOper = true;
                    break;

                // ^ , yroot
                case 25:
                    if (!isSecondMode)
                    {
                        isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                        if (isValue)
                        {
                            calculate.Add("^");
                        }
                    }
                    else
                    {
                        calculate.Add("yroot");
                        isSecondMode = false;
                    }
                    break;

                // *
                case 26:
                    while (stack.Count != 0)
                    {
                        if (stack.Peek().Equals('(')) { break; }
                        else if (stack.Peek().Equals('*') || stack.Peek().Equals('/'))
                        {
                            Console.WriteLine(stack.Peek()); stack.Pop();
                        }
                        else { break; }
                    }
                    stack.Push('*');
                    calculate.Add("*");
                    nowOper = true;
                    break;

                // 10^ ,2^
                case 27:
                    if (!isSecondMode)
                    {
                        isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                        if (isValue)
                        {
                            calculate.RemoveAt(calculate.Count - 1);
                            calculate.Add("10^(" + value + ")");
                        }
                    }
                    else
                    {
                        isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                        if (isValue)
                        {
                            calculate.RemoveAt(calculate.Count - 1);
                            calculate.Add("2^(" + value + ")");
                        }
                        isSecondMode = false;
                    }
                    break;

                // -
                case 28:
                    while (stack.Count != 0)
                    {
                        if (stack.Peek().Equals('(')) { break; }
                        else { Console.WriteLine(stack.Peek()); stack.Pop(); }
                    }
                    stack.Push('-');
                    calculate.Add("-");
                    nowOper = true;
                    break;

                // log, log base
                case 29:
                    if(!isSecondMode)
                        FuncInput("log");
                    else
                    {
                        calculate.Add("log base");
                        isSecondMode = false;
                    }
                    break;

                // +
                case 30:
                    while (stack.Count != 0)
                    {
                        if (stack.Peek().Equals('(')) { break; }
                        else { Console.WriteLine(stack.Peek()); stack.Pop(); }
                    }
                    stack.Push('+');
                    calculate.Add("+");
                    nowOper = true;
                    break;

                // ln, e^
                case 31:
                    if (!isSecondMode)
                    {
                        FuncInput("ln");

                    }
                    else
                    {
                        FuncInput("e^");
                        isSecondMode = false;
                    }
                    break;

                // +-
                case 32:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        value = value / -1;
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add("("+value+")");
                    }
                    break;

                // .
                case 34:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.RemoveAt(calculate.Count - 1);
                        calculate.Add(value+".");
                        nowDot = true;
                    }
                    break;

                // =
                case 35:
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        // = 구현 
                    }
                    break;
            }
        }

        public void Print()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine();
            for (int i = 0; i < calculate.Count; i++)
            {
                Console.Write(calculate[i]);
                Console.Write(" ");
            }
        }
    }
}

