using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 문제 1번 & 2번
namespace number_1_app
{
    class Boiler
    {
        public string Brand;
        //public int Voltage;
        //public int Temperature; // 문제 1번

        private byte voltage;
        public byte Voltage
        {
            get { return voltage; }
            set 
            {
                // 110V와 220V만 저장할 수 있도록 처리
                if (value == 110 || value == 220)
                {
                    voltage = value;
                }
                else
                {
                    Console.WriteLine("*주의* 전압은 110V와 220V 중 하나로 설정해주세요.");
                }
            }
        }
        private int temperature;
        public int Temperature
        {
            get { return temperature; }
            set
            {
                // 물온도는 5도 이하면 5도로, 70도 이상이면 70도로 제한
                if (value <= 5)
                {
                    temperature = 5;
                }
                else if (value >= 70)
                {
                    temperature = 70;
                }
                else
                {
                    temperature = value;
                }
            }
        }
        //public Boiler(string brand, int voltage, int temperature)
        //{
        //    Brand = brand;
        //    Voltage = voltage;
        //    Temperature = temperature;
        //}

        public void printAll()
        {
            Console.WriteLine("브랜드 : {0}, 전압 : {1}, 물온도 : {2}", Brand, voltage, temperature);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Boiler kitturami = new Boiler { Brand = "귀뚜라미", Voltage = 220, Temperature = 45 };
            kitturami.printAll();

            Boiler navi = new Boiler { Brand = "나비엔", Voltage = 120, Temperature = 75 };
            navi.printAll();

        }
    }
}
