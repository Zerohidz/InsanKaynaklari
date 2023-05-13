using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonManger : SingletonMB<PersonManger>
{
    public PersonInfo CurrentPersonInfo { get; private set; }

    public void GenerateNewPerson()
    {
        JobCriterias.Race race = JobCriterias.Race.Turkish;
        Gender gender = Random.Range(0, 1f) < 0.5f ? Gender.Male : Gender.Female;
        int age = Random.Range(JobCriterias.AgeRange.Start.Value, JobCriterias.AgeRange.End.Value);
        CurrentPersonInfo = new()
        {
            Name = NameGenerator.Instance.GetRandomName(race, gender),
            Gender = gender,
            Age = age,
        };
    }
}
