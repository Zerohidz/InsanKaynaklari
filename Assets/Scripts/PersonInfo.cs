using UnityEngine;

public class PersonInfo
{
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }
    public Race Race { get; set; }
    public Religion Religion { get; set; }
    public PoliticView PoliticView { get; set; }
    public Job Job { get; set; }
    public int ExperienceYears { get; set; }
    public PositiveTrait[] PositiveTraits { get; set; }
    public NegativeTrait[] NegativeTraits { get; set; }
}
