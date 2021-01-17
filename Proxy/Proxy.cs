using System;
using System.Collections.Generic;

namespace Proxy
{   
    class Video
    {

    }
    interface IDownloader
    {
        Video Download(string url);
    }
    class YoutubeDownloader : IDownloader
    {
        public Video Download(string url)
        {
            Console.WriteLine("Downloading...");
            return new Video();
        }
    }

    class CacheDownloader : IDownloader
    {
        private IDownloader _d;
        private Dictionary<string, Video> _cache = new Dictionary<string, Video>();

        public CacheDownloader(IDownloader d)
        {
            SetDownloader(d);
        }
        public void SetDownloader(IDownloader d)
        {
            _d = d;
        }
        public Video Download(string url)
        {
            //
            if (!_cache.TryGetValue(url, out var v))
            {
                v = _d.Download(url);
                _cache[url] = v;
            }
            return v;
        }
    }
    class Proxy
    {
        static void Main(string[] args)
        {
            var d = new CacheDownloader(new YoutubeDownloader());

            d.Download("www");
            d.Download("www");
            d.Download("www");
            d.Download("www");
        }
    }
}
