using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Domain
{
    public class TrackInfo : ITrackInfo
    {
        public TrackInfo()
        {
        }

        public TrackInfo(string result)
        {
        }

        public string Artist { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }

        public ITrackInfo GetTrackInfo(string resultJson)
        {
            var results = JToken.Parse(resultJson);
            this.Artist = results["item"]["artists"][0]["name"].ToString();
            this.Title = results["item"]["name"].ToString();
            this.Uri = $"https://open.spotify.com/embed/track/{results["item"]["id"]}";
            return this;
        }
    }
}