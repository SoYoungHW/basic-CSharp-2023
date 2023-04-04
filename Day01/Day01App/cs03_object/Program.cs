using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs03_object
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Object 형식
            int idata = 1024; // Int32 idta = 1024;
            // int == System.Int32
            // C#의 모든것들은 클래스화 되어있음(데이터타입도 클래스)
            // int, char...등은 C, C++와의 호환성 때문에 존재
            // long == System.Int64 
            Console.WriteLine(idata);
            Console.WriteLine(idata.GetType()); // 타입확인
        
            object iobj = (object)idata; // 박싱 : 데이터타입의 값을 오브젝트로 담아라
            Console.WriteLine(iobj);
            Console.WriteLine(iobj.GetType());

            int udata = (int)iobj; // 언박싱 : object를 원래 데이터타입으로 바꿔라
            Console.WriteLine(udata);
            Console.WriteLine(udata.GetType());

            double ddata = 3.141592;
            object pobj = (object)ddata;
            double pdata = (double)pobj;

            Console.WriteLine(pobj);
            Console.WriteLine(pobj.GetType());
            Console.WriteLine(pdata);
            Console.WriteLine(pdata.GetType());

            short sdata = 32000;
            int indata = sdata;
            Console.WriteLine(indata);

            long lndata = long.MaxValue;
            Console.WriteLine(lndata);
            // 작은값을 큰데이터에 넣는건 문제없음
            indata = (int)lndata; // 오버플로우
            Console.WriteLine(indata);

            // float double 간 형변환
            float fval = 3.141592f; // float형은 마지막에 f를 써줘야함
            Console.WriteLine("fval = "+ fval);
            double dval = (double)fval;
            Console.WriteLine("dval = " + dval);
            Console.WriteLine(fval == dval);
            Console.WriteLine(dval == 3.141592);

            // 중요!!
            int numival = 1024;
            string strival = numival.ToString();
            Console.WriteLine(numival);
            Console.WriteLine(strival);
            //Console.WriteLine(numival==strival);
            Console.WriteLine(strival.GetType());

            double numdval = 3.14159265358979;
            string strdval = numdval.ToString();
            Console.WriteLine(strdval);
            Console.WriteLine(strival.GetType());

            // 문자열을 숫자로
            // 주의! 문자열내에 숫자가 아닌 특수문자나, 정수인데 .이 있거나
            string originstr = "300000"; // 3milion은 예외발생
            int convval = Convert.ToInt32(originstr); // int.Parse() 동일
            Console.WriteLine(convval);
            originstr = "1.2345";
            float convfloat = float.Parse(originstr);
            Console.WriteLine(convfloat);

            // 예외발생하지 않도록 형변환 방법
            originstr = "123.4f";
            float ffval;
            // TryFarse는 예외가 발생하면 값은 0으로 대체, 예외없으면 원래값으로
            float.TryParse(originstr, out ffval); // 예외발생하지 않게 숫자변환
            // 형변환 할 수 없으면 0으로 바꿔라
            Console.WriteLine(ffval);

            const double pi = 3.141592;
            Console.WriteLine(pi);
            // pi = 4.54; const(상수화) 값변경불가
        }   
    }
}
