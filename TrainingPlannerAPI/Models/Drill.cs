using System.Reflection.Metadata;
using MongoDB.Bson;

namespace vbsessionplan.Models;
public class Drill
{
    public ObjectId Id { get; set; }
    public string Title { get; set; } = "";
    public string Instructions { get; set; } = "";
    public int ParticipantsMin { get; set; }
    public int? ParticipantsMax { get; set; }
    public int? MinimumDuration { get; set; }
    public int? RecommendedDuration { get; set; }
    public Blob GIFImage { get; set; }
}