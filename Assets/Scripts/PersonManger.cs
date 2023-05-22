using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

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
        PositiveTrait[] positiveTraits = EnumHelper.GetRandomRange<PositiveTrait>((int)Math.Sqrt(GameController.Instance.Day) * 2).ToArray();
        NegativeTrait[] negativeTraits = EnumHelper.GetRandomRange<NegativeTrait>((int)Math.Sqrt(GameController.Instance.Day) * 2).ToArray();

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
        if (companyRequest.Jobs is not null && companyRequest.Jobs.Length > 0)
            MakeCorrectJob(personInfo, companyRequest);
        if (companyRequest.PositiveTraits is not null)
            MakeCorrectPositiveTrait(personInfo, companyRequest);
        if (companyRequest.NegativeTraits is not null)
            MakeCorrectNegativeTrait(personInfo, companyRequest);
    }

    public void MakeFalsePerson(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        // TODO: fix this

        var properties = (Jobs: companyRequest.Jobs, PosTraits: companyRequest.PositiveTraits, NegTraits: companyRequest.NegativeTraits);

        List<int> operations = properties switch
        {
            (not null, not null, not null) => BoolHelper.GetRandomBool() ?
                                                new List<int> { new[] { 1, 2, 3 }.GetRandom() } :
                                                new int[] { 1, 2, 3 }.GetRandomRange(2).ToList(),
            (not null, not null, null) => new List<int> { new[] { 1, 2 }.GetRandom() },
            (not null, null, not null) => new List<int> { new[] { 1, 3 }.GetRandom() },
            (not null, null, null) => new List<int> { 1 },
            (null, not null, not null) => new List<int> { new[] { 2, 3 }.GetRandom() },
            (null, not null, null) => new List<int> { 2 },
            (null, null, not null) => new List<int> { 3 },
            _ => new List<int>()
        };

        var actions = new Dictionary<int, Action> {
            { 0, () => MakeFalseJob(personInfo, companyRequest) },
            { 1, () => MakeFalsePositiveTrait(personInfo, companyRequest) },
            { 2, () => MakeFalseNegativeTrait(personInfo, companyRequest) }
        };

        operations.ForEach(operation => actions[operation]?.Invoke());

    }

    private static void MakeCorrectPositiveTrait(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        var positiveTraits = companyRequest.PositiveTraits.ToList();
        // Kesin barýndýracaðý positive trait sayýsý normalde barýndýrmasý gerekenden azsa gerisini rastgele tamamla
        if (positiveTraits.Count < personInfo.PositiveTraits.Length)
        {
            var allPositiveTraits = EnumHelper.GetValues<PositiveTrait>().ToList();
            allPositiveTraits.RemoveAll(t => positiveTraits.Contains(t));
            positiveTraits.AddRange(allPositiveTraits.GetRandomRange(personInfo.PositiveTraits.Length - positiveTraits.Count));
        }
        personInfo.PositiveTraits = positiveTraits.ToArray();
        personInfo.PositiveTraits.Shuffle();
    }

    private static void MakeFalsePositiveTrait(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        // TODO: test this

        // allPositiveTraits'ten hepsini deðil rastgele bir kýsmýný çýkaracaðýz
        var positiveTraits = companyRequest.PositiveTraits.ToList();
        positiveTraits = positiveTraits.GetRandomRange(UnityEngine.Random.Range(1, positiveTraits.Count + 1)).ToList();

        List<PositiveTrait> allPositiveTraits = EnumHelper.GetValues<PositiveTrait>().ToList();
        allPositiveTraits.RemoveAll(t => positiveTraits.Contains(t));
        personInfo.PositiveTraits = allPositiveTraits.GetRandomRange(personInfo.PositiveTraits.Length).ToArray();
    }

    private static void MakeCorrectNegativeTrait(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        List<NegativeTrait> allNegativeTraits = EnumHelper.GetValues<NegativeTrait>().ToList();
        allNegativeTraits.RemoveAll(t => companyRequest.NegativeTraits.Contains(t));
        personInfo.NegativeTraits = allNegativeTraits.GetRandomRange(personInfo.NegativeTraits.Length).ToArray();
    }

    private static void MakeFalseNegativeTrait(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        // TODO: test this

        // Ýstenmeyen negative trait'lerden rasgele miktarýný seç
        var negativeTraits = companyRequest.NegativeTraits.GetRandomRange(UnityEngine.Random.Range(1, companyRequest.NegativeTraits.Length + 1)).ToList();

        // Kalan kýsmýný da bunlar dýþýndakilerle doldur
        if (negativeTraits.Count < personInfo.NegativeTraits.Length)
        {
            List<NegativeTrait> allNegativeTraits = EnumHelper.GetValues<NegativeTrait>().ToList();
            allNegativeTraits.RemoveAll(t => negativeTraits.Contains(t));
            negativeTraits.AddRange(allNegativeTraits.GetRandomRange(personInfo.NegativeTraits.Length - negativeTraits.Count));
        }
        personInfo.NegativeTraits = negativeTraits.ToArray();
        personInfo.NegativeTraits.Shuffle();
    }

    private static void MakeCorrectJob(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        personInfo.Job = companyRequest.Jobs.GetRandom();
    }

    private static void MakeFalseJob(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        List<Job> jobs = EnumHelper.GetValues<Job>().ToList();
        jobs.RemoveAll(j => companyRequest.Jobs.Contains(j));
        personInfo.Job = jobs.GetRandom();
    }
}

// private static void MakeCorrectJobWithFields(PersonInfo personInfo, CompanyRequest companyRequest)
// {
//if ((companyRequest.Jobs is not null && companyRequest.Jobs.Length > 0) ||
//    (companyRequest.JobFields is not null && companyRequest.JobFields.Length > 0))
//{
//    if (companyRequest.Jobs is not null && (BoolHelper.GetRandomBool() || companyRequest.JobFields is null))
//        personInfo.Job = companyRequest.Jobs.GetRandom();
//    else if (companyRequest.JobFields is not null)
//        personInfo.Job = JobCriterias.JobsOfJobFields[companyRequest.JobFields.GetRandom()].GetRandom();
//}

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
//  }