using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs11_logicondition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region < IF구문 >

            int a = 20;
            if (a == 20)
            {
                Console.WriteLine("20 입니다"); // 처리하는 로직있으면 무조건 중괄호쓸것!
                Console.WriteLine("두번째 줄입니다");
            }
            else
            {
                Console.WriteLine("20이 아닙니다.");
            }

            if (a == 30) return; // 메서드를 완전히 빠져나가는 구문은 한줄 OK

            #endregion

            #region < 데이터타입 비교 Switch 구문 >

            // 데이터타입 비교 switch문 (C# 7.0부터 .NET framework 4.7 / 4.8 )
            object obj = null;

            string inputs = Console.ReadLine(); // 콘솔에서 입력받음

            if (int.TryParse(inputs, out int ioutput)) // 예외가 발생하면 0
            {
                obj = ioutput; // 입력한 값이 정수라서 문자열을 정수로 형변환
            }
            else if (float.TryParse(inputs, out float foutput)) 
            {
                obj = foutput; // 입력 값이 실수라서 문자열을 실수로 형변환
            }
            else
            {
                obj = inputs; // 이도저도 아니다
            }

            Console.WriteLine (obj);
            
            switch(obj)
            {
                case int i: // 정수라면
                    Console.WriteLine("{0}은/는 int 형식입니다", i);
                    break; // 필수
                case float f: // 실수라면
                    Console.WriteLine("{0}은/는 float 형식입니다", f);
                    break;
                case string s: // 문자열이면
                    Console.WriteLine("{0}은/는 string 형식입니다", s);
                    break;
                default: // 그외
                    Console.WriteLine("알수없음");
                    break;
            }
            #endregion

            #region < 2중 for문 >

            for (int x = 2; x <= 9; x++)
            {
                for (int y = 1; y <= 9; y++)
                {
                    Console.WriteLine("{0} x {1} = {2}", x, y, x * y);
                }
            }
            #endregion

            #region < Foreach문 >

            int[] ary = { 2, 4, 6, 8, 10 };

            foreach(int i in ary) // 배열이나 컬렉션(리스트)
            {
                Console.WriteLine("{0} x 2 = {1}", i, i * 2);
            }
            // 위아래 완전동일
            for (int i = 0; i < ary.Length; i++)
            {
                Console.WriteLine("{0} x 2 = {1}", ary[i], ary[i] * 2);
            }
            #endregion

            // 점프문(goto)은 쓰지말자!
        }
    }
}
