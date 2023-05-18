using System;
using System.Collections.Generic;
using System.Linq;

public class PersonManger : SingletonMB<PersonManger>
{
    public PersonInfo CurrentPersonInfo { get; private set; }

    public void NextPerson()
    {
        CurrentPersonInfo = CreateRandomPerson();
        MakeCorrectPerson(CurrentPersonInfo, CompanyRequestManager.Instance.CurrentCompanyRequest);
    }

    public PersonInfo CreateRandomPerson()
    {
        int age = UnityEngine.Random.Range(JobCriterias.AgeRange.Start.Value, JobCriterias.AgeRange.End.Value);
        Race race = Race.Turkish;
        Gender gender = BoolHelper.GetRandomOneFrom(Gender.Male, Gender.Female);
        string name = NameGenerator.Instance.GetRandomName(race, gender);
        // TODO: ýrklara göre din rasgeleliði ayarla
        Religion religion = EnumHelper.GetRandom<Religion>();
        PoliticView politicView = EnumHelper.GetRandom<PoliticView>();
        Job job = EnumHelper.GetRandom<Job>();
        int experienceYears = UnityEngine.Random.Range(JobCriterias.ExperienceYearsRange.Start.Value, JobCriterias.ExperienceYearsRange.End.Value);
        PositiveTrait[] positiveTraits = EnumHelper.GetRandomArray<PositiveTrait>((int)Math.Sqrt(GameController.Instance.Day) * 2);
        NegativeTrait[] negativeTraits = EnumHelper.GetRandomArray<NegativeTrait>((int)Math.Sqrt(GameController.Instance.Day) * 2);

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
        MakeCorrectJob(personInfo, companyRequest);
        //personInfo.PositiveTraits =
        //personInfo.NegativeTraits = 
    }

    private static void MakeCorrectJob(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        if ((companyRequest.Jobs is not null && companyRequest.Jobs.Length > 0) ||
            (companyRequest.JobFields is not null && companyRequest.JobFields.Length > 0))
        {
            if (companyRequest.Jobs is not null && (BoolHelper.GetRandomBool() || companyRequest.JobFields is null))
                personInfo.Job = companyRequest.Jobs.GetRandom();
            else if (companyRequest.JobFields is not null)
                personInfo.Job = JobCriterias.JobsOfJobFields[companyRequest.JobFields.GetRandom()].GetRandom();
        }
        
        // This commented code is another version of job correction with different randomization
        // with this version, jobs have less probability to occur
        // -------------------------------------------------------------------------------
        //List<Job> correctJobs = companyRequest.Jobs is not null && companyRequest.Jobs.Length > 0 ? new(companyRequest.Jobs) : new();
        //if (companyRequest.JobFields is not null && companyRequest.JobFields.Length > 0)
        //{
        //    foreach (var jobField in companyRequest.JobFields)
        //        correctJobs.AddRange(JobCriterias.JobsOfJobFields[jobField]);
        //}
        //if (correctJobs.Count > 0)
        //    personInfo.Job = correctJobs.GetRandom();
    }

    public void MakeFalsePerson(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        // TODO: randomly assign personInfo fields from not companyRequest fields if from them
        // 3 özellikten 1 veya 2 tanesi yanlýþ olsun
    }
}
