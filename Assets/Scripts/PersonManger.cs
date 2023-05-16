using System;
using UnityEngine;

public class PersonManger : SingletonMB<PersonManger>
{
    public PersonInfo CurrentPersonInfo { get; private set; }

    public void NextPerson()
    {
        CurrentPersonInfo = CreateRandomPerson();
        print(CurrentPersonInfo);
    }

    public PersonInfo CreateRandomPerson()
    {
        int age = UnityEngine.Random.Range(JobCriterias.AgeRange.Start.Value, JobCriterias.AgeRange.End.Value);
        Race race = Race.Turkish;
        Gender gender = UnityEngine.Random.Range(0, 1f) < 0.5f ? Gender.Male : Gender.Female;
        string name = NameGenerator.Instance.GetRandomName(race, gender);
        // TODO: ýrklara göre din rasgeleliði ayarla
        Religion religion = EnumExtensions.GetRandom<Religion>();
        PoliticView politicView = EnumExtensions.GetRandom<PoliticView>();
        Job job = EnumExtensions.GetRandom<Job>();
        int experienceYears = UnityEngine.Random.Range(JobCriterias.ExperienceYearsRange.Start.Value, JobCriterias.ExperienceYearsRange.End.Value);
        PositiveTrait[] positiveTraits = EnumExtensions.GetRandomArray<PositiveTrait>((int)Math.Sqrt(GameController.Instance.Day) * 2);
        NegativeTrait[] negativeTraits = EnumExtensions.GetRandomArray<NegativeTrait>((int)Math.Sqrt(GameController.Instance.Day) * 2);

        return new()
        {
            Name = name,
            Gender = gender,
            Age = age,
            Race = race,
            Religion = religion,
            PoliticView = politicView,
            Job = job,
            ExperienceYears = experienceYears,
            PositiveTraits = positiveTraits,
            NegativeTraits = negativeTraits,
        };
    }

    public void MakeCorrectPerson(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        // TODO: randomly assign personInfo fields from companyRequest fields
        
    }

    public void MakeFalsePerson(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        // TODO: randomly assign personInfo fields from not companyRequest fields if from them

    }
}
