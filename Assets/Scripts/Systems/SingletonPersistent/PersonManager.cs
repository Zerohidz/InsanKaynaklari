using System;
using System.Collections.Generic;
using System.Linq;
using TreeEditor;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class PersonManger : SingletonMB<PersonManger>
{
    private static int PersonListSize = 20;
    private delegate void Operation(PersonInfo p, CompanyRequest c);
    private List<PersonInfo> _personList = new();

    public PersonInfo CurrentPersonInfo { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (IsBeingDestroyed)
            return;

        GameController.OnDayChanged += (_) => GeneratePersonList();
    }

    public override void Reset()
    {
        _personList.Clear();
    }

    public void NextPerson()
    {
        if (_personList is null || _personList.Count < 1)
            GeneratePersonList();

        CurrentPersonInfo = _personList[0];
        _personList.RemoveAt(0);
    }

    private void GeneratePersonList()
    {
        List<PersonInfo> newPersonList = new();
        for (int i = 0; i < PersonListSize; i++)
        {
            PersonInfo randomPerson = CreateRandomPerson();

            if (i < PersonListSize / 2)
                MakeCorrectPerson(randomPerson, CompanyRequestManager.Instance.CurrentCompanyRequest);
            else
                MakeIncorrectPerson(randomPerson, CompanyRequestManager.Instance.CurrentCompanyRequest);

            newPersonList.Add(randomPerson);
        }

        ObeyIncorrectExperienceRule(newPersonList);

        _personList = newPersonList.Shuffled().ToList();
        //Tests.PersonGenerationTest(_personList);
    }

    private void ObeyIncorrectExperienceRule(List<PersonInfo> personList)
    {
        int count = 0;
        if (GameController.Instance.Day == 2)
            count = 6;
        else if (GameController.Instance.Day == 3)
            count = 3;
        else if (GameController.Instance.Day == 4)
            count = 2;
        else if (GameController.Instance.Day == 5)
            count = 2;

        var request = CompanyRequestManager.Instance.CurrentCompanyRequest;
        for (int i = 0; i < count; i++)
        {
            if (i < count / 3)
                MakeCorrectPerson(personList[10 + i], request);
            MakeIncorrectExperience(personList[10 + i]);
        }
    }

    private PersonInfo CreateRandomPerson()
    {
        int age = UnityEngine.Random.Range(JobCriterias.AgeRange.Start.Value, JobCriterias.AgeRange.End.Value);
        Race race = EnumHelper.GetRandom<Race>();
        Gender gender = BoolHelper.GetRandomOneFrom(Gender.Male, Gender.Female);
        string name = NameGenerator.Instance.GetRandomName(race, gender);
        Religion religion = GetRandomReligion(race);
        PoliticView politicView = EnumHelper.GetRandom<PoliticView>();
        Job job = EnumHelper.GetRandom<Job>();
        int experienceYears = GetRandomExperience(age);
        PositiveTrait[] positiveTraits = EnumHelper.GetRandomRange<PositiveTrait>(2).ToArray();
        NegativeTrait[] negativeTraits = JobCriterias.GetAvailableNegativeTraits(positiveTraits)
                                                     .GetRandomRange(2).ToArray();

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

    private static int GetRandomExperience(int age)
    {
        return UnityEngine.Random.Range(0, age - JobCriterias.MinimumJobYear + 1);
    }

    private Religion GetRandomReligion(Race race)
    {
        Religion randomReligion = EnumHelper.GetRandom<Religion>();
        return race switch
        {
            Race.Turkish => BoolHelper.GetRandomFromPersentage(95) ? Religion.Islam : randomReligion,
            Race.Arab => BoolHelper.GetRandomFromPersentage(90) ? Religion.Islam : randomReligion,
            Race.Russsian => BoolHelper.GetRandomFromPersentage(77) ? Religion.Christianity : randomReligion,
            Race.German => BoolHelper.GetRandomFromPersentage(60) ? Religion.Christianity : randomReligion,
            Race.American => BoolHelper.GetRandomFromPersentage(67) ? Religion.Christianity : randomReligion,
            _ => randomReligion,
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

        personInfo.IsCorrect = true;
    }

    public void MakeIncorrectPerson(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        List<(Operation Operation, Operation OppositeOperation, bool IsNotNull)> nullChecks = new()
        {
            (MakeIncorrectJob, MakeCorrectJob, companyRequest.Jobs is not null),
            (MakeIncorrectPositiveTrait, MakeCorrectPositiveTrait, companyRequest.PositiveTraits is not null),
            (MakeIncorrectNegativeTrait, MakeCorrectNegativeTrait, companyRequest.NegativeTraits is not null),
        };

        // Faz2: Yanlýþ insanlarýn yanlýþ özellikleri ihtimalen 2 tanesi veya 1 tanesi yanlýþ þeklinde,
        // Biz bunu kesin insan sayýsý haline getirmeliyiz (örn: 15 kiþiden 5'i 1 özellik, 5'i 2, 5'i 3 özellik yanlýþ)
        var nonNulls = nullChecks.Where(kv => kv.IsNotNull).ToList();
        var operations = (nonNulls.Count() switch
        {
            3 => nonNulls.GetRandomRange(BoolHelper.GetRandomOneFrom(1, 2, 3)),
            2 => nonNulls.GetRandomRange(BoolHelper.GetRandomOneFrom(1, 2)),
            1 => nonNulls,
            _ => null,
        }).ToList();

        operations?.ForEach(op => op.Operation?.Invoke(personInfo, companyRequest));

        var oppositeOperations = nonNulls.Except(operations).Select(n => n.OppositeOperation);
        oppositeOperations.ToList().ForEach(oop => oop?.Invoke(personInfo, companyRequest));
        personInfo.IsCorrect = false;
    }

    private static void MakeCorrectJob(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        personInfo.Job = companyRequest.Jobs.GetRandom();
    }

    private static void MakeIncorrectJob(PersonInfo personInfo, CompanyRequest companyRequest)
    {
        // Faz2 : Kiþi yanlýþlýðý sayý kesinliði

        // Faz2 : Birden fazla alandan job gelirse bu satýr zortlar
        // Sen en iyisi bu fonksiyonu tekrar yaz
        // Ýlk iki gün deðilse %90 ihtimal ver filan yaptýk
        List<Job> allJobs = JobCriterias.JobsOfJobFields[companyRequest.JobFields[0].JobField].ToList();
        if (allJobs.All(j => companyRequest.Jobs.Contains(j)) || BoolHelper.GetRandomFromPersentage(10))
            allJobs = EnumHelper.GetValues<Job>().ToList();

        allJobs.RemoveAll(j => companyRequest.Jobs.Contains(j));
        personInfo.Job = allJobs.GetRandom();
    }

    private static void MakeCorrectExperience(PersonInfo personInfo, CompanyRequest companyRequest)
    {

    }

    private static void MakeIncorrectExperience(PersonInfo personInfo, CompanyRequest companyRequest = null)
    {
        personInfo.ExperienceYears = UnityEngine.Random.Range(
            personInfo.MaxPossibleJobExperience + 1,
            personInfo.MaxPossibleJobExperience + 4 + 1
        );
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

    private static void MakeIncorrectPositiveTrait(PersonInfo personInfo, CompanyRequest companyRequest)
    {
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

    private static void MakeIncorrectNegativeTrait(PersonInfo personInfo, CompanyRequest companyRequest)
    {
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