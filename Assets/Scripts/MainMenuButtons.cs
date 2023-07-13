using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Button _loadGameButton;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _quitGameButton;

    private void Awake()
    {
        _loadGameButton.interactable = SaveSystem.GameData.CareerData.Day > 1;
    }

    public void OnLoadGameButtonPressed()
    {
        GameController.Instance.StartGame();
    }

    public void OnNewGameButtonPressed()
    {
        Action main = () =>
        {
            SaveSystem.ResetCareerData();
            GameController.Instance.StartGame();
        };

        if (SaveSystem.GameData.Config.ShowTutorial)
            GameController.Instance.ShowTutorial(endAction: main);
        else
            main();
    }

    public void OnQuitGameButtonPressed()
    {
        Application.Quit();
    }
}
