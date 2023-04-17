using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 문제 4번
namespace number_4_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> color = new Dictionary<string, string>();
            {
                //{ "red", "빨간색" },
                //{ "orange", "주황색" },
                //{ "yellow", "노란색"},
                //{ "green", "초록색"},
                //{ "blue", "파란색"},
                //{ "indigo", "남색" },
                //{ "puple", "보라색" }

                color.Add("red", "빨간색");
                color.Add("orange", "주황색");
                color.Add("yellow", "노란색");
                color.Add("green", "초록색");
                color.Add("blue", "파란색");
                color.Add("indigo", "남색");
                color.Add("puple", "보라색");
            };

            Console.Write("무지개 색은 ");

            foreach (var item in color.Values)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("입니다");


            Console.WriteLine("Key와 Value 확인");

            foreach (var item in color) 
            {
               Console.WriteLine($"{item.Key}은(는) {item.Value}입니다.");
            }

            Console.WriteLine($"puple은 {color["puple"]}입니다.");
        }
    }
}
