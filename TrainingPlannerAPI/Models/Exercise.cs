using System.Reflection.Metadata;

namespace vbsessionplan.Models;
public class Exercise
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Instructions { get; set; } = "";
    public int ParticipantsMin { get; set; }
    public int? ParticipantsMax { get; set; }
    public int? MinimumDuration { get; set; }
    public int? RecommendedDuration { get; set; }
    // public Skills PrimarySkill { get; set; } = Skills.Passing;
    // public Skills[] SecondarySkills { get; set; } = [];
    public Blob GIFImage { get; set; }
}


// public enum Skills
// {
//     Passing,
//     Setting,
//     Attacking,
//     Serving,
//     Blocking
// }