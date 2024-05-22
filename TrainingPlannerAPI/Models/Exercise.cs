using System.Reflection.Metadata;

namespace vbsessionplan.Models;
public class Exercise
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Instructions { get; set; } = "";
    public Skills PrimarySkill { get; set; } = Skills.Passing;
    public Skills[] SecondarySkills { get; set; } = [];
    public Blob GIFImage { get; set; } = new Blob();
}


public enum Skills
{
    Passing,
    Setting,
    Attacking,
    Serving,
    Blocking
}