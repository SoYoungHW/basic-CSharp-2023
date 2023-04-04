using System;
// 사용전에는 색상이 희미함

// 네임스페이스 ConsoleApp1
namespace ConsoleApp1 // 파이썬의 패키지와 동일
{
    /// <summary> xml소스(소스 문서화 자동화툴)
    /// 프로그램 클래스
    /// </summary>
    internal class Program 
    // internal은 private과 비슷
    // 파일명과 클래스명을 동일하게하는게 좋음
    {
        /// <summary>
        /// 메인 엔트리 포인트
        /// </summary>
        /// <param name="args">콘솔 매개변수</param>
        static void Main(string[] args) // 진입점(static void main())
        {
            Console.WriteLine("Hello C#!"); // print()
            // 콘솔에 글자를 출력하는 메소드는 System에 들어있다
        }
    }
}
