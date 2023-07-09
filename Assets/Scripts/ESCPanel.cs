using Krivodeling.UI.Effects;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ESCPanel : MonoBehaviour
{
    public UIBlur Blur;
    public Button ResumeButton;
    public Button QuitButton;

    public void OnResumeButtonPressed()
    {
        Unpause();
    }

    public void OnQuitButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
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
        Blur.Intensity = 1;

        ResumeButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);

        GameController.Instance.GameState = GameState.Paused;
    }

    private void Unpause()
    {
        Blur.Intensity = 0;

        ResumeButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);

        GameController.Instance.GameState = GameState.Day;
    }
}
