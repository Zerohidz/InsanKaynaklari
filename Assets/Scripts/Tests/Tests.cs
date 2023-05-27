using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Tests
{
    public static void PersonGenerationTest(List<PersonInfo> personList)
    {
        int passCount = 0;
        int failCount = 0;
        var request = CompanyRequestManager.Instance.CurrentCompanyRequest;
        foreach (var person in personList)
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

        Debug.Log("Pass count:" + passCount);
        Debug.Log("Fail count:" + failCount);
    }
}
