using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs16_inheritance
{
    class Base // 부모(=기반) 클래스
    {   // 자식클래스에 상속받으려면 private은 안써야함
        protected string Name;
        private string Color; // 만약에 상속을 할거면 private를 protected로 변경!
        public int Age;

        public Base(string Name, string Color, int Age)
        {
            this.Name = Name;
            this.Color = Color;
            this.Age = Age;
            Console.WriteLine("{0}.Base()", Name);
        }
        public void BaseMethod()
        {
            Console.WriteLine("{0}.BaseMethod()", Name);
        }

        public void GetColor()
        {
            Console.WriteLine("{0}, {1}.BaseColor()", Name, Color);
        }
    }

    class Child : Base // 자식클래스
        // 상속받은 이후에 Base의 Name, Color, Age 새로 만들거나 하지 않음
    {
        public Child(string Name, string Color, int Age) : base(Name, Color, Age)
        {
            Console.WriteLine("{0}.Child()", Name);
        }

        public void ChildMethod() 
        {
            Console.WriteLine("{0}.ChildMethod()", Name) ; // Name, Age 접근가능
        }

        public void ChildGetColor()
        {
            // Console.WriteLine("{0}.ChildGetColor()", Color);
        } // Color 접근불가
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Base b = new Base("NameB", "Red", 1);
            b.BaseMethod();
            b.GetColor();

            Child c = new Child("NameC", "Pink", 2); // 먼저 부모클래스 생성자 호출 -> 자식클래스 생성자 호출
            c.ChildMethod(); // 자식클래스 함수
            c.GetColor(); // 부모클래스 GetColor 호출, c에서 Color 접근불가
        }
    }
}
