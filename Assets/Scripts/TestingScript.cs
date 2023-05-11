using UnityEngine;
using UnityEngine.SceneManagement;

public class TestingScript : MonoBehaviour
{
    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PersonManger.Instance.GenerateNewPerson();
            Debug.Log(PersonManger.Instance.CurrentPersonInfo.Name);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
