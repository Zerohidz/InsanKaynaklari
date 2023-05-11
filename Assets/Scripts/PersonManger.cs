using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonManger : Singleton<PersonManger>
{
    public PersonInfo CurrentPersonInfo { get; private set; }

    public void GenerateNewPerson()
    {
        JobCriterias.Race race = JobCriterias.Race.Turkish;
        bool isMale = Random.Range(0, 1f) < 0.5f;
        int age = Random.Range(JobCriterias.AgeRange.Start.Value, JobCriterias.AgeRange.End.Value);
        CurrentPersonInfo = new()
        {
            Name = NameGenerator.Instance.GetRandomName(race, isMale),
            IsMale = isMale,
            Age = age,
        };
    }
}
