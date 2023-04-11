using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs25_exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3 };

            try
            {
                for (var i = 0; i < 5; i++)
                {
                    Console.WriteLine(array[i]);
                }
            }
            catch (Exception ex) // 모르겠으면 그냥 Exception
            {
                Console.WriteLine($"Exception: {ex.Message}");
            } // 개발당시에는 전체 예외를 보고 완료되면 메세지만

            finally // 예외가 발생하더라도 무조건 처리해야되는 로직
            {
                // file 객체 close
                // db 연결 close
                // 네크워크 소켓 close
            }
            Console.WriteLine("계속가요");
            try
            {
                DivideTest(array[2], 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("프로그램종료");

            //try
            //{
            //    Console.WriteLine("Test");
            //    throw new Exception("커스텀예외");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }

        private static void DivideTest(int v1, int v2)
        {
            // throw new NotImplementedException(); // 예외던지기
            try
            {
                Console.WriteLine(v1 / v2);
            }
            catch
            {

                throw new Exception("DivideTest 메서드에서 예외발생");
            }
            
        }
    }
}
