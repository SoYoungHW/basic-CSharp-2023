using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cs12_methods
{
    class Calculator
    {
        public static int Plus(int a, int b)
        {
            return a + b;
        }
        // static(정적) - 프로그램 최초 실행되자마자 메모리 바로 올라가서 끝날때 까지 존재
        // 실행되면 언제든지 접근가능
        public int Sub(int a, int b)
        {
            return a - b; 
        }
    }
    internal class Program
    {
        /// <summary>
        /// 실행시 메모리에 최초 올라가야하기때문에 static이 되어야하고
        /// 메서드 이름이 Main이면 실행될때 알아서 제일 처음에 시작된다.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) // 메인함수는 static(메인내에서 함수를 만들어도 static으로 해야)
            // args 여러값을 받아서 처리가능
        {
            #region < static 메서드 >
            int result = Calculator.Plus(1, 2);
            Console.WriteLine(result);
            // new를 안하는 이유 static
            // 클래스의 객체를 만들 필요가 없음
            // static 없으면 int result = new Calculator().Plus(1, 2);

            int result2 = new Calculator().Sub(1, 2);
            Console.WriteLine(result2);
            // Sub 클래스에 static이 없기때문에 바로 접근불가
            // 객체를 생성해야 접근가능
            #endregion

            #region <Call by reference, Call by value 비교 >
            int x = 10; int y = 3;
            Swap(ref x, ref y);
            Console.WriteLine("x = {0}, y = {1}", x, y);
            // 값 안바뀜(ref없으면)
            // x, y랑 a, b와는 완전 별개(call by value)
            // ref -> x, y가 가지고 있는 주소를 전달하라(call by reference == pointer)
            // C#과 Java에는 pointer 없음

            Console.WriteLine(GetNumber());
            #endregion

            #region < out 매개변수 >

            int divid = 10;
            int divor = 3;

            int rem = 0;

            Divide(divid, divor, out result, out rem );
            Console.WriteLine("나누기값 = {0}, 나머지값 = {1}", result, rem);

            (result, rem) = Divide(17, 4);
            Console.WriteLine("나누기값 = {0}, 나머지값 = {1}", result, rem);

            #endregion

            #region < 가변길이 매개변수 >
            Console.WriteLine(Sum(1, 3, 5, 7, 9));

            #endregion
        }

        // Main 메서드와 같은 레벨에 있는 메서드들은 전부 static이 되어야함(무조건!)
        public static void Swap(ref int a, ref int b)
        {
            int temp = 0;
            temp = a; // temp = 5
            a = b; // a = 4
            b = temp;  // b = temp = 5
        }

        // 단일포인터 = 배열 비슷
        // 2중포인터 = 2차원 배열 비슷
        // 3중포인터 / 3차원 배열 비슷

        static int val = 100;
        public static ref int GetNumber()
        {
            return ref val; // static 메서드에 접근할 수 있는 변수는 static밖에 없음
        }

        /* static int Divide(int x, int y)
        {
             return x / y;
        }
        static int Reminder(int x, int y)
        {
             return x % y;
        } */

        static void Divide(int x, int y, out int val, out int rem) // ref보다 out 권장
        {
            val = x / y;
            rem = x % y;
        }
        static (int result, int rem) Divide(int x, int y)
         {
             return (x / y, x % y); // 튜플
         } // 오버로딩

        public static int Sum(params int[] args) // Python 가변길이 매개변수랑 비교
        {
            int sum = 0;

            foreach (int item in args)
            {
                sum += item;
            }
            return sum;
        }
    }
}
