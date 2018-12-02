namespace Domain
{
    public interface ITrackInfo
    {
        string Title { get; set; }
        string Artist { get; set; }
        string Uri { get; set; }

        ITrackInfo GetTrackInfo(string resultJson);
    }
}