using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs13_class
{   
    // 고양이 클래스 생성(파이썬보다 복잡, C++보다는 단순화)
    class Cat // private이라도 같은 cs13_class 안에 있기 때문에 접근가능
    {
        #region < 멤버변수 - 속성 > 
        public string Name; // 이름
        public string Color; // 색상
        public sbyte Age; // 나이 0~255(sbyte)
        #endregion

        #region < 멤버메서드 - 기능 >
        public void Meow()
        {
            Console.WriteLine("{0} 야옹~", Name);
        }
        public void Run()
        {
            Console.WriteLine("{0} 달린다!", Name);
        }
        #endregion

        #region < 생성자 > 
        // 내용 없으면 알아서 만들어줌, 초기화할게 있으면 생성자 직접 생성
        /// <summary>
        /// 기본생성자
        /// </summary>
        public Cat()
        {
            Name = string.Empty;
            Color = string.Empty;
            Age = 0;
        }

        /// <summary>
        /// 사용자 지정 생성자
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        /// <param name="age"></param>
        public Cat(string name, string color = "흰색", sbyte age = 1) // 디폴트값으로 지정
        {
            Name = name;
            Color = color;
            Age = age;
        }

        #endregion
    }
    internal class Program // internal - cs13_class 안에서는 다 쓸 수 있다
    {
        static void Main(string[] args)
        {
            Cat kitty = new Cat(); // 인스턴스를 만들때 New(생성자)
            // kitty 라는 이름의 객체를 생성할게
            kitty.GetType(); // 기본적으로 상속받는 오브젝트(기능) 존재
            kitty.Name = "헬로키티";
            kitty.Color = "흰색";
            kitty.Age = 50;
            kitty.Meow();
            kitty.Run();

            // 객체를 생성하면서 속성 초기화
            Cat nero = new Cat()
            {
                Name = "검은고양이 네로",
                Color = "검은색",
                Age = 27
            };
            nero.Meow();
            nero.Run();

            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세, 타입은 {3} 입니다."
                              , kitty.Name, kitty.Color, kitty.Age, kitty.GetType());
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세 입니다."
                              , nero.Name, nero.Color, nero.Age);

            Cat yaongi = new Cat(); // 기본 생성자
                Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세 입니다."
                              , yaongi.Name, yaongi.Color, yaongi.Age);

            Cat norangi = new Cat("노랑이", "노란색"); // 사용자 지정 생성자
            Console.WriteLine("{0}의 색상은 {1}, 나이는 {2}세 입니다."
                              , norangi.Name, norangi.Color, norangi.Age);
        }
    }
    // private 같은 그룹안에서만 접근가능(외부에서는 접근불가)
    // private 멤버변수나 메서드는 접근안되지만 Cat 클래스는 접근가능(범위유의할것)
}
