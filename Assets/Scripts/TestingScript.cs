using System;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    void Start()
    {
        PersonNamer personNamer = new PersonNamer();

        foreach (JobCriterias.Race race in Enum.GetValues(typeof(JobCriterias.Race)))
            for (int i = 0; i < 10; i++)
            {
                bool isMale = UnityEngine.Random.Range(0f, 1f) < 0.5f;

                Debug.Log(personNamer.GetRandomName(race, isMale));
            }
    }
}
