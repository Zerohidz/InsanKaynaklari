using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ESCPanel : MonoBehaviour
{
    public RawImage BackgroundBlocker;
    public Button ResumeButton;
    public Button QuitButton;

    public void OnResumeButtonPressed()
    {
        Unpause();
    }

    public void OnQuitButtonPressed()
    {
        Quit();
    }

    public void ToggleShow()
    {
        SetIsShowing(!GameController.Instance.IsPaused);
    }

    public void SetIsShowing(bool willPause)
    {
        if (GameController.Instance.IsPaused)
        {
            if (willPause == false)
            {
                Unpause();
            }
        }
        else if (willPause == true)
        {
            Pause();
        }
    }

    private void Pause()
    {
        BackgroundBlocker.gameObject.SetActive(true);

        ResumeButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);

        GameController.Instance.GameState = GameState.Paused;
    }

    private void Unpause()
    {
        BackgroundBlocker.gameObject.SetActive(false);

        ResumeButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);

        GameController.Instance.GameState = GameState.Day;
    }

    private static void Quit()
    {
        GameController.Instance.GameState = GameState.MainMenu;
        SceneManager.LoadScene("MainMenu");
    }
}
