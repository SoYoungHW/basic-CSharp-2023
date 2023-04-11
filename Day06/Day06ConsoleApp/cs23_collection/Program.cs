using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs23_collection
{
    class CustomEnumerator : IEnumerable // foreach를 쓸 수 있는 객체로 만들래
    {
        int[] list = { 1, 3, 5, 7, 9 };

        public IEnumerator GetEnumerator()
        {
            yield return list[0]; // 메서드를 빠져나가지 않고 값만 반환
            yield return list[1]; // return과 달리 보내주고 멈춰있음
            yield return list[2];
            yield return list[3];
            // yield break;
            yield return list[4];
        }

        //public IEnumerator GetEnumerator()
        //{
        //    yield return list[0]; // 메서드를 빠져나가지 않고 값만 반환
        //    yield return list[1]; // return과 달리 보내주고 멈춰있음
        //    yield return list[2];
        //    yield return list[3];
        //    yield break; // break 만나야 빠져나감
        //    yield return list[4];
        //}
    }

    /// <summary>
    /// foreach를 쓸 수 없는 걸 쓸 수 있게 만듦
    /// </summary>
    class MyArraylist : IEnumerator, IEnumerable // 구현해야함
    {
        int[] array; // 배열값 집어넣는 곳
        int position = -1; // 인덱스

        public MyArraylist()
        {
            this.array = new int[3]; // 기본크기 3으로 초기화
        }

        // 인덱스 프로퍼티
        public int this[int index] 
        {
            get { return this[index]; }
            set
            {
                if ( index > this.array.Length )
                {
                    Array.Resize<int>(ref this.array, index + 1); // 배열크기조정
                    Console.WriteLine("MyArrayList Resize : {0}", array.Length); // 중간확인을위해(개발완료후주석처리)
                }
                array[index] = value;
            }
        }

        #region < IEnumerable 인터페이스 구현 >
        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < array.Length; i++) 
            {
                yield return array[i];
            }
        }
        #endregion

        #region < IEnumerator 인터페이스 구현 >
        public object Current
        {
            get { return array[position]; }
        }

        public bool MoveNext()
        {
            if (position == -1)
            {
                Reset();
                return false;
            }

            position++;
            return (position < array.Length);
        }

        public void Reset()
        {
            position = -1;
        }
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new CustomEnumerator();

            foreach (var item in obj)
            {
                Console.WriteLine(item);
            }

            var myArrayList = new MyArraylist();
            for ( var i = 0; i <= 5; i++ )
            {
                // index 프로퍼티를 만들었기 때문에
                myArrayList[i] = i;

                // IEnumerator 구현했기 때문에
                foreach (var item in myArrayList)
                { 
                    Console.WriteLine(item);
                }
            }
        }
    }
}
