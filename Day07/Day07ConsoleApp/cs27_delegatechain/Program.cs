using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs27_delegatechain
{
    delegate void ThereIsAFire(string location); // 불났을때 대신해주는 대리자

    delegate int Calc(int a, int b);

    delegate string ConCatenate(string[] agrs);
    
    class Sample
    {
        private int valueA; // 멤버변수(외부에서 접근불가)
        public int ValueA // 프로퍼티(대문자시작)
        {
            /* 일반
            get { return valueA; }
            set { valueA = value; } */

            get => ValueA;
            set => ValueA = value; // 람다식
        }
    }
    internal class Program
    {
        static string ProcComcate(string[] args)
        {
            string result = string.Empty; // ==";
            foreach (string s in args)
            {
                result += s + "/";
            }
            return result;
        }

        #region < 대리자체인 예제 >
        static void Call119(string location) 
        {
            Console.WriteLine("소방서죠? {0}에 불났어요!", location);
        }

        static void ShoutOut(string location) 
        {
            Console.WriteLine("{0}에 화재발생!", location);
        }

        static void Escape(string location) 
        {
            Console.WriteLine("{0}에서 탈출합니다", location);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--직접 사용--");
            var loc = "우리집";
            Call119(loc);
            ShoutOut(loc);
            Escape(loc);

            Console.WriteLine("--대리자 사용--");
            // 불이 날수도 있으니까 미리 준비
            var otherloc = "경찰서";
            ThereIsAFire fire = new ThereIsAFire(Call119);
            fire += new ThereIsAFire(ShoutOut);
            fire += new ThereIsAFire(Escape); // 대리자에 메서드 추가
            // 불이났다~
            fire(otherloc);

            // 대리자에서 메서드 삭제
            fire -= new ThereIsAFire(Call119);
            fire("다른집");

            // 익명함수
            Calc plus = delegate (int a, int b)
            {
                return a + b;
            };
            Console.WriteLine(plus(6, 7));

            Calc minus = (a, b) => { return a - b; }; // return 부분은 람다식아님
            Console.WriteLine(minus(7, 6));

            // 람다식
            Calc simpleMinus = (a, b) => a - b;
            Console.WriteLine(simpleMinus(7, 6));
            #endregion

            ConCatenate concat = new ConCatenate(ProcComcate);
            var result = concat(args);
            Console.WriteLine(result);

            Console.WriteLine("람다식으로");
            ConCatenate concat2 = (arr) =>
            {
                string res = string.Empty; // ==";
                foreach (string s in arr)
                {
                    res += s + "/";
                }
                return res;
            };
            Console.WriteLine(concat(args));
        }
    }
}
