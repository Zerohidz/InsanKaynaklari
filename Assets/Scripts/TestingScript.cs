using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log(PersonNamer.Instance.GetRandomName(JobCriterias.Race.Turkish, true));
        SceneManager.LoadScene(1);
    }
}
