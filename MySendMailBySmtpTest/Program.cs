using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MySendMailBySmtpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // MailMessage 객체 생성
            // 파라미터 : (보내는사람, 받는사람, 주제, 본문) 
            var msg = new MailMessage(
                "h2d2002@naver.com", 
                "h2d2002@naver.com, william.hwang@kakaocorp.com",
                $"이메일 테스트 제목 {new Random().Next(1000)}",
                $"이메일 테스트 본문 {new Random().Next(1000)}");

            // SmtpClient 셋업 (Live SMTP 서버, 포트)
            var smtp = new SmtpClient("smtp.naver.com", 587);
            smtp.EnableSsl = true;

            // Live 또는 Hotmail 계정과 암호 필요
            smtp.Credentials = new NetworkCredential("h2d2002", "nhn!@#123");

            // 발송
            smtp.Send(msg);
        }
    }
}
