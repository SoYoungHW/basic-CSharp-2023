using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs30_filereadwrite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = string.Empty; // 텍스트를 읽어와서 출력
            StreamReader reader = null;

            try 
            {
                reader = new StreamReader(@".\python.py"); // 스트림리더 파일 연결
                line = reader.ReadLine(); // 한줄씩 읽음

                while (line != null)
                {
                    Console.WriteLine(line); // 한줄 읽은 것 출력
                    line = reader.ReadLine(); // 다음줄을 읽음

                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"예외! {ex.Message}");
            }
            finally // 예외가 발생해도 안해도
            {
                reader.Close(); // 파일을 읽으면 무조건 마지막에 Close!
            }

            // 읽기 끝

            StreamWriter writer = new StreamWriter(@".\pythonByCsharp");

            try
            {
                writer.WriteLine("import sys;");
                writer.WriteLine("");
                writer.WriteLine("print(sys.executable);");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"예외! {ex.Message}");
            }
            finally
            {
                writer.Close();
            }
            Console.WriteLine("파일생성완료");

            // 쓰기 끝
        }
    }
}
