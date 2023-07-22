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
        GameController.Instance.ShowTutorial(endAction: () =>
        {
            SaveSystem.ResetCareerData();
            GameController.Instance.StartGame();
        });
    }

    public void OnQuitGameButtonPressed()
    {
        Application.Quit();
    }
}
