using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs20_abstractClass
{
        abstract class AbstrackParent
        {
            protected void MethodA()
            {
                Console.WriteLine("AbstractParent.MethodA()");
            }


            public void MethodB() // 클래스랑 동일
            {
                Console.WriteLine("AbstractParent.MethodB()");
                MethodA();
            }

            public abstract void MethodC(); // 인터페이스랑 동일, 추상메서드
        }

        class Child : AbstrackParent
        {
            public override void MethodC() // 재정의(사실은 구현)
            {
                Console.WriteLine("Child.MethodC() - 추상클래스 구현!");
            }
        }

    abstract class Mammal // 포유류 최상위 클래스
    {
        public void Nurse()  // 인터페이스와의 차이
        {
            Console.WriteLine("포유한다");
        }
        public abstract void Sound();
    }

    class Dog : Mammal
    {
        public override void Sound()
        {
            Console.WriteLine("멍멍!");
        }
    } // Sound라는 하나의 함수로 해결하겠다
    // 추상클래스는 인터페이스처럼 함수를 받아서 그곳에서 구현하겠다(쓰는이유?)

    class Cats : Mammal
    {
        public override void Sound()
        {
            Console.WriteLine("야옹~");
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            AbstrackParent parent = new Child();
            parent.MethodC();
            parent.MethodB(); // 자유롭게 사용가능
            // parent.MethodA(); // protected는 자시자신과 자식클래스내에서만 사용가능
        }
    }
}
