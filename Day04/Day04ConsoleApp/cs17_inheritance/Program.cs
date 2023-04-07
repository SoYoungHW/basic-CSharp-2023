using cs17_inheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs17_inheritance
{
    // 상속을 하는 이유 : 상위클래스로 묶어서 프로세스를 간략화가능(메서드의 개수감소) // 객체지향 특징
    // 예) 사육사 동물관리
    class Parent // 부모클래스
    {
        protected String Name; // 상속할때는 private 쓰지말기

        public Parent(string Name) // 생성자
        {
            this.Name = Name;
            Console.WriteLine("{0} from Parent 생성자", Name);
        }
        public void ParentMethod()
        {
            Console.WriteLine("{0} from Parent 메서드", Name);
        }
    }

    class Child : Parent // 자식클래스
    {
        public Child(string Name) : base(Name)
        {
            Console.WriteLine("{0} from Child 생성자", Name); // 부모생성자 먼저 실행 후, 자신생성자를 생성
        }
        public void ChildMethod()
        {
            Console.WriteLine("{0} from Child 메서드", Name); // private이면 접근불가
        }
    }

    // 클래스간 형변환 DB처리, DI
    class Mammal // 포유류
    {
        public void Nurse() // 기르다
        {
            Console.WriteLine("포유류 기르다");
        }
    }

    class Dogs : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("멍멍!");
        }
    }

    class Cats : Mammal
    {
        public void Meow()
        {
            Console.WriteLine("야옹~");
        }
    }

    class Elephant : Mammal
    {
        public void Poo()
        {
            Console.WriteLine("뿌");
        }
    }

    class Zookeeper
    {
        public void Wash(Mammal mammal)
        {
            if (mammal is Elephant)
            {
                var animal = mammal as Elephant;
                Console.WriteLine("코끼리를 씻깁니다");
                animal.Poo();
            }
            else if (mammal is Dogs)
            {
                var animal = mammal as Dogs;
                Console.WriteLine("강아지를 씻깁니다");
                animal.Bark();
            }
            else if ( mammal is Cats)
            {
                var animal = mammal as Cats;
                Console.WriteLine("고양이를 씻깁니다");
                animal.Meow();
                animal.Meow();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region < 기본 상속 개념 >
            Parent p = new Parent("p");
            p.ParentMethod();

            Console.WriteLine("자식클래스 생성");
            Child c = new Child("c"); // 1.부모생성자 -> 2.자식생성자
            c.ParentMethod();
            c.ChildMethod();
            // 자식클래스는 부모클래스의 속성, 기능을 모두 쓸 수 있다(단 public이나 protected 일때만)
            #endregion

            #region < 클래스 간 형식변환 >
            // Mammal mammal = new Mammal(); // 기본
            Mammal mammal = new Dogs(); // 부모클래스로 형변환
            // mammal.Bark(); // 바로안됨
            if (mammal is Dogs)
            {
                Dogs midDog = mammal as Dogs;
                // Dogs midDog = (Dogs)mammal; 구식
                midDog.Bark();
            }   // 이렇게 써야 Bark() 가능 : is ~ as~

            // Dogs dogs = new Mammal(); // 불가
            // 자식클래스(Dogs)는 부모가 가진 특성을 다 가지고 있지만(Nurse)
            // 부모클래스(Mammal)은 자식이 가진 특성중 없는게 있다(Bark)
            // 부모클래스가 자식클래스로 변환은 불가

            Zookeeper keeper = new Zookeeper();
            keeper.Wash(mammal);
            // 부모클래스가 없으면 개, 고양이, 코끼리 하나하나 다 만들어야함

            #endregion
        }


    }
}
