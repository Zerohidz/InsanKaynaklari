using TMPro;
using UnityEngine;

public class CV : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Gender;
    public TextMeshProUGUI Age;
    public TextMeshProUGUI Job;
    public TextMeshProUGUI ExperienceYears;
    public TextMeshProUGUI GoodHabits;
    public TextMeshProUGUI BadHabits;

    public void SetInfo(PersonInfo personInfo)
    {
        Name.SetText(personInfo.Name);
        Gender.SetText(personInfo.Gender.GetDisplay());
        Age.SetText(personInfo.Age.ToString());
    }
}
