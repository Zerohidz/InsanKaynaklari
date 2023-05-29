using System;
using TMPro;
using UnityEngine;

public class CV : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Gender;
    public TextMeshProUGUI Age;
    public TextMeshProUGUI Race;
    public TextMeshProUGUI Religion;
    public TextMeshProUGUI PoliticView;
    public TextMeshProUGUI Job;
    public TextMeshProUGUI ExperienceYears;
    public TextMeshProUGUI PositiveTraits;
    public TextMeshProUGUI NegativeTraits;

    public void SetInfo(PersonInfo personInfo)
    {
        Name?.SetText(personInfo.Name);
        Gender?.SetText(personInfo.Gender.GetDisplay());
        Age?.SetText(personInfo.Age.GetDisplayAsYears());
        Race?.SetText(personInfo.Race.GetDisplay());
        Religion?.SetText(personInfo.Religion.GetDisplay());
        PoliticView?.SetText(personInfo.PoliticView.GetDisplay());
        Job?.SetText(personInfo.Job.GetDisplay());
        ExperienceYears?.SetText(personInfo.ExperienceYears.GetDisplayAsYears());
        PositiveTraits?.SetText(personInfo.PositiveTraits?.GetDisplay());
        NegativeTraits?.SetText(personInfo.NegativeTraits?.GetDisplay());
    }

    public void Accept()
    {
        GetComponent<Animator>().SetTrigger("Accept");
    }

    public void Reject()
    {
        GetComponent<Animator>().SetTrigger("Reject");
    }
}
