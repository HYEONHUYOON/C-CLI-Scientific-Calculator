using System;
using System.Collections;
using System.Collections.Generic;

namespace Scientific_Calculator
{
    public class Calculator
    {
        //수학 함수 클래스
        MathFunc MathF = new MathFunc();

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

        //제곱 입력중
        bool nowCarrot;

        //입력수
        int inputN;

        //e, PI 입력중
        bool ePI;

        //계산기 상태
        bool isC;
        public bool isSecondMode = false;

        //하단
        string bottomS = "";
        double bottomD = 0;

        //Exp값
        double expDouble;
        string expDoubleS ="0";
        bool nowExp;

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
            Console.Write("{0,14}", "π[11]");
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
            Console.Write("{0,14}", "π[11]");
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
            Console.Write("{0,14}", "π[11]");
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
            Console.Write("{0,14}", "π[11]");
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
                        calculate.Add(num.ToString());
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
                //아무것도 입력 안했거나 연산자 중일 때
                if (bottomS =="" || nowOper)
                {
                    //ln 일때
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
                    //isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    //if (isValue)
                    //{
                    //    calculate.RemoveAt(calculate.Count - 1);
                    //    calculate.Add(funcName + "(" + value + ")");
                    //}
                    bottomD = double.Parse(bottomS);
                    calculate.Add(funcName + "(" + bottomD + ")");
                }
            }
            //함수 입력 중이라면
            else if(nowFunc)
            {
                temp = calculate[calculate.Count - 1];
                calculate.RemoveAt(calculate.Count - 1);
                calculate.Add(funcName + "(" + temp + ")");
                nowFunc = true;
            }
        }

        public void NumInput(string num)
        {
            if (ePI)
            {
                //calculate.RemoveAt(calculate.Count - 1);
                bottomS = num;
                //calculate.Add("1");
                ePI = false;
            }
            else if (nowExp)
            {
                if (expDoubleS == "0")
                {
                    expDoubleS = "";
                    expDoubleS += num;
                }
                else
                    expDoubleS += num;
            }
            else if (nowCarrot)
            {
                bottomS = num;
                nowCarrot = false;
            }
            else if (nowFunc)
            {
                calculate.RemoveAt(calculate.Count - 1);
                bottomS = num;
                nowCarrot = false;
            }
            else if (nowOper)
            {
                bottomS = num;
                nowOper = false;
            }
            else bottomS += num;
            //GatherNum(1);
            //NowIsDot(1);
        }

        //입력
        public void InputNum()
        {
            Console.Write("{0,75}","입력 :");

            inputN = int.Parse(Console.ReadLine());

            switch(inputN)
            {
                case 1:
                    NumInput("1");
                    break;
                case 2:
                    NumInput("2");
                    break;
                case 3:
                    NumInput("3");
                    break;
                case 4:
                    NumInput("4");
                    break;
                case 5:
                    NumInput("5");
                    break;
                case 6:
                    NumInput("6");
                    break;
                case 7:
                    NumInput("7");
                    break;
                case 8:
                    NumInput("8");
                    break;
                case 9:
                    NumInput("9");
                    break;
                case 0:
                    NumInput("0");
                    break;

                case 10:
                    isSecondMode = true;
                    nowOper = false;
                    break;

                // π
                case 11:
                    if (ePI)
                    {
                        //calculate.RemoveAt(calculate.Count - 1);
                        //calculate.Add(Math.PI.ToString());
                        bottomS = MathF.PI().ToString();

                    }
                    else
                    {
                        //calculate.Add(Math.PI.ToString());
                        bottomS = MathF.PI().ToString();
                    }
                    ePI = true;
                    break;

                // e
                case 12:
                    if (ePI)
                    {
                        //calculate.RemoveAt(calculate.Count - 1);
                        //calculate.Add(Math.E.ToString());
                        bottomS = MathF.e().ToString();
                    }
                    else
                    {
                        //calculate.Add(Math.E.ToString());
                        bottomS = MathF.e().ToString();
                    }
                    ePI = true;
                    break;

                // CE C
                case 13:
                    if (!isC)
                        bottomS = "";
                    else
                        calculate.Clear();

                    break;

                // <<
                case 14:
                    calculate.RemoveAt(calculate.Count - 1);
                    break;

                // sqr , cube
                case 15:
                    ePI = false;
                    if (!isSecondMode)
                    {
                        if(nowExp)
                        {
                            nowExp = false;
                            bottomD = MathF.sqr(MathF.exp(expDouble, int.Parse(expDoubleS)));
                            bottomS = bottomD.ToString();
                        }
                        FuncInput("sqr");   
                    }
                    else
                    {
                        FuncInput("cube");
                        bottomD = MathF.cube(double.Parse(bottomS));
                        bottomS = bottomD.ToString();
                        isSecondMode = false;
                    }
                    nowFunc = true;
                    break;

                // 1/x
                case 16:
                    ePI = false;
                    //isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if(nowFunc)
                    {

                    }
                    else if(nowOper)
                    {
                        //앞의 식 연산 한 값 1/()
                    }
                    else
                    {

                    }
                    //if (isValue)
                    //{
                    //    calculate.RemoveAt(calculate.Count - 1);
                    //    calculate.Add("1/(" + value + ")");
                    //}
                    break;

                // abs
                case 17:
                    ePI = false;
                    FuncInput("abs");
                    bottomD = MathF.abs(double.Parse(bottomS));
                    bottomS = bottomD.ToString();
                    nowFunc = true;
                    break;

                // Exp 
                case 18:
                    ePI = false;
                    //isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    //if (isValue)
                    //{
                    //    calculate.RemoveAt(calculate.Count - 1);
                    //    calculate.Add(value + ".e+");
                    //    calculate.Add("0");
                    //}

                    expDouble = double.Parse(bottomS);
                    bottomS += "e+";
                    nowExp = true;
                    break;

                // mod
                case 19:
                    ePI = false;
                    isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                    if (isValue)
                    {
                        calculate.Add("mod");
                    }
                    break;

                // sqrt , cuberoot
                case 20:
                    ePI = false;
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
                    ePI = false;
                    stack.Push('(');
                    calculate.Add("("); break;

                // )
                case 22:
                    ePI = false;
                    while (!stack.Peek().Equals('('))
                    { Console.WriteLine(stack.Peek()); stack.Pop(); }
                    break;
                    // 마지막 남아있는 '(' 제거  
                    stack.Pop();
                    calculate.Add(")");
                    break;

                // factorial
                case 23:
                    ePI = false;
                    FuncInput("fact");
                    nowFunc = true;
                    break;

                // 나누기 /
                case 24:
                    ePI = false;
                    //while (stack.Count != 0)
                    //{
                    //    if (stack.Peek().Equals('(')) { break; }
                    //    else if (stack.Peek().Equals('*') || stack.Peek().Equals('/'))
                    //    {
                    //        Console.WriteLine(stack.Peek()); stack.Pop();
                    //    }
                    //    else { break; }
                    //}
                    if (bottomS == "")
                    {
                        calculate.Add("0");
                        calculate.Add("/");
                    }
                    else if (nowFunc)
                    {
                        calculate.Add("/");
                        nowFunc = false;
                    }
                    else if(nowExp)
                    {
                        nowExp = false;
                        calculate.Add(MathF.exp(expDouble, int.Parse(expDoubleS)).ToString());
                        calculate.Add("/");
                        bottomS = MathF.exp(expDouble, int.Parse(expDoubleS)).ToString();
                    }
                    else
                    {
                        calculate.Add(bottomS);
                        calculate.Add("/");
                    }
                    nowOper = true;
                    break;

                // ^ , yroot (Carrot0
                case 25:
                    ePI = false;
                    nowFunc = false;
                    if (!isSecondMode)
                    {
                        if (!nowOper)
                        {
                            if (bottomS == "" && calculate.Count == 0)
                            {
                                //calculate.RemoveAt(calculate.Count - 1);
                                calculate.Add("0");
                                calculate.Add("^");
                            }
                            else if(nowCarrot)
                            {
                                break;
                            }
                            else
                            {
                                if (nowFunc)
                                {
                                    calculate.Add("^");
                                }
                                else
                                {
                                    //calculate.RemoveAt(calculate.Count - 1);
                                    calculate.Add(bottomS);
                                    calculate.Add("^");
                                }
                            }
                        }
                        else if(nowOper)
                        {
                            calculate.RemoveAt(calculate.Count - 1);
                            calculate.Add("^");
                        }
                    }
                    else
                    {
                        if (!nowOper)
                        {
                            if (bottomS == "" && stack.Count == 0)
                            {
                                //calculate.RemoveAt(calculate.Count - 1);
                                calculate.Add("0");
                                calculate.Add("yroot");
                            }
                            else
                            {
                                if (nowFunc)
                                {
                                    calculate.Add("^");
                                }
                                else
                                {
                                    //calculate.RemoveAt(calculate.Count - 1);
                                    calculate.Add(bottomS);
                                    calculate.Add("yroot");
                                }
                            }
                        }
                        else if (nowOper)
                        {
                            calculate.RemoveAt(calculate.Count - 1);
                            calculate.Add("^");
                        }
                        isSecondMode = false;
                    }
                    nowCarrot = true;
                    break;

                // *
                case 26:
                    ePI = false;
                    //while (stack.Count != 0)
                    //{
                    //    if (stack.Peek().Equals('(')) { break; }
                    //    else if (stack.Peek().Equals('*') || stack.Peek().Equals('/'))
                    //    {
                    //        Console.WriteLine(stack.Peek()); stack.Pop();
                    //    }
                    //    else { break; }
                    //}
                    if (bottomS == "")
                    {
                        calculate.Add("0");
                        calculate.Add("*");
                    }
                    else if (nowFunc)
                    {
                        calculate.Add("*");
                        nowFunc = false;
                    }
                    else if (nowExp)
                    {
                        nowExp = false;
                        calculate.Add(MathF.exp(expDouble, int.Parse(expDoubleS)).ToString());
                        calculate.Add("*");
                        bottomS = MathF.exp(expDouble, int.Parse(expDoubleS)).ToString();
                    }
                    else
                    {
                        calculate.Add(bottomS);
                        calculate.Add("*");
                    }
                    nowOper = true;
                    break;

                // 10^ ,2^
                case 27:
                    ePI = false;
                    if (!isSecondMode)
                    {
                        //isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                        //if (isValue)
                        //{
                        //    calculate.RemoveAt(calculate.Count - 1);
                        //    calculate.Add("10^(" + bottomS + ")");
                        //}

                        calculate.Add("10^(" + bottomS + ")");
                        bottomD = double.Parse(bottomS);
                        bottomS = MathF.Pow(bottomD).ToString();
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
                    nowFunc = true;
                    break;

                // -
                case 28:
                    ePI = false;
                    //while (stack.Count != 0)
                    //{
                    //    if (stack.Peek().Equals('(')) { break; }
                    //    else { Console.WriteLine(stack.Peek()); stack.Pop(); }
                    //}
                    if (bottomS == "")
                    {
                        calculate.Add("0");
                        calculate.Add("-");
                    }
                    else if (nowFunc)
                    {
                        calculate.Add("-");
                        nowFunc = false;
                    }
                    else if (nowExp)
                    {
                        nowExp = false;
                        calculate.Add(MathF.exp(expDouble, int.Parse(expDoubleS)).ToString());
                        calculate.Add("-");
                        bottomS = MathF.exp(expDouble, int.Parse(expDoubleS)).ToString();
                    }
                    else
                    {
                        calculate.Add(bottomS);
                        calculate.Add("-");
                    }
                    nowOper = true;
                    break;

                // log, log base
                case 29:
                    ePI = false;
                    if (!isSecondMode)
                        FuncInput("log");
                    else
                    {
                        calculate.Add("log base");
                        isSecondMode = false;
                    }
                    break;

                // +
                case 30:
                    ePI = false;
                    //while (stack.Count != 0)
                    //{
                    //    if (stack.Peek().Equals('(')) { break; }
                    //    else { Console.WriteLine(stack.Peek()); stack.Pop(); }
                    //}
                    if (bottomS == "")
                    {
                        calculate.Add("0");
                        calculate.Add("+");
                    }
                    else if(nowFunc)
                    {
                        calculate.Add("+");
                        nowFunc = false;
                    }
                    else if (nowExp)
                    {
                        nowExp = false;
                        calculate.Add(MathF.exp(expDouble, int.Parse(expDoubleS)).ToString());
                        calculate.Add("+");
                        bottomS = MathF.exp(expDouble, int.Parse(expDoubleS)).ToString();
                    }
                    else
                    {
                        calculate.Add(bottomS);
                        calculate.Add("+");
                    }
                    nowOper = true;
                    break;

                // ln, e^
                case 31:
                    ePI = false;
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

                // +/-
                case 32:
                    ePI = false;
                    if (bottomS != "")
                    {
                        //isValue = double.TryParse(calculate[calculate.Count - 1], out value);

                        bottomD = double.Parse(bottomS);
                        bottomD = bottomD / -1;
                        bottomS = bottomD.ToString();

                        //value = value / -1;
                        //calculate.RemoveAt(calculate.Count - 1);
                        //calculate.Add("(" + value + ")");

                        FuncInput("negate");
                    }
                    else
                    {
                        value = 0;
                        FuncInput("negate");
                    }
                    nowFunc = true;
                    break;

                // .
                case 34:
                    ePI = false;
                    bottomD = double.Parse(bottomS);

                    if (nowFunc)
                    {
                        bottomS = "0.";
                    }
                    else
                    {
                        //decimal 인지
                        if (!((bottomD % 1) > 0))
                        {
                            bottomS += ".";
                        }
                    }
                    //if (isValue)
                    //{
                    //    calculate.RemoveAt(calculate.Count - 1);
                    //    calculate.Add(value+".");
                    //    nowDot = true;
                    //}
                    break;

                // =
                case 35:
                    ePI = false;
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
            Console.WriteLine();
            if(nowExp)
            {
                Console.Write(bottomS);
                Console.WriteLine(expDoubleS);
            }
            else
            Console.WriteLine(bottomS);
        }
    }
}

