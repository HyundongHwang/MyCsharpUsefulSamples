using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyScreenCopyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // 주화면의 크기 정보 읽기
            int width = (int)SystemParameters.PrimaryScreenWidth;
            int height = (int)SystemParameters.PrimaryScreenHeight;

            // 화면 크기만큼의 Bitmap 생성
            using (Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb))
            {
                // Bitmap 이미지 변경을 위해 Graphics 객체 생성
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    // 화면을 그대로 카피해서 Bitmap 메모리에 저장
                    gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                }
                // Bitmap 데이타를 파일로 저장
                bmp.Save("test.png", ImageFormat.Png);
            }
        }

    }
}
