using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs15_accessmodifier
{
    class WaterHeater // 클래스앞에 아무것도 없으면 기본 internal
    {
        protected int temp; // 자식클래스에서만 접근가능(은닉성을 지키기위해)
        // 메서드(멤버함수)를 통해서 접근
        public void SetTemp(int temp)
        {
            if (temp < -5 || temp > 40)
            {
                Console.WriteLine("범위 이탈");
                return;
            }
            else { this.temp = temp; }
        }
        public int GetTemp() 
        {
            return this.temp;
        }
        internal void TurnOnHeater()
        {
            Console.WriteLine("보일러 켭니다 : {0}℃", temp);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            WaterHeater boiler = new WaterHeater();
            boiler.SetTemp(30);
            Console.WriteLine(boiler.GetTemp());
            boiler.TurnOnHeater();
            // boiler.temp = 38;
        }
    }
}
