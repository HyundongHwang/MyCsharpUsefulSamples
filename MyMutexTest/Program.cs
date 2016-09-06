using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyMutexTest
{
    class Program
    {
        static void Main()
        {
            // Unique한 뮤텍스명을 위해 주로 GUID를 사용한다.
            string mtxName = "60C3D9CA-5957-41B2-9B6D-419DC9BE77DF";

            // 뮤텍스명으로 뮤텍스 객체 생성 
            // 만약 뮤텍스를 얻으면, createdNew = true
            bool createdNew;
            Mutex mtx = new Mutex(true, mtxName, out createdNew);

            // 뮤텍스를 얻지 못하면 에러
            if (!createdNew)
            {
                Console.WriteLine("에러: 프로그램 이미 실행중");
                return;
            }

            // 성공하면 본 프로그램 실행
            Console.WriteLine("실행중...");
            Console.ReadLine();
        }
    }
}
