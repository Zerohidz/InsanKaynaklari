using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tests : TestUnit
{
    private List<PersonInfo> _personList;

    public Tests(List<PersonInfo> personList)
    {
        _personList = personList;
    }

    public static void PersonGenerationTest(List<PersonInfo> personList)
    {
        int passCount = 0;
        int failCount = 0;
        List<PersonInfo> failedPersons = new();
        var request = CompanyRequestManager.Instance.CurrentCompanyRequest;
        foreach (var person in personList)
        {
            bool isCorrect = false;
            if (request.Jobs.Contains(person.Job))
                if (request.PositiveTraits is null || request.PositiveTraits.All(j => person.PositiveTraits.Contains(j)))
                    if (request.NegativeTraits is null || request.NegativeTraits.All(j => !person.NegativeTraits.Contains(j)))
                        if (!request.FakeExperienceCheck || person.ExperienceYears <= person.MaxPossibleJobExperience)
                            isCorrect = true;

            if (isCorrect == person.IsCorrect)
                passCount++;
            else
            {
                failedPersons.Add(person);
                failCount++;
            }
        }

        foreach (var person in failedPersons)
        {
            Debug.Log(person.Job.GetDisplay());
            Debug.Log(person.Age);
            Debug.Log(person.ExperienceYears);
        }

        Debug.Log("Pass count:" + passCount);
        Debug.Log("Fail count:" + failCount);
    }

    [Test]
    public void PersonGenerationTest1()
    {
        int passCount = 0;
        int failCount = 0;
        var request = CompanyRequestManager.Instance.CurrentCompanyRequest;
        foreach (var person in _personList)
        {
            bool isCorrect = false;
            if (request.Jobs.Contains(person.Job))
                if (request.PositiveTraits is null || request.PositiveTraits.All(j => person.PositiveTraits.Contains(j)))
                    if (request.NegativeTraits is null || request.NegativeTraits.All(j => !person.NegativeTraits.Contains(j)))
                        isCorrect = true;

            if (isCorrect)
                passCount++;
            else
                failCount++;
        }

        Ensure(passCount == _personList.Count / 2);
        Ensure(failCount == _personList.Count / 2);
    }
}
