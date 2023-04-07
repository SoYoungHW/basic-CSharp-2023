using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs19_interface
{
    interface ILogger // 인터페이스(=약속)
    {
        void WriteLog(string log); // 상속받을거면 이부분을 반드시 만들어서 구현해라
    }

    interface IFormattableLogger : ILogger // 상속 비슷
    {
        void WriteLog(string format, params object[] args); // 오버로딩
        // args 다중 파라미터
    }


    class ConsoleLogger : ILogger // 인터페이스는 상속X 구현O 이라고 부름
    {
        public void WriteLog(string log) // 구현
        {
            Console.WriteLine("{0}, {1}", DateTime.Now.ToLocalTime(), log);
        }
    }

    class ConsoleLogger2 : IFormattableLogger
    {
        public void WriteLog(string log)
        {
            Console.WriteLine("{0}, {1}", DateTime.Now.ToLocalTime(), log);
        }

        public void WriteLog(string format, params object[] args)
        {
            string message = string.Format(format, args);
            Console.WriteLine("{0}, {1}", DateTime.Now.ToLocalTime(), message);
        }
    }

    class Car
    {
        public string Name { get; set; }
        public string Color { get; set; }

        public void Stop()
        {
            Console.WriteLine("정지!");
        }
    }

    interface IHoverable
    {
    void Hover(); // 물에서 달린다
    }

    interface IFlyable
    {
    void Fly(); // 날다
    }

    // C#에는 다중상속 X
    class FlyHoverCar : Car, IFlyable, IHoverable
    {
        public void Fly()
        {
            Console.WriteLine("날다");
        }
        public void Hover()
        {
            Console.WriteLine("물에서");
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger(); // new ILogger() X (new는 클래스만)
            logger.WriteLog("안녕~!");

            IFormattableLogger logger2 = new ConsoleLogger2();
            logger2.WriteLog("{0} x {1} = {2}", 6, 5, (6 * 5));
        }
    }
}
