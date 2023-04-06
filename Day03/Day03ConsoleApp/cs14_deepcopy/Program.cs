using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs14_deepcopy
{
    class SomeClass
    {
        public int SomeField1; // get, set 나중에 나옴
        public int SomeField2;

        public SomeClass DeepCopy() 
        {
            SomeClass newCopy = new SomeClass(); // 깊은 복사
            newCopy.SomeField1 = this.SomeField1; // Call by value
            newCopy.SomeField2 = SomeField2; // this 굳이 안써도 됨

            return newCopy;
        }

        #region < this 사용법 >
        class Employee
        {
            private string Name;

            public void SetName(string Name)
            {
                this.Name = Name; // 클래스의 멤버변수와 메서드의 매개변수 이름이 완전히 동일할 때(대소문자까지)
            }
        }
        class ThisClass
        {
            int a, b, c;
            public ThisClass()
            {
                this.a = 1;
            }
            public ThisClass(int b) : this() // a를 호출하고 b
            {
                this.b = b;
            }
            public ThisClass(int b, int c) : this(b) // b를 호출하고 c
            {
                this.c = c;
            }
        }
        #endregion
        internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("얕은 복사 시작"); // source와 target이 (주소복사) 값이 쉐어(!) 조심!

            SomeClass source = new SomeClass();
            source.SomeField1 = 100;
            source.SomeField2 = 200;

            SomeClass target = source; // 복사생성자 호출
            target.SomeField2 = 300; // 얕은 복사라서 source 값도 바뀜
            // 주의! call by reference, 주소를 넘기기때문에 값도 같이 공유됨

            Console.WriteLine("s.SomeFiled1 -> {0}, s.SomeField -> {1}"
                              , source.SomeField1, source.SomeField2);
            Console.WriteLine("s.SomeFiled1 -> {0}, s.SomeField -> {1}"
                              , target.SomeField1, target.SomeField2);

            Console.WriteLine("깊은 복사 시작");

            SomeClass s = new SomeClass();
            s.SomeField1 = 100;
            s.SomeField2 = 200;
            
            SomeClass t = s.DeepCopy(); // 깊은 복사
            t.SomeField2 = 300;
            Console.WriteLine("s.SomeFiled1 -> {0}, s.SomeField -> {1}"
                              , s.SomeField1, s.SomeField2);
            Console.WriteLine("s.SomeFiled1 -> {0}, s.SomeField -> {1}"
                              , t.SomeField1, t.SomeField2);
        }
    }
}
