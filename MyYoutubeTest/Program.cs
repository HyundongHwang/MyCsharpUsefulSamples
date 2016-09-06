using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyYoutubeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                // YouTubeService 객체 생성
                var youtube = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyDcOzn3n03txqkLXQBNKKKknbzxbfyfuMQ", // 키 지정
                    ApplicationName = "My YouTube Search"
                });

                // Search용 Request 생성
                var request = youtube.Search.List("snippet");
                request.Q = "양희은";  //ex: "양희은"
                request.MaxResults = 25;

                // Search용 Request 실행
                var result = await request.ExecuteAsync();

                // Search 결과를 리스트뷰에 담기
                foreach (var item in result.Items)
                {
                    if (item.Id.Kind == "youtube#video")
                    {
                        var videoId = item.Id.VideoId.ToString();
                        var title = item.Snippet.Title;
                        Console.WriteLine($"videoId {videoId} title {title}");
                    }
                }
            }).Wait();

            Console.ReadLine();
        }
    }
}
