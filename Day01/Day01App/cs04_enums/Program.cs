using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs04_enums
{
    internal class Program
    {
        enum HomeTown
        {
            SEOUL,
            DAEJEON = 1, // 값지정가능
            DAEGU,
            BUSAN,
            JEJU
        } // 열거형(오타실수를 줄임)
        static void Main(string[] args)
        {
            HomeTown myHomeTown;
            myHomeTown = HomeTown.BUSAN;

            if(myHomeTown==HomeTown.SEOUL)
            {
                Console.WriteLine("서울 출신이시군요");
            }
            else if(myHomeTown == HomeTown.DAEJEON)
            {
                Console.WriteLine("충청도에유");
            }
            else if(myHomeTown==HomeTown.DAEGU)
            {
                Console.WriteLine("대구여~");
            }
            else if(myHomeTown==HomeTown.BUSAN)
            {
                Console.WriteLine("부산이라예~");
            }
        }
    }
}
