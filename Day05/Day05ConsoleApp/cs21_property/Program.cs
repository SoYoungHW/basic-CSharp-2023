using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs21_property
{
    class Boiler
    {
        private int temp; // 기본멤버변수 - 소문자
        public int Temp // 프로퍼티(속성) - 대문자로 시작
        {
            get { return temp; }
            set // 프로퍼티 set 할때 무조건 value 사용
            {
                if (value <= 10 || value >= 70)
                {
                    temp = 10; // 제일 낮은 온도로 변경설정
                }
                else
                { 
                    temp = value;
                }
            }
        }

        // get; set;과 비교(아래의 Get메서드와 Set메서드는 Java에서만 사용, C#은 거의X)
        public void SetTemp(int temp)
        {
            if (temp <= 10 || temp >= 70)
            {
                //Console.WriteLine("수온설정값이 너무 낮거나 높습니다. 10~70도 사이로 지정해주세요");
                //return;
                this.temp = 10;
            } // 도메인이랑 똑같은 것(DB에서)
            else
            {
                this.temp = temp;
            }
        }
        public int GetTemp()
        {
            return this.temp;
        }
    }

    class Car
    {
        string name;
        string color;
        int year;
        string fuelType;
        int door;
        string tireType;
        string company;
        int price;
        string carIDNumber;
        string carPlateNumer;

        public string Name { get; set; } // 필터링이 필요없으면 멤버변수없이 프로퍼티로 대체
        public string Color { get; set; } // get; 하나만 쓰는 것도 가능(출력만가능하게-값입력불가)
        // string Color X                 // set; 만 쓰는 것은 불가!

        // 들어오는 데이터를 필터링할때는 private 멤버변수와 프로퍼티를 둘다 사용
        public int Year
        {
            get { return year; } // get => year; 람다식 
            set
            {
                if (value <= 1990 || value >= 2023)
                {
                    year = 2023;
                }
                else
                {
                    year = value;
                }
            }
        }
        public string FuelType
        {
            get => fuelType;
            set
            {
                if (value != "휘발유" || value != "경유")
                {
                    value = "휘발유";
                }
                else
                {
                    fuelType = value;
                }
            }
        }
        public int Door
        {
            get { return door; }
            set
            {
                if (value != 2 || value != 4)
                {
                    value = 4;
                }
                else
                {
                    door = value;
                }
            }
        }
        public string TireType { get; set; }
        public string Company { get; set; } = "현대자동차"; // 기본적으로 할당(자동할당)
        public int Price { get => price; set => price = value; }
        public string CarIDNumber { get; set; }
        public string CarPlateNumer { get; set; }
    }

    // 인터페이스를 사용
    interface IProduct
    {
        string ProductName { get; set; }

        void Produce();
    }

    class MyProduct : IProduct
    {
        private string productname;
        public string ProductName 
        {
            get { return ProductName; }
            set { ProductName = value; } 
        }

        public void Produce()
        {
            Console.WriteLine("{0}을(를) 생산합니다.", ProductName);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kittu = new Boiler();
            //kittu.temp = 60;

            ////...
            //kittu.temp = 300000; // 보일러 물수온 30만℃?
            //kittu.temp = -120;
            // 이런식으로 데이터 오염이 일어남
            // -> get/set 사용
            kittu.SetTemp(50);
            Console.WriteLine(kittu.GetTemp()); // 구식방법

            Boiler navi = new Boiler();
            navi.Temp = 5000; // 프로퍼티는 변수처럼 사용(명칭은 프로퍼티!)
            Console.WriteLine(navi.Temp);

            Car ionic = new Car() { Name = "아이오닉" }; // set
            // ionic.Name = "아이오닉";
            Console.WriteLine(ionic.Name); // get

            // 생성할 때 프로퍼티로 초기화
            Car genesis = new Car()
            {
                Name = "제네시스",
                FuelType = "휘발유",
                Color = "보라색",
                Door = 4,
                TireType = "광폭타이어",
                Year = 0,
            };
            Console.WriteLine("자동차 제조회사는 {0}", genesis.Company);
            Console.WriteLine("자동차 제조년도는 {0}년", genesis.Year);
        }
    }
}
