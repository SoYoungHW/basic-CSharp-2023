using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs24_generic
{

    #region < 일반화 클래스 >
    class MyArray<T> where T : class // 사용할 타입은 무조건 클래스 타입이어야 한다(where T : class)
    {
        T[] array;
    }
    #endregion

    // 하나로 퉁치자! 일반화
    internal class Program
    {
        #region < 일반화 메서드 >
        static void CopyArray<T>(T[] source, T[] target)
        {
            for (var i = 0; i < source.Length; i++)
            {
                target[i] = source[i];
            }
        }
        #endregion

        static void Main(string[] args)
        {
            #region < 일반화 시키기 >
            int[] source = { 1, 2, 4, 5 };
            int[] target = new int[source.Length];
            
            CopyArray<int>(source, target); // <int> 안써도 무방
            foreach ( var i in target ) 
            {
                Console.WriteLine(i);
            }

            long[] source2 = { 2100000, 2300000, 3300000, 5600000, 7800000 };
            long[] target2 = new long[source2.Length];
            
            CopyArray<long>(source2, target2);
            foreach (var i in target2)
            {
                Console.WriteLine(i);
            }

            float[] source3 = { 3.14f, 3.15f, 3.16f};
            float[] target3 = new float[source3.Length];

            CopyArray<float>(source3, target3);
            foreach (var i in target3)
            {
                Console.WriteLine(i);
            }
            #endregion

            // 일반화 컬렉션 
            List<int> list = new List<int>();
            for (var i = 10; i > 0; i--)
            {
                list.Add(i);
            }

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            list.RemoveAt(3); // 7 삭제

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            list.Sort();

            foreach( var i in list)
            {
                Console.WriteLine(i);
            }

            // 제일 많이 사용
            // 아래와 같은 일반화 컬렉션을 자주 볼 수 있음(눈에 익혀두기!)
            List<MyArray<string>> myStringArray = new List<MyArray<string>>();

            // 일반화 스택
            Stack<float> stFlaot = new Stack<float>();
            stFlaot.Push(3.15f);
            stFlaot.Push(4.28f);
            stFlaot.Push(7.24f);

            while (stFlaot.Count > 0)
            {
                Console.WriteLine(stFlaot.Pop()); // 정석
            }

            // 일반화 큐
            Queue<string> qStrings = new Queue<string>();
            qStrings.Enqueue("Hello");
            qStrings.Enqueue("World");
            qStrings.Enqueue("My");
            qStrings.Enqueue("C#");

            while (qStrings.Count > 0)
            {
                Console.WriteLine(qStrings.Dequeue());
            }

            // 일반화 딕셔너리 그다음 많이 사용
            Dictionary<string, int> dictNumbers = new Dictionary<string, int>();
            dictNumbers["하나"] = 1;
            dictNumbers["둘"] = 2;
            dictNumbers["셋"] = 3;
            dictNumbers["넷"] = 4;

            Console.WriteLine(dictNumbers["셋"]);

        }
    }
}