using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs05_nullable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int형은 기본적으로 null값이 될 수 없음
            int? a = null; // C# 6.0 Nullable
            Console.WriteLine(a == null);
            // Console.WriteLine(a.GetType()); // 예외발생 null은 타입없음

            int b = 0;
            Console.WriteLine(b == null);
            Console.WriteLine(b.GetType());

            // 값 형식 byte, short, int, long, float, double, char 등은 null 할당X
            // null을 할당할 수 있도록 만드는 방식 type?

            float? c = null;
            Console.WriteLine(c.HasValue); // c에 값이 있는지
            Console.WriteLine(c);
            c = 3.14f;
            Console.WriteLine(c.HasValue);
            Console.WriteLine(c.Value);
            Console.WriteLine(c);
        }
    }
}
