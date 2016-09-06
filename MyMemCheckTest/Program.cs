using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyMemCheckTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 초기 메모리 (베이스)
            long mem = GC.GetTotalMemory(false);
            Console.WriteLine("Initial Memory: {0}", mem);

            // 특정 함수 호출
            Run();

            // 함수 호출후 메모리
            mem = GC.GetTotalMemory(false);
            Console.WriteLine("Current Memory: {0}", mem);

            // 메모리 Clean Up 
            GC.Collect();
            Thread.Sleep(5000);

            // 메모리 Clean Up 후 
            mem = GC.GetTotalMemory(false);
            Console.WriteLine("After GC Memory: {0}", mem);

            Console.ReadLine();
        }

        // 아래 함수에서 대량의 메모리
        // 사용하는 객체 생성
        static void Run()
        {
            var obj = new LargeDataClass();
            obj.Set(1, 10);
        }
    }

    // 대량 데이타 필드를 가진 클래스
    class LargeDataClass
    {
        // memory = 4 * 1,000,000 = 4M
        private int[] data = new int[1000000];

        public void Set(int index, int value)
        {
            data[index] = value;
        }
    }
}
