using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 문제 3번
namespace number_2_app
{
    class Car
    {
        private string name;
        private string maker;
        private string color;
        private int yearmodel;
        private int maxspeed;
        private string uniquenumber;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Maker
        {
            get => maker;
            set => maker = value;
        }
        public string Color
        {
            get => color;
            set => color = value;
        }
        public int YearModel
        {
            get => yearmodel;
            set
            {
                if (value > 2023)
                {
                    yearmodel = 2023;
                }
                else 
                {
                    yearmodel = value;
                }
            }
        }
        public int Maxspeed
        {
            get => maxspeed;
            set
            {
                if (maxspeed > 220)
                {
                    maxspeed = 220;
                }
                else
                {
                    maxspeed = value;
                }
            }
        }
        public string UniqueNumber
        {
            get => uniquenumber;
            set => uniquenumber = value;
        }

        public void Start()
        {
            Console.WriteLine("{0}의 시동을 겁니다", Name);
        }
        public void Accelerate()
        {
            Console.WriteLine("최대시속 {0}㎞/h로 가속합니다", Maxspeed);
        }
        public void TurnRight()
        {
            Console.WriteLine("{0}을/를 우회전 합니다", Name);
        }
        public void Brake()
        {
            Console.WriteLine("{0}의 브레이크를 밟습니다", Name);
        }
    }

    class ElectricCar : Car
    {
        public virtual void Recharge()
        {
            Console.WriteLine("배터리를 충전합니다");
        }
    }

    class HybridCar : ElectricCar
    {
        public override void Recharge()
        {
            Console.WriteLine("달리면서 배터리를 충전합니다");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            HybridCar ionic = new HybridCar();
            ionic.Name = "아이오닉";
            ionic.Maker = "현대자동차";
            ionic.Color = "White";
            ionic.YearModel = 2018;
            ionic.Maxspeed = 220;
            ionic.UniqueNumber = "54라 3346";

            ionic.Start();
            ionic.Accelerate();
            ionic.Recharge();
            ionic.TurnRight();
            ionic.Brake();
        }
    }
}
